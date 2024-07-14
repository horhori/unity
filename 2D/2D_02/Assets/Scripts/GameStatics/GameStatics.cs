using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameStatics
{
    public static bool IsInScreen(Transform transform, bool checkHorizontal, bool checkVertical)
    {
        return IsInScreen(transform, checkHorizontal, checkVertical, (-8.5f, 8.5f), (-4.5f, 4.5f));
    }

    public static bool IsInScreen(Transform transform, bool checkHorizontal, bool checkVertical, (float left, float right) hori, (float bottom, float top) vert)
    {
            return ((checkHorizontal) ? // ����˻�
            transform.position.x >= hori.left && transform.position.x <= hori.right : true) && (
            (checkVertical) ? // �����˻�
            transform.position.y >= vert.bottom && transform.position.y <= vert.top : true);
    }

    // �ϳ��� ������ �ٸ� �������� ������ ����
    public static Vector2 GetDirectionVector(Vector2 position, Vector2 target)
    {
        return (target - position).normalized;
    }
}
