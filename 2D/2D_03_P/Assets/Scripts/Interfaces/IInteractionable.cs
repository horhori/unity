using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractionable
{
    // ��ȣ �ۿ� ������ ������Ʈ�� �̸�
    string interactionName { get; }

    // ��ȣ�ۿ� �� ȣ���� �޼���
    void Interaction();
}
