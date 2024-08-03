using System;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class MonsterBase : MonoBehaviour, ICharacter, IMonster
{
    public float hp { get; private set; } = 100.0f;

    public Ground existenceArea { get; private set; }

    protected CharacterManager characterManager {  get; private set; }

    // �÷��̾� ���� ����
    private CircleCollider2D _DetectArea = null;

    // �÷��̾ ���������� ������ �� ȣ���� �޼��� �븮��
    protected Action<PlayerInstance> OnPlayerDetectedStart;

    protected Action<PlayerInstance> OnPlayerDetectedEnd;

    protected virtual void Awake()
    {
        characterManager = GameManager.GetManagerClass<CharacterManager>();

        _DetectArea = GetComponent<CircleCollider2D>();
        _DetectArea.isTrigger = true;

        existenceArea = GetComponentInParent<Ground>();
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            OnPlayerDetectedStart(characterManager.playerCharacter);
        }
    }
    protected virtual void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            OnPlayerDetectedEnd(characterManager.playerCharacter);
        }
    }
}
