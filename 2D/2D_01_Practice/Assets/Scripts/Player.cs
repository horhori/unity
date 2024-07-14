using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    // > 플레이어가 이동할 때 적용될 속도
    public float _MoveSpeed = 10.0f;

    // > 방향 벡터를 저장할 변수
    private Vector2 _DirectionVector = Vector2.zero;

    // > 왼쪽, 오른쪽, 위쪽, 아래쪽의 끝 좌표
    private const float LeftPositionX = -8.87f;
    private const float RightPositionX = 8.87f;
    private const float UpPositionY = 3.7f;
    private const float DownPositionY = -4.5f;

    // 복사 생성시킬 미사일의 원본 오브젝트를 참조할 변수
    public GameObject m_MissileOri = null;

    // 미사일을 쏠 때 지난 시간을 체크할 변수
    public float _MissileShootCheckTime = 0.0f;

    // 복사 생성시킬 폭탄의 원본 오브젝트를 참조할 변수
    public GameObject m_BombOri = null;

    public static int _BombCount = 3;


    private void Update()
    {
        // 키 입력
        InputKey();

        // 지정된 방향 움직임
        MovePlayerCharacter();
    }

    // 대각선 입력 안됨
    private void InputKey()
    {

            if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.DownArrow))
            {
                _DirectionVector = Vector2.zero;
            }
            if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow))
            {
                _DirectionVector = Vector2.zero;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                _DirectionVector = Vector2.left;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                _DirectionVector = Vector2.right;
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                _DirectionVector = Vector2.up;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                _DirectionVector = Vector2.down;
            }
            if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow))
            {
                Vector2 temp = new Vector2(-1f, 1f);
                _DirectionVector = temp;
            }
            if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow))
            {
                Vector2 temp = new Vector2(-1f, -1f);
                _DirectionVector = temp;
            }
            if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow))
            {
                Vector2 temp = new Vector2(1f, 1f);
                _DirectionVector = temp;
            }
            if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow))
            {
                Vector2 temp = new Vector2(1f, -1f);
                _DirectionVector = temp;
            }
            if (Input.GetKey(KeyCode.Space))
            {
                MissileShoot();
            }
            if (Input.GetKey(KeyCode.LeftControl))
            {
                BombShoot();
            }
            if (!Input.anyKey)
            {
                _DirectionVector = Vector2.zero;
            }
            // 스페이스 누르고 있을 때 방향키 안누르면 안멈춤
    }

    private void MovePlayerCharacter()
    {
        // > _DirectionVector 방향으로 _MoveSpeed 속도만큼 이동
        transform.Translate(_DirectionVector * _MoveSpeed * Time.deltaTime, Space.World);

        // > 플레이어의 x 위치가 맵 끝으로 넘어가지 않도록
        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x, LeftPositionX, RightPositionX),
            Mathf.Clamp(transform.position.y, DownPositionY, UpPositionY)
            );
    }

    // 미사일 발사
    private void MissileShoot()
    {
        if (Time.time - _MissileShootCheckTime >= Random.Range(0.2f, 0.6f))
        {
            _MissileShootCheckTime = Time.time;

            CreateMissile();
        }
    }

    private void CreateMissile()
    {
        GameObject newMissile = Instantiate(m_MissileOri);

        newMissile.transform.position = transform.position;

        Destroy(newMissile, 3.0f);
    }

    // 폭탄 발사
    private void BombShoot()
    {
        if (Time.time - _MissileShootCheckTime >= Random.Range(0.2f, 0.6f) && _BombCount > 0)
        {
            _BombCount--;
            _MissileShootCheckTime = Time.time;

            CreateBomb();
        }
    }

    private void CreateBomb()
    {
        GameObject newBomb = Instantiate(m_BombOri);

        newBomb.transform.position = transform.position;

        Destroy(newBomb, 5.0f);
    }
}
