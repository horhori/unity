using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airplane : MonoBehaviour
{
    // 플레이어를 참조할 변수
    public GameObject m_Player;

    // 플레이어를 따라 이동시킬 변수
    private const float _AirPlaneSpeed = 8.0f;

    // 플레이어 위치를 받아와 저장할 변수
    /// - 비행기가 이 위치를 받아와서 계속 이동
    private Vector2 _MoveTargetPosition = Vector2.zero;

    // 플레이어 위치를 받아올 때 지난 시간을 체크할 변수
    private float _PlayerLocationUpdateCheckTime = 0.0f;

    // Sprite Renderer에 접근할 수 있는 변수
    public SpriteRenderer m_SpriteRenderer = null;

    // 복사 생성시킬 미사일의 원본 오브젝트를 참조할 변수

    // 미사일을 떨어뜨릴 때 지난 시간을 체크할 변수
}
