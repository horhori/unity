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

    // �̻����� ����߸� �� ���� �ð��� üũ�� ����
}
