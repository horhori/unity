using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovement
{
    // 이동 방향 프로퍼티
    Vector2 dirVector { get; }

    // 이동 로직
    void Movement();
}
