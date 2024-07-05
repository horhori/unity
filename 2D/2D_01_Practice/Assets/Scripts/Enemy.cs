using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // 플레이어를 참조할 변수
    public GameObject m_Player;

    // 플레이어를 따라 이동시킬 변수
    private float _EnemySpeed = 8.0f;

    private const float _MaxEnemySpeed = 16.0f;


    // 플레이어 위치를 받아와 저장할 변수
    private Vector2 _MoveTargetPosition = Vector2.zero;

    // 플레이어 위치를 받아올 때 지난 시간을 체크할 변수
    private float _PlayerLocationUpdateCheckTime = 0.0f;

    // 복사 생성시킬 미사일의 원본 오브젝트를 참조할 변수
    public GameObject m_MissileOriginal = null;

    // 미사일을 쏠 때 지난 시간을 체크할 변수
    public float _MissileDropCheckTime = 0.0f;

    // 복사 생성시킬 유도 미사일의 원본 오브젝트를 참조할 변수
    public GameObject m_HomingMissileOriginal = null;

    // 유도 미사일을 쏠 때 지난 시간을 체크할 변수
    public float _HomingMissileDropCheckTime = 0.0f;

    // > 방향 벡터를 저장할 변수
    private Vector2 _DirectionVector = Vector2.up;

    private const float UpPositionY = 3.7f;
    private const float DownPositionY = -4.5f;

    private void Start()
    {
        // 초기위치 설정
        _MoveTargetPosition = transform.position;
    }

    private void Update()
    {
        // 플레이어가 존재하는 동안에만 하단 구문을 실행
        if (!m_Player) return;

        Debug.Log("EnemyHp : " + EnemyHp.m_EnemyHp );
        Debug.Log("EnemyHalfHp : " + EnemyHp.m_EnemyHalfHp );
        if (EnemyHp.m_EnemyHp > EnemyHp.m_EnemyHalfHp)
        {
            Debug.Log("Phase1 Start");
            Phase1();
        } else
        {
            Debug.Log("Phase2 Start");
            Phase2();
        }

        
    }

    private void Phase1()
    {
        FollowPlayerCharacterY();

        UpdateTargetPosition();

        MissilePhase1Shoot();
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
    private void MissilePhase1Shoot()
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



    private void Phase2()
    {
        MoveCharacterY();

        UpdateMovingSpeed();

        MissilePhase2Shoot();

    }

    private void MoveCharacterY()
    {
        // > _DirectionVector 방향으로 _MoveSpeed 속도만큼 이동
        transform.Translate(_DirectionVector * _EnemySpeed * Time.deltaTime, Space.World);

        // > 플레이어의 x 위치가 맵 끝으로 넘어가지 않도록
        //transform.position = new Vector2(
        //    transform.position.x,
        //    Mathf.Clamp(transform.position.y, DownPositionY, UpPositionY)
        //    );

        if (transform.position.y <= DownPositionY)
        {
            Debug.Log("Down");
            _DirectionVector = Vector2.up;
        } else if (transform.position.y >= UpPositionY)
        {
            Debug.Log("Up");

            _DirectionVector = Vector2.down;
        }

        // > 플레이어의 x 위치가 맵 끝으로 넘어가지 않도록
        transform.position = new Vector2(
            transform.position.x,
            Mathf.Clamp(transform.position.y, DownPositionY, UpPositionY)
            );
    }

    private void UpdateMovingSpeed()
    {
        _EnemySpeed = Mathf.MoveTowards(_EnemySpeed, _MaxEnemySpeed, 2f * Time.deltaTime);
    }

    private void MissilePhase2Shoot()
    {
        if (Time.time - _MissileDropCheckTime >= Random.Range(0.12f, 0.2f))
        {
            _MissileDropCheckTime = Time.time;

            CreateMissile();
        }
        //if (Time.time - _HomingMissileDropCheckTime >= Random.Range(0.4f, 0.5f))
        //{
        //    _HomingMissileDropCheckTime = Time.time;

        //    CreateHomingMissile();
        //}
    }
    
    //private void CreateHomingMissile()
    //{
    //    GameObject newMissile = Instantiate(m_HomingMissileOriginal);

    //    newMissile.transform.position = transform.position;

    //    Destroy(newMissile, 5.0f);
    //}
}
