using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    // 방향
    private readonly Vector2 _FallDirection = Vector2.down;

    // 속도
    private float _FallingSpeed = 0.2f;

    // 최고속도
    private const float _MaxFallingSpeed = 10.0f;

    private void Update()
    {
        UpdateFallingSpeed();

        Fall();
    }

    // 떨어지는 속도를 점점 빠르게
    private void UpdateFallingSpeed()
    {

        _FallingSpeed = Mathf.MoveTowards(_FallingSpeed, _MaxFallingSpeed, 10f * Time.deltaTime);
    }

    private void Fall()
    {
        transform.Translate(_FallDirection * _FallingSpeed * Time.deltaTime, Space.World);
    }
}
