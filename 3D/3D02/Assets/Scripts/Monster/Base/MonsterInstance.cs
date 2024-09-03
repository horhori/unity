using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonsterInstance : MonoBehaviour, IMonster
{
    public const float BeginDelay = 1.0f;

    public HpBar m_HpCanvasPrefab = null;

    public bool isDie { get; protected set; }

    public float hp { get; set; } = 100.0f;

    public float maxHp { get; set; } = 100.0f;

    [SerializeField] protected float _Def = 10.0f;
    public PlayerInstance player { get; protected set; }
    
    public HpBar hpBar { get; private set; }

    public MonsterManager monsterManager { get; private set; }

    public CharacterManager characterManager { get; private set; }

    // 몬스터가 데미지를 입었을 때 처음 호출된 메서드 대리자
    protected System.Action<PlayerInstance, float> MonsterBeginDamaged;

    // 몬스터가 사망했을 때 OnDisable보다 먼저 호출할 메서드 대리자
    protected System.Action MonsterBeginDead;

    public abstract void Attack();

    public abstract void Damage(float damage);

    protected virtual void Awake()
    {
        IEnumerator DieCheck()
        {
            yield return new WaitUntil(() => hp <= 0.0f);
            MonsterBeginDead?.Invoke();
            gameObject.SetActive(false);
        }

        monsterManager = GameManager.GetManagerClass<MonsterManager>();
        characterManager = GameManager.GetManagerClass<CharacterManager>();

        // 생성된 몬스터 인스턴스를 리스트에 추가
        monsterManager.stageMonsters.Add(this);

        // > hp ui 생성
        hpBar = Instantiate(m_HpCanvasPrefab);

        // > hp UI가 따라다닐 Transform 생성
        hpBar.SetHUDTransform(transform.Find("HUDTransform"));

        MonsterBeginDamaged = (PlayerInstance playerInstance, float playerAtk) =>
        hp -= (playerAtk / _Def);

        MonsterBeginDead = () =>
        {
            isDie = true;

            // MonsterManager의 stageMonste에서 해당 오브젝트를 가진 요소를 제거
            monsterManager.stageMonsters.Remove(this);
        };

        StartCoroutine(DieCheck());
    }
    
    protected virtual void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("PlayerArrow"))
        {
            MonsterBeginDamaged?.Invoke(player, characterManager.playerAtk);
        }
    }
}
