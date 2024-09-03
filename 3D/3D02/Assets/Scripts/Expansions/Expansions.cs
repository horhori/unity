using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameObjectExpansions
{
    // ���ӿ�����Ʈ�� ������ �������� ȸ��
    // normalizedDirection : ����ȭ�� ����
    public static void RotateTo(this GameObject gameObject, Vector3 normalizedDirection)
    {
        gameObject.transform.rotation = Quaternion.LookRotation(normalizedDirection);

    }
    // �ش� ������Ʈ���� ������ ��ǥ�� �ٶ󺼶��� ���� ����
    public static Vector3 GetDirectionVector(this GameObject gameObject, GameObject targetObject)
    {
        return (targetObject.transform.position - gameObject.transform.position).normalized;
    }

}
