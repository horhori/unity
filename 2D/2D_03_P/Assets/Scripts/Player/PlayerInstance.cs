using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstance : MonoBehaviour, ICharacter
{
    
    // �ִϸ��̼��� ������ ������Ʈ�� ���� ������Ƽ
    public IAnimInstance animInstance { get; private set; }

    // > �̵��� ������ ������Ʈ�� ���� ������Ƽ
    public IMovement movement { get; private set; }

    // ĳ������ ���� ���⿡ ���� ������Ƽ
    public Direction lookDirection { get; private set; }

    public enum PlayerAction { Idle, Run }
    public PlayerAction playerAction { get; private set; } = PlayerAction.Idle;

    public Ground existenceArea { get; private set; }

    private CharacterManager _CharacManager = null;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        animInstance = GetComponentInChildren<IAnimInstance>();
        movement = GetComponent<IMovement>();
        _CharacManager = GameManager.GetManagerClass<CharacterManager>();

        // ĳ���� �Ŵ����� ĳ���� �ν��Ͻ� ���
        _CharacManager.playerCharacter = this;
    }

    private void Update()
    {
        UpdateLookDirection(movement.dirVector);

        UpdatePlayerAction(movement.dirVector);

        InputKey();
    }

    private void UpdateLookDirection(Vector2 dir)
    {
        // �̵��� ���ٸ� ���� ������Ʈ
        if(dir == Vector2.zero) return;

        else if(dir == Vector2.left)    lookDirection = Direction.Left;
        else if(dir == Vector2.right)   lookDirection = Direction.Right;
        else if(dir == Vector2.down)    lookDirection = Direction.Down;
        else if(dir == Vector2.up)      lookDirection = Direction.Up;
    }

    private void InputKey()
    {
        if(Input.GetKeyDown(KeyCode.F) &&
            _CharacManager.interactionableObject != null)
        {
            TryInteraction();
        }
    }

    private void UpdatePlayerAction(Vector2 dir)
    {
        // ������ ���� ���ؼ� �̵� / ��� ����
        // sqrMagnitude : �� ������ �Ÿ���  ������ ��Ʈ�� �� ��
        if (Mathf.Approximately(dir.sqrMagnitude, 0.0f)) playerAction = PlayerAction.Idle;
        else playerAction = PlayerAction.Run;
    }

    private void TryInteraction()
    {
        Debug.Log("����");
        _CharacManager.interactionableObject.Interaction();
    }
}
