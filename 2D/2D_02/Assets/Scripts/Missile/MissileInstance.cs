using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

// �̻��Ϲ����Ʈ ������Ʈ�� �ʿ��ϴٰ� �˷���
[RequireComponent(typeof(MissileMovement))]

public class MissileInstance : MonoBehaviour, IRecyclableGameObject
{
    // �ش� ������Ʈ�� Ȱ��ȭ�Ǿ ���� �Ұ������� ��Ÿ��
    public bool isActive { get; set; } = true;


    // > �ش� ������Ʈ�� �����ϴ� ������Ʈ MissileMovement ������ ���� ������Ƽ
    public MissileMovement movement { get; private set; }

    private void Awake()
    {
        Initialize();
    }
    
    // ���� ������ true
    private void OnEnable()
    {
        isActive = true;

        movement.Initialize();
    }

    // ���� ������ false
    private void OnDisable()
    {
        isActive = false;
    }

    private void Initialize()
    {
        // ������ ������Ʈ�� ã�Ƽ� ��������
        movement = GetComponent<MissileMovement>();
    }

    // �浹ó�� : 2D ������Ʈ���� Trigger = ������� �� �����Ŵ
    // Trigger, Collision
    // Enter : �浹���� ��
    // Stay : �浹 ��
    // Exit : �浹�� �� ������ ��
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("missile �浹");
        if(collision.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
        }
    }
}
