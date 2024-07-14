using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �������..
public class EnemyHomingMissile : MonoBehaviour
{
    // �÷��̾ ������ ����
    public GameObject m_Player;

    // �÷��̾� ��ġ�� �޾ƿ� �� ���� �ð��� üũ�� ����
    private float _PlayerLocationUpdateCheckTime = 0.0f;

    // Sprite Renderer�� ������ �� �ִ� ����
    public SpriteRenderer m_SpriteRenderer = null;

    // ����
    private Vector2 _ShootDirection = Vector2.zero;

    // �ӵ�
    private float _ShootingSpeed = 0.2f;

    // �ְ�ӵ�
    private const float _MaxShootingSpeed = 10.0f;

    private void Update()
    {
        UpdateTargetPosition();

        UpdateShootingSpeed();

        Shoot();
    }

    private void UpdateTargetPosition()
    {
        // 0.5�ʸ��� �÷��̾� ��ġ�� �޾ƿ�
        if (Time.time - _PlayerLocationUpdateCheckTime >= 0.5f)
        {
            _PlayerLocationUpdateCheckTime = Time.time;

            _ShootDirection = m_Player.transform.position;

            _ShootDirection.x = transform.position.x;
        }
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
