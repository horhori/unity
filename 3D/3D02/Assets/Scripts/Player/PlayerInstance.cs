using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement), typeof(CharacterController))]
public class PlayerInstance : MonoBehaviour, IHp
{
    // CharacterManager 참조 변수
    private CharacterManager _CharacterManager = null;

    // PlayerMovement에 대한 프로퍼티
    public PlayerMovement playerMovement { get; private set; }

    // CharacterController 프로퍼티
    public CharacterController controller { get; private set; }

    // PlayerAnimInstance 프로퍼티
    public PlayerAnimInstance animInstance { get; private set; }

    // PlayerAutoAttack 프로퍼티
    public PlayerAutoAttack playerAutoAttack { get; private set; }

    public float hp { get; set; } = 100.0f;

    public float maxHp { get; set; } = 100.0f;

    private void Awake()
    {
        _CharacterManager = GameManager.GetManagerClass<CharacterManager>();
        _CharacterManager.player = this;

        playerMovement = GetComponent<PlayerMovement>();
        controller = GetComponent<CharacterController>();
        animInstance = GetComponentInChildren<PlayerAnimInstance>();
        playerAutoAttack = GetComponent<PlayerAutoAttack>();
    }
}
