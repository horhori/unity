using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimInstance : MonoBehaviour, IAnimInstance
{
    // �����ϴ� �ִϸ����Ϳ� ���� ������Ƽ
    public Animator animator { get; private set; }

    // �ֻ��� �θ� ������Ʈ�� �߰��� PlayerInstance ������Ʈ�� ���� ����
    private PlayerInstance _PlayerInstance = null;

    // �÷��̾��� ���� ������ ���ڿ��� ������ ����
    private string _AnimDirection = "";

    // �÷��̾��� �׼� ���� ���ڿ� ����
    private string _PlayerAction = "";

    private void Awake()
    {
        animator = GetComponent<Animator>();
        _PlayerInstance = GetComponentInParent<PlayerInstance>();
    }

    private void Update()
    {
        UpdateAnimData();
        AnimationControl();
    }

    // �ִϸ��̼� ����� �ʿ��� �����͸� �޾ƿ�
    private void UpdateAnimData()
    {
        _AnimDirection = _PlayerInstance.lookDirection.ToString();
        _PlayerAction = _PlayerInstance.playerAction.ToString();
    }

    private void AnimationControl()
    {
        animator.Play(_PlayerAction + _AnimDirection);
    }
}
