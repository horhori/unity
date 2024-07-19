using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstance : MonoBehaviour, ICharacter
{
    // �÷��̾� ĳ���� HP ���� ������Ƽ
    public float hp { get; private set; } = 100.0f;

    // > �÷��̾ �������� ������ �ִ� ������ �����ϱ� ���� ����
    private bool _Invincibilty = false;

    // �÷��̾� ĳ���� �̹����� ����� �� �ִ� SpriteRenderer ������Ʈ�� ������ ����
    private SpriteRenderer _Sprite = null;

    // ��ź ������Ʈ�� ������ ����
    private ExplosionPool _Explosion = null;

    private void Awake()
    {
        _Sprite = transform.Find("PlayerImage").GetComponent<SpriteRenderer>();

        _Explosion = GameObject.Find("ExplosionPool")?.GetComponent<ExplosionPool>();
        // > �÷��̾� ��ü�� ������ŵ�ϴ�.
        GameManager.gameManager.playerInstance = this;
    }

    // �����
    public void Damage(float damage)
    {
        // �������°� �ƴ϶�� ������� �ݴϴ�.
        if (!_Invincibilty)
        {
            // hp ����
            hp -= damage;

            // hp�� ���Ҵٸ�
            if (hp >= 0.0f)
                // �ڷ�ƾ ����(��������)
                StartCoroutine(StartInvincibilityState());

            // �÷��̾ �׾��ٸ�
            else
            {
                // ���� �ִϸ��̼� ���
                _Explosion.PlayExplosion(transform.position);
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
            //       ���� ��� ����
            EnableColor = _Sprite.color;

        DisableColor.a = 0.2f;

        // ���� ���� ��ȯ
        _Invincibilty = true;

        // �ݺ�
        for (int i = 0; i < 10; i++)
        {
            visible = !visible;
            _Sprite.color = (visible) ? EnableColor : DisableColor;
            yield return new WaitForSeconds(0.1f);
        }

        _Invincibilty = false;
    }
}
