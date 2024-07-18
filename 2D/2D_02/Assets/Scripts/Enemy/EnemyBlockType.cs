using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlockType : EnemyBase
{
    [SerializeField]
    private float _MoveSpeed = 5.0f;

    private void Update()
    {
        EnemyMove();
    }

    private void EnemyMove()
    {
        transform.Translate(Vector2.down * _MoveSpeed * Time.deltaTime);
    }
}
