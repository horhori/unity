using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    // > hp�ٸ� ������ �ִ� �θ� ������Ʈ transform�� ������ ����
    public Transform HpBarParentTransform = null;

    // ���� ü��
    [Range(0.0f, 500.0f)]
    public float m_Hp = 500.0f;

    // �÷��̾��� ü�¿� ���� ü�¹� ���̸� ����
    public void UpdateHpBar()
    {
        HpBarParentTransform.localScale = new Vector2(m_Hp / 500, 1.0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Missile"))
        {
            // hp���� 10�� ��
            m_Hp -= 10.0f;

            // ����� hp���� hp�ٿ� ����
            UpdateHpBar();

            // hp�� 0���� �Ǹ� Destroy
            if (m_Hp <= 0.0f)
            {
                Destroy(gameObject);
            }
        }
    }
}
