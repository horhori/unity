using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingMovement : MonoBehaviour, IMovement
{
    public TrackingMonsterBase monsterInstance { get; private set; }

    public Vector2 dirVector { get; private set; }

    // 추적중인 확인할때 사용할 프로퍼티
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
        // 추적 상태 전환
        isTracking = true;

        // 목표 위치 설정
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
