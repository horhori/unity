using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
public abstract class EnemyBase : MonoBehaviour, ICharacter
{
    // �� ü�� ������Ƽ
    public float hp { get; private set; } = 100.0f;

    // ���� �ִϸ��̼� Ǯ
    private ExplosionPool _Explosion = null;
    protected virtual void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        // �ڵ����� ������Ʈ ��Ȱ��ȭ ��Ű�� �ڷ�ƾ
        IEnumerator AutoDestroy()
        {
            // ȭ�� �ۿ� ������ ���� ���
            yield return new WaitWhile(() =>
            GameStatics.IsInScreen(
                transform, true, true, (-8.5f, 8.5f), (-4.5f, 50.0f)));

            // ���� �ִϸ��̼�
            Die();
        }

        _Explosion = GameObject.Find("ExplosionPool")?.GetComponent<ExplosionPool>();

        // �ڵ� ��Ȱ��ȭ ����
        StartCoroutine(AutoDestroy());
    }

    // ���� �ִϸ��̼� �޼���
    private void Die()
    {
        // ���� �ִϸ��̼� ���
        _Explosion.PlayExplosion(transform.position);
        // �� ��Ȱ��ȭ
        gameObject.SetActive(false);
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        // �÷��̾� �̻��ϰ� ������ ��
        if(other.CompareTag("PlayerMissile"))
        {
            // ü���� ���ҽ�ŵ�ϴ�.
            hp -= 30.0f;

            // ü�� ���� ���� �ʴٸ�
            if(hp <= 0.0f) Die();
        }

        // �÷��̾�� ���ƴٸ�
        if(other.CompareTag("Player"))
        {
            // �÷��̾�� ������� ���մϴ�.
            GameManager.gameManager.playerInstance.Damage(30.0f);
        }
    }
}
