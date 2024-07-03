using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airplane : MonoBehaviour
{
    // �÷��̾ ������ ����
    public GameObject m_Player;

    // �÷��̾ ���� �̵���ų ����
    private const float _AirPlaneSpeed = 8.0f;

    // �÷��̾� ��ġ�� �޾ƿ� ������ ����
    /// - ����Ⱑ �� ��ġ�� �޾ƿͼ� ��� �̵�
    private Vector2 _MoveTargetPosition = Vector2.zero;

    // �÷��̾� ��ġ�� �޾ƿ� �� ���� �ð��� üũ�� ����
    private float _PlayerLocationUpdateCheckTime = 0.0f;

    // Sprite Renderer�� ������ �� �ִ� ����
    public SpriteRenderer m_SpriteRenderer = null;

    // ���� ������ų �̻����� ���� ������Ʈ�� ������ ����
    /// - �������� ������ ����
    public GameObject m_MissileOri = null;

    // �̻����� ����߸� �� ���� �ð��� üũ�� ����
    public float _MissileDropCheckTime = 0.0f;

    private void Start()
    {
        // �ʱ���ġ ����
        _MoveTargetPosition = transform.position;
    }

    private void Update()
    {
        // �÷��̾ �����ϴ� ���ȿ��� �ϴ� ������ ����
        if (!m_Player) return;

        FollowPlayerCharacterX();

        UpdateTargetPosition();

        MissileDrop();
    }

    // �÷��̾��� ��ġ�� ���󰡰�
    private void FollowPlayerCharacterX()
    {
        // ������Ʈ�� ��ġ�� ��ǥ ��ġ�� �̵�
        transform.position = Vector2.MoveTowards(
            transform.position,
            _MoveTargetPosition,
            _AirPlaneSpeed * Time.deltaTime);
        // Vector2.MoveTowards(current, target, maxDistanceDelta)
        // current ��ġ���� target�� ��ġ�� 1�����Ӹ��� maxDistanceDelta�� �ӵ��� �̵��� ��ġ�� ����
    }

    // ��ǥ ��ġ ������Ʈ
    private void UpdateTargetPosition()
    {
        // 0.5�ʸ��� �÷��̾� ��ġ�� �޾ƿ�
        if(Time.time - _PlayerLocationUpdateCheckTime >= 0.5f)
        {
            _PlayerLocationUpdateCheckTime = Time.time;
            /// - Time.time : ������ ����� �ĺ��� ����� �ð��� �ʴ����� ��ȯ
            /// ����Ÿ�� : float
            _MoveTargetPosition = m_Player.transform.position;

            _MoveTargetPosition.y = transform.position.y;

            // ��ǥ ��ġ�� ���� ����� ��ġ���� �����ʿ� �ִٸ� �̹����� �ݴ�� ��������
            // ��ǥ ��ġ x�� ���� ����� ��ġ x���� ũ�� true
            m_SpriteRenderer.flipX = (_MoveTargetPosition.x > transform.position.x);

        }
    }

    // �̻��� �������� �޼���
    private void MissileDrop()
    {
        if (Time.time - _MissileDropCheckTime >= Random.Range(0.2f, 0.6f))
        {
            // - Random.Range(min, max) : min�� max ������ ���� ����
            _MissileDropCheckTime = Time.time;

            // �̻��� ����
            CreateMissile();
        }
    }

    private void CreateMissile()
    {
        // Missile_ori ���� ���� newMissile�� ����
        GameObject newMissile = Instantiate(m_MissileOri);
        /// Instantiate(original) : GameObject ������ original�� ���� �����ؼ�
        /// ������ ������Ʈ �ν��Ͻ��� ����

        // ������ ������Ʈ ��ġ�� ������� ��ġ�� ����
        newMissile.transform.position = transform.position;

        // �̻��� 3���� ����
        Destroy(newMissile, 3.0f);
    }
}
