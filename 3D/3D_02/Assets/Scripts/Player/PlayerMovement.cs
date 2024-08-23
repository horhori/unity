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

    // 플레이어 속도
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
        // 공격중이라면
        if (_PlayerInstance.playerAutoAttack.isAttacking &&
            _MonsterManager.stageMonsters.Count != 0 &&
            _PlayerInstance.playerAutoAttack.targetMonster)
        {
            lookDirection = gameObject.GetDirectionVector(_PlayerInstance.playerAutoAttack.targetMonster.gameObject);
        }

        // 공격중이지 않다면
        else
        {
            lookDirection = (direction != Vector3.zero) ? direction.normalized : lookDirection;
            
        }

        direction = _CharacterManager.inputVector;

        _PlayerInstance.controller.SimpleMove(direction * m_MoveSpeed);

        // 오브젝트 회전

        // 플레이어가 공격중이라면
        if (_PlayerInstance.playerAutoAttack.isAttacking &&
            _PlayerInstance.playerAutoAttack.targetMonster)
        {
            // 가장 가까운 적을 향하는 방향  벡터를 얻고 그 방향을 바라보도록 함
            gameObject.RotateTo(
                gameObject.GetDirectionVector(
                    _PlayerInstance.playerAutoAttack.targetMonster.gameObject));
        }

        // 플레이어가 공격중이 아니라면
        else
        {
            if(direction != Vector3.zero)
            {
                gameObject.RotateTo(direction);
            }
        }
    }
}
