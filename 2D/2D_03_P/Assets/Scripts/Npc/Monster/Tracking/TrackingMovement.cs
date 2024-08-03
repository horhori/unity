using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingMovement : MonoBehaviour, IMovement
{
    public TrackingMonsterBase monsterInstance { get; private set; }

    public Vector2 dirVector { get; private set; }

    // �������� Ȯ���Ҷ� ����� ������Ƽ
    public bool isTracking { get; private set; }

    private Vector2 _TrackingTarget = Vector2.zero;

    private void Awake()
    {
        monsterInstance = GetComponent<TrackingMonsterBase>();
    }

    private void Update()
    {
        Movement();
        dirVector = monsterInstance.nav.velocity;
    }

    public void Movement()
    {
        monsterInstance.nav.SetDestination(_TrackingTarget);
    }
    public void StartTracking(Vector2 trackingTarget)
    {
        // ���� ���� ��ȯ
        isTracking = true;

        // ��ǥ ��ġ ����
        MoveToTarget(trackingTarget);
    }

    public void MoveToTarget(Vector2 target)
    {
        _TrackingTarget = target;
    }

    public void StopTracking()
    {
        isTracking = false;
    }
}
