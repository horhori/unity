using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    // > 플레이어가 이동할 때 적용될 속도
    public float _MoveSpeed = 10.0f;

    // > 방향 벡터를 저장할 변수
    private Vector2 _DirectionVector = Vector2.zero;

    // > 왼쪽, 오른쪽, 위쪽, 아래쪽의 끝 좌표
    private const float LeftPositionX = -8.87f;
    private const float RightPositionX = 8.87f;
    private const float UpPositionY = 4.5f;
    private const float DownPositionY = -4.5f;


    private void Update()
    {
        // 키 입력
        InputKey();

        // 지정된 방향 움직임
        MovePlayerCharacter();
    }

    // 대각선 입력 안됨
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
        // > _DirectionVector 방향으로 _MoveSpeed 속도만큼 이동
        transform.Translate(_DirectionVector * _MoveSpeed * Time.deltaTime, Space.World);

        // > 플레이어의 x 위치가 맵 끝으로 넘어가지 않도록
        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x, LeftPositionX, RightPositionX),
            transform.position.y
            );

        // y축 안됨
    }
}
