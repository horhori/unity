using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // �÷��̾ ������ ����
    public GameObject m_Player;

    // �÷��̾ ���� �̵���ų ����
    private const float _EnemySpeed = 8.0f;

    // �÷��̾� ��ġ�� �޾ƿ� ������ ����
    private Vector2 _MoveTargetPosition = Vector2.zero;

    // �÷��̾� ��ġ�� �޾ƿ� �� ���� �ð��� üũ�� ����
    private float _PlayerLocationUpdateCheckTime = 0.0f;

    // Sprite Renderer�� ������ �� �ִ� ����
    public SpriteRenderer m_SpriteRenderer = null;

    // ���� ������ų �̻����� ���� ������Ʈ�� ������ ����
    public GameObject m_MissileOriginal = null;

    // �̻����� �� �� ���� �ð��� üũ�� ����
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

        FollowPlayerCharacterY();

        UpdateTargetPosition();

        MissileShoot();
    }

    private void FollowPlayerCharacterY()
    {
        // ������Ʈ�� ��ġ�� ��ǥ ��ġ�� �̵�
        transform.position = Vector2.MoveTowards(
            transform.position,
            _MoveTargetPosition,
            _EnemySpeed * Time.deltaTime);
    }

    // ��ǥ ��ġ ������Ʈ
    private void UpdateTargetPosition()
    {
        // 0.5�ʸ��� �÷��̾� ��ġ�� �޾ƿ�
        if(Time.time - _PlayerLocationUpdateCheckTime >= 0.5f)
        {
            _PlayerLocationUpdateCheckTime = Time.time;

            _MoveTargetPosition = m_Player.transform.position;

            _MoveTargetPosition.x = transform.position.x;
        }
    }

    // �̻��� �߻�
    private void MissileShoot()
    {
        if (Time.time - _MissileDropCheckTime >= Random.Range(0.2f, 0.6f))
        {
            _MissileDropCheckTime = Time.time;

            CreateMissile();
        }
    }

    private void CreateMissile()
    {
        GameObject newMissile = Instantiate(m_MissileOriginal);

        newMissile.transform.position = transform.position;

        Destroy(newMissile, 3.0f);
    }
}
