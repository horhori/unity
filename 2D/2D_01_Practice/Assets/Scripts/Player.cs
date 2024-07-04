using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    // > �÷��̾ �̵��� �� ����� �ӵ�
    public float _MoveSpeed = 10.0f;

    // > ���� ���͸� ������ ����
    private Vector2 _DirectionVector = Vector2.zero;

    // > ����, ������, ����, �Ʒ����� �� ��ǥ
    private const float LeftPositionX = -8.87f;
    private const float RightPositionX = 8.87f;
    private const float UpPositionY = 4.5f;
    private const float DownPositionY = -4.5f;


    private void Update()
    {
        // Ű �Է�
        InputKey();

        // ������ ���� ������
        MovePlayerCharacter();
    }

    // �밢�� �Է� �ȵ�
    private void InputKey()
    {
        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.DownArrow))
        {
            _DirectionVector = Vector2.zero;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            _DirectionVector = Vector2.zero;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            _DirectionVector = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            _DirectionVector = Vector2.right;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            _DirectionVector = Vector2.up;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            _DirectionVector = Vector2.down;
        }
        else if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow))
        {
            Vector2 temp = new Vector2(-1f,1f);
            _DirectionVector = temp;
        }
        else if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow))
        {
            Vector2 temp = new Vector2(-1f, -1f);
            _DirectionVector = temp;
        }
        else if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            Vector2 temp = new Vector2(1f, 1f);
            _DirectionVector = temp;
        }
        else if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            Vector2 temp = new Vector2(1f, -1f);
            _DirectionVector = temp;
        }
        else
        {
            _DirectionVector = Vector2.zero;
        }
    }

    private void MovePlayerCharacter()
    {
        // > _DirectionVector �������� _MoveSpeed �ӵ���ŭ �̵�
        transform.Translate(_DirectionVector * _MoveSpeed * Time.deltaTime, Space.World);

        // > �÷��̾��� x ��ġ�� �� ������ �Ѿ�� �ʵ���
        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x, LeftPositionX, RightPositionX),
            transform.position.y
            );

        // y�� �ȵ�
    }
}
