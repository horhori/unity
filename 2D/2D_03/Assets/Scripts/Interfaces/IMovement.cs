using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovement
{
    // �̵� ���� ������Ƽ
    Vector2 dirVector { get; }

    // �̵� ����
    void Movement();
}
