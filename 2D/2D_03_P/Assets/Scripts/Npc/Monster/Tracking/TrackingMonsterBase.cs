using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TrackingMovement))]
public class TrackingMonsterBase : MonsterBase
{
    public TrackingMovement movement { get; private set; }

    public NavMeshAgent2D nav { get; private set; }

    // ��ǥ�� �������� ���� �� ���� �����̿� ���� ������ ��ġ�� �̵�
    // true�϶��� �̵�
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

    // �������� �ƴҶ����� �ʿ����� ���ƴٴϵ��� �մϴ�.
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
