using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHp : MonoBehaviour
{
    // > hp�ٸ� ������ �ִ� �θ� ������Ʈ transform�� ������ ����
    public Transform HpBarParentTransform = null;

    // �÷��̾��� ü��
    [Range(0.0f, 100.0f)]
    public float m_Hp = 100.0f;

    // �÷��̾��� ü�¿� ���� ü�¹� ���̸� ����
    public void UpdateHpBar()
    {
        HpBarParentTransform.localScale = new Vector2(m_Hp / 100, 1.0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("EnemyMissile"))
        {
            // hp���� 10�� ��
            m_Hp -= 10.0f;

            // ����� hp���� hp�ٿ� ����
            UpdateHpBar();

            Destroy(collision.gameObject);

            // hp�� 0���� �Ǹ� Destroy
            if (m_Hp <= 0.0f)
            {
                Destroy(gameObject);
            }
        }
    }
}
