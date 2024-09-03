using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBee : MonsterMovableType
{
    // 공격, 데미지, 움직임 직접 구현하기
    
    private IAnimInstance _Animinstance = null;

    protected override void Awake()
    {
        base.Awake();
        _Animinstance = GetComponentInChildren<IAnimInstance>();
    }

    protected override void Start()
    {
        base.Start();
        StartCoroutine(FollowPlayer());
    }

    protected virtual void Update()
    {
        _Animinstance.SetFloat("_Speed", nav.velocity.magnitude);
    }

    public override void Attack()
    {
       
    }

    public override void Damage(float damage)
    {
       
    }

    public override void Movement()
    {
        
    }

    private IEnumerator FollowPlayer()
    {
        yield return new WaitUntil(() => moveStarted);

        while (true)
        {
            // 목표 위치 설정, 목표 위치 이동
            targetPosition = player.transform.position;
            nav.SetDestination(targetPosition);

            // 목표 위치와의 거리가 0.5 될때까지 대기
            yield return new WaitUntil(() => Vector3.Distance(transform.position, targetPosition) <= 0.5f);

            nav.SetDestination(transform.position);

            // m_MoveDelay만큼 대기
            yield return new WaitForSeconds(m_MoveDelay);
        }
    }
}
