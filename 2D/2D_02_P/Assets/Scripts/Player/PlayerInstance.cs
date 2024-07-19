using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstance : MonoBehaviour, ICharacter
{
    // 플레이어 캐릭터 HP 정보 프로퍼티
    public float hp { get; private set; } = 100.0f;

    // > 플레이어가 데미지를 입을수 있는 상태인 구별하기 위한 변수
    private bool _Invincibilty = false;

    // 플레이어 캐릭터 이미지를 출력할 수 있는 SpriteRenderer 컴포넌트를 참조할 변수
    private SpriteRenderer _Sprite = null;

    // 폭탄 컴포넌트를 참조할 변수
    private ExplosionPool _Explosion = null;

    private void Awake()
    {
        _Sprite = transform.Find("PlayerImage").GetComponent<SpriteRenderer>();

        _Explosion = GameObject.Find("ExplosionPool")?.GetComponent<ExplosionPool>();
        // > 플레이어 객체를 참조시킵니다.
        GameManager.gameManager.playerInstance = this;
    }

    // 대미지
    public void Damage(float damage)
    {
        // 무적상태가 아니라면 대미지를 줍니다.
        if (!_Invincibilty)
        {
            // hp 감소
            hp -= damage;

            // hp가 남았다면
            if (hp >= 0.0f)
                // 코루틴 시작(무적상태)
                StartCoroutine(StartInvincibilityState());

            // 플레이어가 죽었다면
            else
            {
                // 폭발 애니메이션 재생
                _Explosion.PlayExplosion(transform.position);
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
            //       참일 경우 색상
            EnableColor = _Sprite.color;

        DisableColor.a = 0.2f;

        // 무적 상태 전환
        _Invincibilty = true;

        // 반복
        for (int i = 0; i < 10; i++)
        {
            visible = !visible;
            _Sprite.color = (visible) ? EnableColor : DisableColor;
            yield return new WaitForSeconds(0.1f);
        }

        _Invincibilty = false;
    }
}
