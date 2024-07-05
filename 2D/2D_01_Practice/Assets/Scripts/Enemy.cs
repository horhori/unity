using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // �÷��̾ ������ ����
    public GameObject m_Player;

    // �÷��̾ ���� �̵���ų ����
    private float _EnemySpeed = 8.0f;

    private const float _MaxEnemySpeed = 16.0f;


    // �÷��̾� ��ġ�� �޾ƿ� ������ ����
    private Vector2 _MoveTargetPosition = Vector2.zero;

    // �÷��̾� ��ġ�� �޾ƿ� �� ���� �ð��� üũ�� ����
    private float _PlayerLocationUpdateCheckTime = 0.0f;

    // ���� ������ų �̻����� ���� ������Ʈ�� ������ ����
    public GameObject m_MissileOriginal = null;

    // �̻����� �� �� ���� �ð��� üũ�� ����
    public float _MissileDropCheckTime = 0.0f;

    // ���� ������ų ���� �̻����� ���� ������Ʈ�� ������ ����
    public GameObject m_HomingMissileOriginal = null;

    // ���� �̻����� �� �� ���� �ð��� üũ�� ����
    public float _HomingMissileDropCheckTime = 0.0f;

    // > ���� ���͸� ������ ����
    private Vector2 _DirectionVector = Vector2.up;

    private const float UpPositionY = 3.7f;
    private const float DownPositionY = -4.5f;

    private void Start()
    {
        // �ʱ���ġ ����
        _MoveTargetPosition = transform.position;
    }

    private void Update()
    {
        // �÷��̾ �����ϴ� ���ȿ��� �ϴ� ������ ����
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
        // ������Ʈ�� ��ġ�� ��ǥ ��ġ�� �̵�
        transform.position = Vector2.MoveTowards(
            transform.position,
            _MoveTargetPosition,
            _EnemySpeed * Time.deltaTime);
    }

    // ��ǥ ��ġ ������Ʈ
    private void UpdateTargetPosition()
    {
        // 0.5�ʸ��� �÷��̾� ��ġ�� �޾ƿ�
        if(Time.time - _PlayerLocationUpdateCheckTime >= 0.5f)
        {
            _PlayerLocationUpdateCheckTime = Time.time;

            _MoveTargetPosition = m_Player.transform.position;

            _MoveTargetPosition.x = transform.position.x;
        }
    }

    // �̻��� �߻�
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
        // > _DirectionVector �������� _MoveSpeed �ӵ���ŭ �̵�
        transform.Translate(_DirectionVector * _EnemySpeed * Time.deltaTime, Space.World);

        // > �÷��̾��� x ��ġ�� �� ������ �Ѿ�� �ʵ���
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

        // > �÷��̾��� x ��ġ�� �� ������ �Ѿ�� �ʵ���
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
