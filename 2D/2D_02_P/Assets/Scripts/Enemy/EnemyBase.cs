using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
public abstract class EnemyBase : MonoBehaviour, ICharacter
{
    // 적 체력 프로퍼티
    public float hp { get; private set; } = 100.0f;

    // 폭발 애니메이션 풀
    private ExplosionPool _Explosion = null;
    protected virtual void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        // 자동으로 오브젝트 비활성화 시키는 코루틴
        IEnumerator AutoDestroy()
        {
            // 화면 밖에 나갈때 까지 대기
            yield return new WaitWhile(() =>
            GameStatics.IsInScreen(
                transform, true, true, (-8.5f, 8.5f), (-4.5f, 50.0f)));

            // 폭발 애니메이션
            Die();
        }

        _Explosion = GameObject.Find("ExplosionPool")?.GetComponent<ExplosionPool>();

        // 자동 비활성화 시작
        StartCoroutine(AutoDestroy());
    }

    // 폭발 애니메이션 메서드
    private void Die()
    {
        // 폭발 애니메이션 재생
        _Explosion.PlayExplosion(transform.position);
        // 적 비활성화
        gameObject.SetActive(false);
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        // 플레이어 미사일과 겹쳤을 때
        if(other.CompareTag("PlayerMissile"))
        {
            // 체력을 감소시킵니다.
            hp -= 30.0f;

            // 체력 남아 있지 않다면
            if(hp <= 0.0f) Die();
        }

        // 플레이어와 겹쳤다면
        if(other.CompareTag("Player"))
        {
            // 플레이어에게 대미지를 가합니다.
            GameManager.gameManager.playerInstance.Damage(30.0f);
        }
    }
}
