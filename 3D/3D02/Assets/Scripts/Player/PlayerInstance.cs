using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement), typeof(CharacterController))]
public class PlayerInstance : MonoBehaviour, IHp
{
    // CharacterManager ���� ����
    private CharacterManager _CharacterManager = null;

    // PlayerMovement�� ���� ������Ƽ
    public PlayerMovement playerMovement { get; private set; }

    // CharacterController ������Ƽ
    public CharacterController controller { get; private set; }

    // PlayerAnimInstance ������Ƽ
    public PlayerAnimInstance animInstance { get; private set; }

    // PlayerAutoAttack ������Ƽ
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
