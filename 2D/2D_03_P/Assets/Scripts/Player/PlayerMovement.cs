using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMovement
{
    // ĳ���� �̵� ���⿡ ���� ������Ƽ
    public Vector2 dirVector { get; private set; } = Vector2.zero;

    // Rigidbody2D ������Ƽ
    public Rigidbody2D _rigid { get; private set; }

    // �̵� �ӵ�
    private float _MoveSpeed = 30.0f;

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

    private void Update()
    {
        InputKey();
        (this as IMovement).Movement();
    }

    // Ű �Է� ó��
    private void InputKey()
    {
        dirVector = new Vector2(
            _InputHorizontal = (Mathf.Approximately(_InputVertical, 0.0f) ?
            Input.GetAxisRaw("Horizontal") : 0.0f),
            _InputVertical = (Mathf.Approximately(_InputHorizontal, 0.0f) ?
            Input.GetAxisRaw("Vertical") : 0.0f));
    }

    void IMovement.Movement()
    {
        _rigid.AddForce(dirVector * _MoveSpeed, ForceMode2D.Force);
    }
}
