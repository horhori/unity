using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // �ּ�, �ִ밪 �����ϱ� ���� ����ü
    private struct MinMax
    {
        // �ּ�, �ִ� �� ����
        float min, max;

        // ������ �ʱ�ȭ
        public MinMax(float min, float max)
        {
            this.min = min;
            this.max = max;
        }

        // value�� min�� max ������ ������ ���Ӵϴ�.
        public float Clamp(float value)
        {
            if(min > value || max < value)
            {
                value = (min > value) ? min : max;
            }
            return value;
        }
    }

    // Ű�Է� ���� ����
    private float _InputHorizontal = 0.0f;
    private float _InputVertical = 0.0f;

    // �÷��̾� ĳ���� �̵� �ӵ�
    private float _MoveSpeed = 10.0f;

    // > ���� ���� �̵� ���� ����
    private MinMax _HoriMinMax;
    private MinMax _VertMinMax;

    private void Awake()
    {
        _HoriMinMax = new MinMax(-8.5f, 8.5f);
        _VertMinMax = new MinMax(-4.5f, 4.5f);
    }
}
