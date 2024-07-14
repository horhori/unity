using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    // > hp�ٸ� ������ �ִ� �θ� ������Ʈ transform�� ������ ����
    public Transform HpBarParentTransform = null;

    // ���� ü��
    [Range(0.0f, 500.0f)]
    public static float m_EnemyHp = 500.0f;

    public static float m_EnemyHalfHp = m_EnemyHp * 0.5f;

    // �÷��̾��� ü�¿� ���� ü�¹� ���̸� ����
    public void UpdateHpBar()
    {
        HpBarParentTransform.localScale = new Vector2(m_EnemyHp / 500, 1.0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Missile"))
        {
            // hp���� 10�� ��
            m_EnemyHp -= 10.0f;

            // ����� hp���� hp�ٿ� ����
            UpdateHpBar();

            Destroy(collision.gameObject);

            // hp�� 0���� �Ǹ� Destroy
            if (m_EnemyHp <= 0.0f)
            {
                Destroy(gameObject);
            }
        }
        if (collision.CompareTag("Bomb"))
        {
            m_EnemyHp -= 50.0f;

            // ����� hp���� hp�ٿ� ����
            UpdateHpBar();

            Destroy(collision.gameObject);


            // hp�� 0���� �Ǹ� Destroy
            if (m_EnemyHp <= 0.0f)
            {
                Destroy(gameObject);
            }
        }
    }
}
