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

    public void Start()
    {
        Initialize();
    }

    public void Update()
    {
        MissileMove();
    }

    public void Initialize()
    {
        _CurrentMoveSpeed = m_InitialMissileSpeed;
    }

    private void MissileMove()
    {
        transform.Translate(m_MoveDirection * _CurrentMoveSpeed * Time.deltaTime, Space.World);

        // 미사일 속도를 서서히 증가
        _CurrentMoveSpeed = Mathf.MoveTowards(_CurrentMoveSpeed, m_MissileMaxSpeed, 10 * Time.deltaTime);

        // 게임이 나갔는지 검사 -> 넘어갔다면 오브젝트 비활성화
        gameObject.SetActive(
            GameStatics.IsInScreen(transform, m_HorizontalLimit, m_VerticalLimit));


        // 화면 영역 검사
        // 게임 밖으로 나가면 알아서 삭제
        //if(!GameStatics.IsInScreen(transform, m_HorizontalLimit, m_VerticalLimit)) {
        //    Destroy(gameObject);
        //}
    }
}
