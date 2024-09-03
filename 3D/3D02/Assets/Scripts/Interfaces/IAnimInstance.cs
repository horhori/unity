using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAnimInstance
{
    // �ܺ� �ִϸ����� ���� ���
    Animator animator { get; }

    // �ִϸ������� �Ķ���� ���� �޼��� ����
    bool SetBool(string paramName, bool value);
    float SetFloat(string paramName, float value);
    int SetInt(string paramName, int value);
    void SetTrigger(string paramName);
}
