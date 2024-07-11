using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class PlayerInstance : MonoBehaviour, ICharacter
{
    // �÷��̾� ĳ���� HP ���� ������Ƽ 
    public float hp { get; private set; } = 100.0f;

    // > �÷��̾ �������� ���� �� �ִ� ������ �����ϱ� ���� ����
    private SpriteRenderer _Sprite = null;

    // ��ź ������Ʈ�� ������ ����


    private void Awake()
    {
        // ������ ����� �� �÷��̾� �̹����� ã��
        _Sprite = transform.Find("PlayerImage").GetComponent<SpriteRenderer>();

        // > �÷��̾� ��ü�� ������Ŵ
        GameManager.gameManager.playerInstance = this;
    }
}
