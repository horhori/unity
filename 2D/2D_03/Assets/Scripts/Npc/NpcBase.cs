using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// NPC의 기본 동작을 수행하도록 하는 클래스

[RequireComponent(typeof(CircleCollider2D))]
public abstract class NpcBase : MonoBehaviour, ICharacter, IInteractionable
{
    public string interactionName { get; private set; }

    public CircleCollider2D interactionableArea { get; private set; }

    public Ground existenceArea { get; private set; }

    public CharacterManager characterManager { get; private set; }

    // 플레이어와 겹침이 시작될 때 호출할 메서드 대리자
    protected Action OnPlayerStartOverlappedEvent;

    // 플레이어와 겹침이 끝났을 때 호출할 메서드 대리자
    protected Action OnPlayerEndedOverlappedEvent;

    // npc 이름을 표시하는 캔버스
    private GameObject _NpcNameCanvas = null;

    // 상호작용 시 호출될 메서드
    public abstract void Interaction();

    protected virtual void Awake()
    {
        characterManager = GameManager.GetManagerClass<CharacterManager>();

        // 상호작용 가능하도록 할 영역을 나타내는 컴포넌트
        interactionableArea = GetComponent<CircleCollider2D>();

        // 겹침이 가능하도록 함
        interactionableArea.isTrigger = true;

        // NPC 이름을 표시하는 캔버스 오브젝트 찾음
        _NpcNameCanvas = transform.Find("NpcNameCanvas").gameObject;

        OnPlayerStartOverlappedEvent = () => { _NpcNameCanvas.SetActive(true); };
        OnPlayerEndedOverlappedEvent = () => { _NpcNameCanvas?.SetActive(false); };
    }

    protected virtual void Start()
    {
        // 처음에는 이름 표시 안할거라서
        _NpcNameCanvas.SetActive(false);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision) { 
        // 플레이어 겹쳤을 때
        if(collision.CompareTag("Player")) 
        {
            // 자기 자신과 상호작용 가능하도록 함
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
            // 현재 상호작용이 가능한 오브젝트가 자기 자신이라면
            if (characterManager.interactionableObject == this as IInteractionable)
            {
                // null로 설정해서 더이상 상호작용이 불가능하도록 함
                characterManager.interactionableObject = null;
            }

            OnPlayerEndedOverlappedEvent();
        }
    }
}
