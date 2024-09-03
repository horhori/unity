using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBee : MonsterMovableType
{
    // ����, ������, ������ ���� �����ϱ�
    
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
            // ��ǥ ��ġ ����, ��ǥ ��ġ �̵�
            targetPosition = player.transform.position;
            nav.SetDestination(targetPosition);

            // ��ǥ ��ġ���� �Ÿ��� 0.5 �ɶ����� ���
            yield return new WaitUntil(() => Vector3.Distance(transform.position, targetPosition) <= 0.5f);

            nav.SetDestination(transform.position);

            // m_MoveDelay��ŭ ���
            yield return new WaitForSeconds(m_MoveDelay);
        }
    }
}
