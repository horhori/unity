using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMovement : MonoBehaviour
{
    [Tooltip("�̻��� �̵� �����Դϴ�.")]
    public Vector2 m_MoveDirection;

    [Tooltip("�̻��� �ʱ� �̵� �ӵ�")]
    public float m_InitialMissileSpeed;

    [Tooltip("�̻��� �ִ� �̵� �ӵ�")]
    public float m_MissileMaxSpeed;

    // > x, y ��ġ�� ȭ�� ���η� �����ų ������ ����
    public bool m_HorizontalLimit = false;
    public bool m_VerticalLimit = false;

    // > ���� �̵� �ӵ��� ������ ����
    private float _CurrentMoveSpeed;


    public void Initialize()
    {
        
    }
}
