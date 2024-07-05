using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 만드는중..
public class EnemyHomingMissile : MonoBehaviour
{
    // 플레이어를 참조할 변수
    public GameObject m_Player;

    // 플레이어 위치를 받아올 때 지난 시간을 체크할 변수
    private float _PlayerLocationUpdateCheckTime = 0.0f;

    // Sprite Renderer에 접근할 수 있는 변수
    public SpriteRenderer m_SpriteRenderer = null;

    // 방향
    private Vector2 _ShootDirection = Vector2.zero;

    // 속도
    private float _ShootingSpeed = 0.2f;

    // 최고속도
    private const float _MaxShootingSpeed = 10.0f;

    private void Update()
    {
        UpdateTargetPosition();

        UpdateShootingSpeed();

        Shoot();
    }

    private void UpdateTargetPosition()
    {
        // 0.5초마다 플레이어 위치를 받아옴
        if (Time.time - _PlayerLocationUpdateCheckTime >= 0.5f)
        {
            _PlayerLocationUpdateCheckTime = Time.time;

            _ShootDirection = m_Player.transform.position;

            _ShootDirection.x = transform.position.x;
        }
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
