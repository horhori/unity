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
    /// - 프리팹을 참조할 변수
    public GameObject m_MissileOri = null;

    // 미사일을 떨어뜨릴 때 지난 시간을 체크할 변수
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

        FollowPlayerCharacterX();

        UpdateTargetPosition();

        MissileDrop();
    }

    // 플레이어의 위치를 따라가게
    private void FollowPlayerCharacterX()
    {
        // 오브젝트의 위치를 목표 위치로 이동
        transform.position = Vector2.MoveTowards(
            transform.position,
            _MoveTargetPosition,
            _AirPlaneSpeed * Time.deltaTime);
        // Vector2.MoveTowards(current, target, maxDistanceDelta)
        // current 위치에서 target의 위치로 1프레임마다 maxDistanceDelta의 속도로 이동한 위치를 리턴
    }

    // 목표 위치 업데이트
    private void UpdateTargetPosition()
    {
        // 0.5초마다 플레이어 위치를 받아옴
        if(Time.time - _PlayerLocationUpdateCheckTime >= 0.5f)
        {
            _PlayerLocationUpdateCheckTime = Time.time;
            /// - Time.time : 게임이 실행된 후부터 경과된 시간을 초단위로 반환
            /// 리턴타입 : float
            _MoveTargetPosition = m_Player.transform.position;

            _MoveTargetPosition.y = transform.position.y;

            // 목표 위치가 현재 비행기 위치보다 오른쪽에 있다면 이미지를 반대로 뒤집어줌
            // 목표 위치 x가 현재 비행기 위치 x보다 크면 true
            m_SpriteRenderer.flipX = (_MoveTargetPosition.x > transform.position.x);

        }
    }

    // 미사일 떨어지는 메서드
    private void MissileDrop()
    {
        if (Time.time - _MissileDropCheckTime >= Random.Range(0.2f, 0.6f))
        {
            // - Random.Range(min, max) : min과 max 사이의 난수 생성
            _MissileDropCheckTime = Time.time;

            // 미사일 생성
            CreateMissile();
        }
    }

    private void CreateMissile()
    {
        // Missile_ori 복사 생성 newMissile에 참조
        GameObject newMissile = Instantiate(m_MissileOri);
        /// Instantiate(original) : GameObject 형식의 original을 복사 생성해서
        /// 생성된 오브젝트 인스턴스를 리턴

        // 생성한 오브젝트 위치를 비행기의 위치로 서정
        newMissile.transform.position = transform.position;

        // 미사일 3초후 삭제
        Destroy(newMissile, 3.0f);
    }
}
