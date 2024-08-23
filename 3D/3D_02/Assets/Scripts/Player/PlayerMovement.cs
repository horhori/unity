using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMovement
{
    private CharacterManager _CharacterManager = null;

    private MonsterManager _MonsterManager = null;

    private PlayerInstance _PlayerInstance = null;

    public Vector3 direction { get; private set; }
    public Vector3 lookDirection { get; private set; }

    // �÷��̾� �ӵ�
    [Range(1.0f, 100.0f)] public float m_MoveSpeed = 6.0f;

    private void Awake()
    {
        _CharacterManager = GameManager.GetManagerClass<CharacterManager>();
        _MonsterManager = GameManager.GetManagerClass<MonsterManager>();
        _PlayerInstance = GetComponent<PlayerInstance>();
    }

    private void Update()
    {
        (this as IMovement).Movement();
    }

    void IMovement.Movement()
    {
        // �������̶��
        if (_PlayerInstance.playerAutoAttack.isAttacking &&
            _MonsterManager.stageMonsters.Count != 0 &&
            _PlayerInstance.playerAutoAttack.targetMonster)
        {
            lookDirection = gameObject.GetDirectionVector(_PlayerInstance.playerAutoAttack.targetMonster.gameObject);
        }

        // ���������� �ʴٸ�
        else
        {
            lookDirection = (direction != Vector3.zero) ? direction.normalized : lookDirection;
            
        }

        direction = _CharacterManager.inputVector;

        _PlayerInstance.controller.SimpleMove(direction * m_MoveSpeed);

        // ������Ʈ ȸ��

        // �÷��̾ �������̶��
        if (_PlayerInstance.playerAutoAttack.isAttacking &&
            _PlayerInstance.playerAutoAttack.targetMonster)
        {
            // ���� ����� ���� ���ϴ� ����  ���͸� ��� �� ������ �ٶ󺸵��� ��
            gameObject.RotateTo(
                gameObject.GetDirectionVector(
                    _PlayerInstance.playerAutoAttack.targetMonster.gameObject));
        }

        // �÷��̾ �������� �ƴ϶��
        else
        {
            if(direction != Vector3.zero)
            {
                gameObject.RotateTo(direction);
            }
        }
    }
}
