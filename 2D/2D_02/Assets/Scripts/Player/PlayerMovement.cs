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
}
