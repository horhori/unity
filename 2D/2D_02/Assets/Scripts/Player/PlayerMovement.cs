using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // 최소, 최대값 저장하기 위한 구조체
    private struct MinMax
    {
        // 최소, 최대 값 선언
        float min, max;

        // 생성자 초기화
        public MinMax(float min, float max)
        {
            this.min = min;
            this.max = max;
        }

        // value를 min과 max 사이의 값으로 가둡니다.
        public float Clamp(float value)
        {
            if(min > value || max < value)
            {
                value = (min > value) ? min : max;
            }
            return value;
        }
    }

    // 키입력 저장 변수
    private float _InputHorizontal = 0.0f;
    private float _InputVertical = 0.0f;

    // 플레이어 캐릭터 이동 속도
    private float _MoveSpeed = 10.0f;

    // > 수직 수평 이동 가능 영역
    private MinMax _HoriMinMax;
    private MinMax _VertMinMax;

    private void Awake()
    {
        _HoriMinMax = new MinMax(-8.5f, 8.5f);
        _VertMinMax = new MinMax(-4.5f, 4.5f);
    }

    private void Update()
    {
        // 키 입력 처리
        InputKey();

        // 플레이어 이동
        PlayerMove();
    }

    private void InputKey()
    {
        // 수평 축 입력
        _InputHorizontal = Input.GetAxis("Horizontal");
        // 수직 축 입력
        _InputVertical = Input.GetAxis("Vertical");
    }

    // 플레이어 이동 제어
    private void PlayerMove()
    {
        // 플레이어 이동 범위를 한정
        // 내부(local) 함수
        void LimitPlayerMove()
        {
            // > 한정된 플레이어 위치를 저장할 변수
            Vector2 playerPosition;

            // > 위치 한정
            playerPosition.x = _HoriMinMax.Clamp(transform.position.x);
            playerPosition.y = _VertMinMax.Clamp(transform.position.y);

            // 한정된 위치로 플레이어 위치를 저장
            transform.position = playerPosition;
        }

        // 수평 제어
        transform.Translate(Vector2.right * _InputHorizontal * _MoveSpeed * Time.deltaTime, Space.World);

        // 수직 제어
        transform.Translate(Vector2.up * _InputVertical * _MoveSpeed * Time.deltaTime, Space.World);

        // 이동 범위 제어
        LimitPlayerMove();
    }
}
