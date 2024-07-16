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

        // �̻��� �ӵ��� ������ ����
        _CurrentMoveSpeed = Mathf.MoveTowards(_CurrentMoveSpeed, m_MissileMaxSpeed, 10 * Time.deltaTime);

        // ������ �������� �˻� -> �Ѿ�ٸ� ������Ʈ ��Ȱ��ȭ
        gameObject.SetActive(
            GameStatics.IsInScreen(transform, m_HorizontalLimit, m_VerticalLimit));


        // ȭ�� ���� �˻�
        // ���� ������ ������ �˾Ƽ� ����
        //if(!GameStatics.IsInScreen(transform, m_HorizontalLimit, m_VerticalLimit)) {
        //    Destroy(gameObject);
        //}
    }
}
