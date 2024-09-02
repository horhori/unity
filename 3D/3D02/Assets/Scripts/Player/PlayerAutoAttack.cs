using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAutoAttack : MonoBehaviour
{
    private CharacterManager _CharacterManager = null;

    // ���� ������ ȭ�� ������
    [SerializeField] private PlayerArrow _ArrowPrefab;

    // ȭ�� �߻��� ��ġ
    [SerializeField] private Transform _ArrowShotPointTransform = null;

    // ���� ����� ���Ϳ� ���� ������Ƽ
    public MonsterInstance targetMonster { get; private set; }

    // ���� �Ŵ���
    public MonsterManager monsterManager { get; private set; }

    // ������Ʈ Ǯ
    private ObjectPool<PlayerArrow> _ArrowPool = null;

    // ���� ���������� �˻�
    public bool isAttacking { get; set; } = false;

    private void Awake()
    {
        IEnumerator AutoUpdateTargetMonster()
        {
            // ���� �ν��Ͻ�
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
                    // ArgumentOutOfRangeException : ����ִ� ����Ʈ ��ҿ� �����ϸ� ����� ����
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

            // ���� �� ���� ����
            isAttacking = true;

            // ���� �ִϸ��̼� ���
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

            //  �̵� ���� �߰� ���� �������� ���¶��
            if(prevPlayerMoveDirection != Vector3.zero &&
                _CharacterManager.player.playerAutoAttack.isAttacking)
            {
                // ���� ����
                _CharacterManager.player.animInstance.AttackEnd();
            }
        }
    }
    public void Attack()
    {
        // ���� ������ ������Ʈ ã�� ���ٸ� ���� ���� �� ���
        PlayerArrow arrow = _ArrowPool.GetRecyclableObject() ??
            _ArrowPool.RegisterRecyclableObject(Instantiate(_ArrowPrefab));

        // ȭ�� Ȱ��ȭ
        if (arrow.gameObject.activeSelf)
            arrow.isActive = true;
        else
            arrow.gameObject.SetActive(arrow.isActive = true);

        // �߻� ��ġ
        arrow.transform.position = _ArrowShotPointTransform.position;
    }
}
