using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHp : MonoBehaviour
{
    // > hp바를가지고 있는 부모 오브젝트 transform을 참조할 변수
    public Transform HpBarParentTransform = null;

    // 플레이어의 체력
    [Range(0.0f, 100.0f)]
    public float m_Hp = 100.0f;

    // 플레이어의 체력에 따라 체력바 길이를 조절
    public void UpdateHpBar()
    {
        HpBarParentTransform.localScale = new Vector2(m_Hp / 100, 1.0f);
    }
}
