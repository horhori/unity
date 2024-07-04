using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // 플레이어를 참조할 변수
    public GameObject m_Player;

    // 플레이어를 따라 이동시킬 변수
    private const float _EnemySpeed = 8.0f;

    // 플레이어 위치를 받아와 저장할 변수
    private Vector2 _MoveTargetPosition = Vector2.zero;

    // 플레이어 위치를 받아올 때 지난 시간을 체크할 변수
    private float _PlayerLocationUpdateCheckTime = 0.0f;

    // Sprite Renderer에 접근할 수 있는 변수
    public SpriteRenderer m_SpriteRenderer = null;

    // 복사 생성시킬 미사일의 원본 오브젝트를 참조할 변수
    public GameObject m_MissileOriginal = null;

    // 미사일을 쏠 때 지난 시간을 체크할 변수
    public float _MissileDropCheckTime = 0.0f;

    private void Start()
    {
        // 초기위치 설정
        _MoveTargetPosition = transform.position;
    }

    private void Update()
    {
        // 플레이어가 존재하는 동안에만 하단 구문을 실행
        if (!m_Player) return;

        FollowPlayerCharacterY();

        UpdateTargetPosition();

        MissileShoot();
    }

    private void FollowPlayerCharacterY()
    {
        // 오브젝트의 위치를 목표 위치로 이동
        transform.position = Vector2.MoveTowards(
            transform.position,
            _MoveTargetPosition,
            _EnemySpeed * Time.deltaTime);
    }

    // 목표 위치 업데이트
    private void UpdateTargetPosition()
    {
        // 0.5초마다 플레이어 위치를 받아옴
        if(Time.time - _PlayerLocationUpdateCheckTime >= 0.5f)
        {
            _PlayerLocationUpdateCheckTime = Time.time;

            _MoveTargetPosition = m_Player.transform.position;

            _MoveTargetPosition.x = transform.position.x;
        }
    }

    // 미사일 발사
    private void MissileShoot()
    {
        if (Time.time - _MissileDropCheckTime >= Random.Range(0.2f, 0.6f))
        {
            _MissileDropCheckTime = Time.time;

            CreateMissile();
        }
    }

    private void CreateMissile()
    {
        GameObject newMissile = Instantiate(m_MissileOriginal);

        newMissile.transform.position = transform.position;

        Destroy(newMissile, 3.0f);
    }
}
