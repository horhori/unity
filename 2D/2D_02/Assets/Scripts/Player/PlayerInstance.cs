using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class PlayerInstance : MonoBehaviour, ICharacter
{
    // �÷��̾� ĳ���� HP ���� ������Ƽ 
    public float hp { get; private set; } = 100.0f;

    private bool _Invincibility = false;

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

    // ������
    public void Damage(float damage)
    {
        // ���� ���°� �ƴ϶�� �������� ��
        if (!_Invincibility)
        {
            // hp ����
            hp -= damage;

            // hp�� ���Ҵٸ�
            if (hp >= 0.0f)
            {
                // �ڷ�ƾ ����(
                StartCoroutine(StartInvincibilityState());
            }

            // �÷��̾ �׾��ٸ�
            else
            {
                // ���� �ִϸ��̼� ���

                gameObject.SetActive(false);
            }
        }
    }

    private IEnumerator StartInvincibilityState()
    {
        // ���ڰŸ��� �����ϴ� ����
        bool visible = true;

        // visible�� ������ ��� ����
        Color DisableColor = _Sprite.color,
            EnableColor = _Sprite.color;

        // ���󰪿��� a = ������
        DisableColor.a = 0.2f;

        // ���� ���� ��ȯ
        _Invincibility = true;

        // �ݺ�
        for (int i=0; i<10; i++)
        {
            visible = !visible;
            _Sprite.color = (visible) ? EnableColor : DisableColor;
            yield return new WaitForSeconds(0.1f);
        }

        _Invincibility = false;
    }
}
