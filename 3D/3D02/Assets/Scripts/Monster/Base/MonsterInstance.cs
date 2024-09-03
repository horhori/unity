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

    // ���Ͱ� �������� �Ծ��� �� ó�� ȣ��� �޼��� �븮��
    protected System.Action<PlayerInstance, float> MonsterBeginDamaged;

    // ���Ͱ� ������� �� OnDisable���� ���� ȣ���� �޼��� �븮��
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

        // ������ ���� �ν��Ͻ��� ����Ʈ�� �߰�
        monsterManager.stageMonsters.Add(this);

        // > hp ui ����
        hpBar = Instantiate(m_HpCanvasPrefab);

        // > hp UI�� ����ٴ� Transform ����
        hpBar.SetHUDTransform(transform.Find("HUDTransform"));

        MonsterBeginDamaged = (PlayerInstance playerInstance, float playerAtk) =>
        hp -= (playerAtk / _Def);

        MonsterBeginDead = () =>
        {
            isDie = true;

            // MonsterManager�� stageMonste���� �ش� ������Ʈ�� ���� ��Ҹ� ����
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
