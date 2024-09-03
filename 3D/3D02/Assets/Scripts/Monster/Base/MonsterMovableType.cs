using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class MonsterMovableType : MonsterInstance, IMovement
{
    // ����
    public Vector3 direction {  get; private set; }

    // NavMeshAgent ������Ƽ
    public NavMeshAgent nav { get; private set; }

    // ��ǥ ��ġ
    protected Vector3 targetPosition { get; set; } = Vector3.zero;

    // �̵� ���� üũ�� ������Ƽ
    protected bool moveStarted { get; private set; } = false;

    // �̵� �� ������
    protected float m_MoveDelay = 1.0f;

    public abstract void Movement();

    protected override void Awake()
    {
        base.Awake();
        nav = GetComponent<NavMeshAgent>();
    }

    protected virtual void Start()
    {
        IEnumerator StartDelay()
        {
            yield return new WaitForSeconds(BeginDelay);
            moveStarted = true;
        }

        player = GameManager.GetManagerClass<CharacterManager>().player;
        StartCoroutine(StartDelay());
    }
}
