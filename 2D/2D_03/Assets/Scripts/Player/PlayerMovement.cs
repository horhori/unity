using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMovement
{
    // ĳ���� �̵� ���⿡ ���� ������Ƽ
    public Vector2 dirVector {  get; private set; } = Vector2.zero;

    // Rigidbody2D ������Ƽ
    public Rigidbody2D _rigid { get; private set; }

    // �̵� �ӵ�
    private float _MoveSpeed = 40.0f;

    // ���� ���� �Է� ���� ����
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
