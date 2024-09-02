using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAutoAttack : MonoBehaviour
{
    private CharacterManager _CharacterManager = null;

    // 복사 생성할 화살 프리팹
    [SerializeField] private PlayerArrow _ArrowPrefab;

    // 화살 발사할 위치
    [SerializeField] private Transform _ArrowShotPointTransform = null;

    // 가장 가까운 몬스터에 대한 프로퍼티
    public MonsterInstance targetMonster { get; private set; }

    // 몬스터 매니저
    public MonsterManager monsterManager { get; private set; }

    // 오브젝트 풀
    private ObjectPool<PlayerArrow> _ArrowPool = null;

    // 현재 공격중인지 검사
    public bool isAttacking { get; set; } = false;

    private void Awake()
    {
        IEnumerator AutoUpdateTargetMonster()
        {
            // 몬스터 인스턴스
            MonsterInstance prevTargetMonster = null;
            yield return new WaitUntil(() => monsterManager.stageMonsters.Count != 0);

            while (true)
            {
                yield return new WaitWhile(() =>
                {
                    bool result = false;

                    try
                    {
                        result = prevTargetMonster == monsterManager.stageMonsters[0];
                    }
                    // ArgumentOutOfRangeException : 비어있는 리스트 요소에 접근하면 생기는 에러
                    catch (System.ArgumentOutOfRangeException)
                    {
                        result = true;
                    }

                    return result;
                });

                prevTargetMonster = targetMonster = monsterManager.stageMonsters[0];
            }
        }
        _CharacterManager = GameManager.GetManagerClass<CharacterManager>();
        monsterManager = GameManager.GetManagerClass<MonsterManager>();

        _ArrowPool = new ObjectPool<PlayerArrow>();
        StartCoroutine(AutoUpdateTargetMonster());
    }

    private void Start()
    {
        StartCoroutine(AutoAttackStart());
        StartCoroutine(BeginMoveCheck());
    }
    private IEnumerator AutoAttackStart()
    {
        while(true)
        {
            yield return new WaitUntil(() =>
            _CharacterManager.inputVector == Vector3.zero && !isAttacking &&
            monsterManager.stageMonsters.Count != 0);

            // 공격 중 상태 변경
            isAttacking = true;

            // 공격 애니메이션 재생
            _CharacterManager.player.animInstance.PlayAttackAnimation();
        }
    }
    private IEnumerator BeginMoveCheck()
    {
        Vector3 prevPlayerMoveDirection = _CharacterManager.inputVector;

        while(true)
        {
            yield return new WaitWhile(() =>
                prevPlayerMoveDirection == _CharacterManager.inputVector);
            prevPlayerMoveDirection = _CharacterManager.inputVector;

            //  이동 시작 했고 아직 공격중인 상태라면
            if(prevPlayerMoveDirection != Vector3.zero &&
                _CharacterManager.player.playerAutoAttack.isAttacking)
            {
                // 공격 중지
                _CharacterManager.player.animInstance.AttackEnd();
            }
        }
    }
    public void Attack()
    {
        // 재사용 가능한 오브젝트 찾고 없다면 새로 생성 후 등록
        PlayerArrow arrow = _ArrowPool.GetRecyclableObject() ??
            _ArrowPool.RegisterRecyclableObject(Instantiate(_ArrowPrefab));

        // 화살 활성화
        if (arrow.gameObject.activeSelf)
            arrow.isActive = true;
        else
            arrow.gameObject.SetActive(arrow.isActive = true);

        // 발사 위치
        arrow.transform.position = _ArrowShotPointTransform.position;
    }
}
