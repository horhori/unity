using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class PlayerInstance : MonoBehaviour, ICharacter
{
    // 플레이어 캐릭터 HP 정보 프로퍼티 
    public float hp { get; private set; } = 100.0f;

    private bool _Invincibility = false;

    // > 플레이어가 데미지를 입을 수 있는 상태인 구별하기 위한 변수
    private SpriteRenderer _Sprite = null;

    // 폭탄 컴포넌트를 참조할 변수


    private void Awake()
    {
        // 게임이 실행될 때 플레이어 이미지를 찾음
        _Sprite = transform.Find("PlayerImage").GetComponent<SpriteRenderer>();

        // > 플레이어 객체를 참조시킴
        GameManager.gameManager.playerInstance = this;
    }

    // 데미지
    public void Damage(float damage)
    {
        // 무적 상태가 아니라면 데미지를 줌
        if (!_Invincibility)
        {
            // hp 감소
            hp -= damage;

            // hp가 남았다면
            if (hp >= 0.0f)
            {
                // 코루틴 시작(
                StartCoroutine(StartInvincibilityState());
            }

            // 플레이어가 죽었다면
            else
            {
                // 폭발 애니메이션 재생

                gameObject.SetActive(false);
            }
        }
    }

    private IEnumerator StartInvincibilityState()
    {
        // 깜박거림을 제어하는 변수
        bool visible = true;

        // visible이 거짓일 경우 색상
        Color DisableColor = _Sprite.color,
            EnableColor = _Sprite.color;

        // 색상값에서 a = 투명도임
        DisableColor.a = 0.2f;

        // 무적 상태 전환
        _Invincibility = true;

        // 반복
        for (int i=0; i<10; i++)
        {
            visible = !visible;
            _Sprite.color = (visible) ? EnableColor : DisableColor;
            yield return new WaitForSeconds(0.1f);
        }

        _Invincibility = false;
    }
}
