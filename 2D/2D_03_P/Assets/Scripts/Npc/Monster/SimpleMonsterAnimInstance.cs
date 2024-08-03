using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(SpriteRenderer))]
public class SimpleMonsterAnimInstance : MonoBehaviour, IAnimInstance
{
    public Animator animator { get; private set; }

    private SpriteRenderer _SpriteRenderer = null;

    public float horizontalAxisValue { get; set; }

    public bool isMove { get; private set; }

    public string m_IdleAnimName;
    public string m_MoveAnimName;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        _SpriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void UpdateAnimationData(float horiAxis, bool move)
    {
        horizontalAxisValue = horiAxis;
        isMove = move;
    }

    private void Update()
    {
        FlipX();
        SimpleAnimControl();
    }

    private void FlipX()
    {
        if (Mathf.Approximately(horizontalAxisValue, 0.0f)) return;
        _SpriteRenderer.flipX = (horizontalAxisValue < 0.0f);
    }

    private void SimpleAnimControl()
    {
        if (isMove) animator.Play(m_MoveAnimName);
        else animator.Play(m_IdleAnimName);
    }
}
