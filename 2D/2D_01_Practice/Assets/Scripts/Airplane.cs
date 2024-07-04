using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airplane : MonoBehaviour
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
        transform.po
    }
}
