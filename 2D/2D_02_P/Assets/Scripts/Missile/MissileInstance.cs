using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MissileMovement))]
public class MissileInstance : MonoBehaviour, IRecyclableGameObject
{
    // �ش� ������Ʈ�� Ȱ��ȭ�Ǿ ���� �Ұ������� ��Ÿ���ϴ�.
    public bool isActive { get; set; } = true;

    // > �ش� ������Ʈ�� �����ϴ� ������Ʈ MissileMovement ������ ���� ������Ƽ
    public MissileMovement movement { get; private set; }

    private void Awake()
    {
        Initialize();
    }
    private void OnEnable()
    {
        isActive = true;
        movement.Initialize();
    }
    private void OnDisable()
    {
        isActive = false;
    }
    private void Initialize()
    {
        movement = GetComponent<MissileMovement>();
        
    }
   
    // �浹ó�� : 2D ������Ʈ���� Trigger = ������� �� �����ŵ�ϴ�.
    // Trigger, Collision
    // Enter : �浹 ���� ��
    // Stay : �浹 ��
    // Exit : �浹�� �� ������ ��
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
            gameObject.SetActive(false);
    }
}
