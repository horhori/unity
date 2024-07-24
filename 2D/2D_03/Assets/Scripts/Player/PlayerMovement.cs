using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMovement
{
    // 캐릭터 이동 방향에 대한 프로퍼티
    public Vector2 dirVector {  get; private set; } = Vector2.zero;

    // Rigidbody2D 프로퍼티
    public Rigidbody2D _rigid { get; private set; }

    // 이동 속도
    private float _MoveSpeed = 40.0f;

    // 수평 수직 입력 저장 변수
    private float _InputHorizontal = 0.0f;
    private float _InputVertical = 0.0f;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }
}
