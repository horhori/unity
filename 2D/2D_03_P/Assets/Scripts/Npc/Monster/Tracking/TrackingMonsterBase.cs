using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TrackingMovement))]
public class TrackingMonsterBase : MonsterBase
{
    public TrackingMovement movement { get; private set; }

    public NavMeshAgent2D nav { get; private set; }

    // 목표가 추적하지 않을 때 랜덤 딜레이에 따라 랜덤한 위치로 이동
    // true일때만 이동
    [SerializeField] private bool _RandomMove = true;

    [Range(0.0f, 10.0f)]
    [SerializeField] private float _TrackingDelay = 0.3f;

    protected override void Awake()
    {
        base.Awake();

        nav = GetComponent<NavMeshAgent2D>();
        movement = GetComponent<TrackingMovement>();

        OnPlayerDetectedStart = (PlayerInstance playerInstance) => StartCoroutine(FindPlayer());
        OnPlayerDetectedEnd = (PlayerInstance playerInstance) => movement.StopTracking();
    }

    protected virtual void Start()
    {
        if (_RandomMove) StartCoroutine(RandomMove());
    }

    private IEnumerator FindPlayer()
    {
        do
        {
            movement.StartTracking(characterManager.playerCharacter.transform.position);
            yield return new WaitForSeconds(_TrackingDelay);
        }
        while (movement.isTracking);
    }

    // 추적중이 아닐때에는 맵영역을 돌아다니도록 합니다.
    private IEnumerator RandomMove()
    {
        while(true)
        {
            movement.MoveToTarget(GameStatics.GetRandomPositionInBounds(existenceArea.area.bounds));
            yield return new WaitUntil(() => !movement.isTracking &&
            movement.dirVector == Vector2.zero);
            yield return new WaitForSeconds(Random.Range(0.5f, 2.0f));
        }
    }
}
