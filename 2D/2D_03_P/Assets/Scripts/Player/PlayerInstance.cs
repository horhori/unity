using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstance : MonoBehaviour, ICharacter
{
    
    // 애니메이션을 제어할 컴포넌트에 대한 프로퍼티
    public IAnimInstance animInstance { get; private set; }

    // > 이동을 제어할 컴포넌트에 대한 프로퍼티
    public IMovement movement { get; private set; }

    // 캐릭터의 보는 방향에 대한 프로퍼티
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

        // 캐릭터 매니저에 캐릭터 인스턴스 등록
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
        // 이동이 없다면 방향 없데이트
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
        // 벡터의 길이 구해서 이동 / 대기 설정
        // sqrMagnitude : 두 점간의 거리를  제곱에 루트를 한 값
        if (Mathf.Approximately(dir.sqrMagnitude, 0.0f)) playerAction = PlayerAction.Idle;
        else playerAction = PlayerAction.Run;
    }

    private void TryInteraction()
    {
        Debug.Log("ㅊㅋ");
        _CharacManager.interactionableObject.Interaction();
    }
}
