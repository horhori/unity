using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSimpleAnim : MonoBehaviour, IAnimInstance
{
    public Animator animator {  get; private set; }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    bool IAnimInstance.SetBool(string paramName, bool value)
    {
        animator.SetBool(paramName, value);
        return value;
    }

    float IAnimInstance.SetFloat(string paramName, float value)
    {
        animator.SetFloat(paramName, value);
        return value;
    }

    int IAnimInstance.SetInt(string paramName, int value)
    {
        animator.SetInteger(paramName, value);
        return value;
    }

    void IAnimInstance.SetTrigger(string paramName)
    {
        animator.SetTrigger(paramName);
    }
}
