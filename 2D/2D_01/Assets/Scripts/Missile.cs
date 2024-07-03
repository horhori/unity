using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    // ����
    private readonly Vector2 _FallDirection = Vector2.down;

    // �ӵ�
    private float _FallingSpeed = 0.2f;

    // �ְ�ӵ�
    private const float _MaxFallingSpeed = 10.0f;

    private void Update()
    {
        UpdateFallingSpeed();

        Fall();
    }

    // �������� �ӵ��� ���� ������
    private void UpdateFallingSpeed()
    {

        _FallingSpeed = Mathf.MoveTowards(_FallingSpeed, _MaxFallingSpeed, 10f * Time.deltaTime);
    }

    private void Fall()
    {
        transform.Translate(_FallDirection * _FallingSpeed * Time.deltaTime, Space.World);
    }
}
