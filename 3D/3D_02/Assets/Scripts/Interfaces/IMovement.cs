using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovement
{
    // �̵� ���� ����
    Vector3 direction { get; }

    void Movement();


}