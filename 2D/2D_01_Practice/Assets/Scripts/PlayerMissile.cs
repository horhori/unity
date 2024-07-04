using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMissile : MonoBehaviour
{
    // ����
    private readonly Vector2 _ShootDirection = Vector2.right;

    // �ӵ�
    private float _ShootingSpeed = 0.2f;

    // �ְ�ӵ�
    private const float _MaxShootingSpeed = 10.0f;

    private void Update()
    {
        UpdateShootingSpeed();

        Shoot();
    }

    // �ӵ��� ������
    private void UpdateShootingSpeed()
    {
        _ShootingSpeed = Mathf.MoveTowards(_ShootingSpeed, _MaxShootingSpeed, 10f * Time.deltaTime);
    }

    private void Shoot()
    {
        transform.Translate(_ShootDirection * _ShootingSpeed * Time.deltaTime, Space.World);
    }
}
