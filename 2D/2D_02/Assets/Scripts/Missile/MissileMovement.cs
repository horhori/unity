using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMovement : MonoBehaviour
{
    [Tooltip("미사일 이동 방향입니다.")]
    public Vector2 m_MoveDirection;

    [Tooltip("미사일 초기 이동 속도")]
    public float m_InitialMissileSpeed;

    [Tooltip("미사일 최대 이동 속도")]
    public float m_MissileMaxSpeed;

    // > x, y 위치를 화면 내부로 제약시킬 것인지 지정
    public bool m_HorizontalLimit = false;
    public bool m_VerticalLimit = false;

    // > 현재 이동 속도를 저장할 변수
    private float _CurrentMoveSpeed;


    public void Initialize()
    {
        
    }
}
