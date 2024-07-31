using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// NPC�� �⺻ ������ �����ϵ��� �ϴ� Ŭ����

[RequireComponent(typeof(CircleCollider2D))]
public abstract class NpcBase : MonoBehaviour, ICharacter, IInteractionable
{
    public string interactionName { get; private set; }

    public CircleCollider2D interactionableArea { get; private set; }

    public Ground existenceArea { get; private set; }

    public CharacterManager characterManager { get; private set; }

    // �÷��̾�� ��ħ�� ���۵� �� ȣ���� �޼��� �븮��
    protected Action OnPlayerStartOverlappedEvent;

    // �÷��̾�� ��ħ�� ������ �� ȣ���� �޼��� �븮��
    protected Action OnPlayerEndedOverlappedEvent;

    // npc �̸��� ǥ���ϴ� ĵ����
    private GameObject _NpcNameCanvas = null;

    // ��ȣ�ۿ� �� ȣ��� �޼���
    public abstract void Interaction();

    protected virtual void Awake()
    {
        characterManager = GameManager.GetManagerClass<CharacterManager>();

        // ��ȣ�ۿ� �����ϵ��� �� ������ ��Ÿ���� ������Ʈ
        interactionableArea = GetComponent<CircleCollider2D>();

        // ��ħ�� �����ϵ��� ��
        interactionableArea.isTrigger = true;

        // NPC �̸��� ǥ���ϴ� ĵ���� ������Ʈ ã��
        _NpcNameCanvas = transform.Find("NpcNameCanvas").gameObject;

        OnPlayerStartOverlappedEvent = () => { _NpcNameCanvas.SetActive(true); };
        OnPlayerEndedOverlappedEvent = () => { _NpcNameCanvas?.SetActive(false); };
    }

    protected virtual void Start()
    {
        // ó������ �̸� ǥ�� ���ҰŶ�
        _NpcNameCanvas.SetActive(false);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision) { 
        // �÷��̾� ������ ��
        if(collision.CompareTag("Player")) 
        {
            // �ڱ� �ڽŰ� ��ȣ�ۿ� �����ϵ��� ��
            characterManager.interactionableObject = this;

            OnPlayerStartOverlappedEvent();
        }
        else if (collision.CompareTag("Ground"))
        {
            existenceArea = collision.GetComponent<Ground>();
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            // ���� ��ȣ�ۿ��� ������ ������Ʈ�� �ڱ� �ڽ��̶��
            if (characterManager.interactionableObject == this as IInteractionable)
            {
                // null�� �����ؼ� ���̻� ��ȣ�ۿ��� �Ұ����ϵ��� ��
                characterManager.interactionableObject = null;
            }

            OnPlayerEndedOverlappedEvent();
        }
    }
}
