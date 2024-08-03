using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Ground : MonoBehaviour
{
    private CharacterManager _CharacterManager = null;

    public BoxCollider2D area { get; private set; }

    private void Awake()
    {
        _CharacterManager = GameManager.GetManagerClass<CharacterManager>();
        area = GetComponent<BoxCollider2D>();
        area.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�÷��̾�� ��ġ��
        if (collision.CompareTag("Player"))
            // �÷��̾ ���� �� ������ �ڱ��ڽ�(Ground)�� ����
            _CharacterManager.playerExistenceArea = this;
    }
}