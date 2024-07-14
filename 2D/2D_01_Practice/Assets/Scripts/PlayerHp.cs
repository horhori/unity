using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHp : MonoBehaviour
{
    // > hp바를 가지고 있는 부모 오브젝트 transform을 참조할 변수
    public Transform HpBarParentTransform = null;

    // 플레이어의 체력
    [Range(0.0f, 100.0f)]
    public float m_Hp = 100.0f;

    // 플레이어의 체력에 따라 체력바 길이를 조절
    public void UpdateHpBar()
    {
        HpBarParentTransform.localScale = new Vector2(m_Hp / 100, 1.0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("EnemyMissile"))
        {
            // hp에서 10을 뺌
            m_Hp -= 10.0f;

            // 변경된 hp값을 hp바에 적용
            UpdateHpBar();

            Destroy(collision.gameObject);

            // hp가 0이하 되면 Destroy
            if (m_Hp <= 0.0f)
            {
                Destroy(gameObject);
            }
        }
    }
}
