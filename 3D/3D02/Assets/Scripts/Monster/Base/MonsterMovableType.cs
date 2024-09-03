using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class MonsterMovableType : MonsterInstance, IMovement
{
    // 방향
    public Vector3 direction {  get; private set; }

    // NavMeshAgent 프로퍼티
    public NavMeshAgent nav { get; private set; }

    // 목표 위치
    protected Vector3 targetPosition { get; set; } = Vector3.zero;

    // 이동 시작 체크할 프로퍼티
    protected bool moveStarted { get; private set; } = false;

    // 이동 후 딜레이
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
