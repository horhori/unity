using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    // 방향
    private readonly Vector2 _ShootDirection = Vector2.right;

    // 속도
    private float _ShootingSpeed = 0.1f;

    // 최고속도
    private const float _MaxShootingSpeed = 5.0f;

    private void Update()
    {
        UpdateShootingSpeed();

        Shoot();
    }

    // 속도를 빠르게
    private void UpdateShootingSpeed()
    {
        _ShootingSpeed = Mathf.MoveTowards(_ShootingSpeed, _MaxShootingSpeed, 10f * Time.deltaTime);
    }

    private void Shoot()
    {
        transform.Translate(_ShootDirection * _ShootingSpeed * Time.deltaTime, Space.World);
    }
}
