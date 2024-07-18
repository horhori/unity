using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowType : EnemyBase
{
    [SerializeField]
    private float _MoveSpeed = 5.0f;

    private Transform _PlayerTransform = null;

    private Vector2 _MoveDirection = Vector2.down;

    protected override void Awake()
    {
        base.Awake();
        _PlayerTransform = GameManager.gameManager.playerInstance.transform;

    }

    private void Update()
    {
        // 플레이어가 적보다 오른쪽에 있다면
        _MoveDirection.x = (_PlayerTransform.position.x > transform.position.x) ? 1.0f : -1.0f;

        transform.Translate(_MoveDirection * _MoveSpeed * Time.deltaTime, Space.World);
    }
}
