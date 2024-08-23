using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimInstance : MonoBehaviour, IAnimInstance
{
    public Animator animator { get; private set; }

    private float _Speed = 0.0f;

    // ĳ���� �Ŵ��� ���� ����
    private CharacterManager _CharacterManager = null;

    private PlayerAutoAttack _PlayerAutoAttack = null;

    private void Awake()
    {
        _CharacterManager = GameManager.GetManagerClass<CharacterManager>();
        animator = transform.GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        _PlayerAutoAttack = _CharacterManager.player.playerAutoAttack;
    }

    private void Update()
    {
        _Speed = _CharacterManager.inputVector.magnitude;
        SetFloat("_Speed", _Speed);

    }

    // ���� �ִϸ��̼�
    public void PlayAttackAnimation()
    {
        SetTrigger("_Attack");
    }

    public void Attack()
    {
        _PlayerAutoAttack.Attack();
    }

    public void AttackEnd()
    {
        _PlayerAutoAttack.isAttacking = false;
    }

    #region Implemented IAnimInstance

    public bool SetBool(string paramName, bool value)
    {
        animator.SetBool(paramName, value);
        return value;
    }

    public float SetFloat(string paramName, float value)
    {
        animator.SetFloat(paramName, value);
        return value;
    }

    public int SetInt(string paramName, int value)
    {
        animator.SetInteger(paramName, value);
        return value;
    }

    public void SetTrigger(string paramName)
    {
        animator.SetTrigger(paramName);
    }

    #endregion
}
