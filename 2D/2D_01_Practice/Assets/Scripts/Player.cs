using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    // > �÷��̾ �̵��� �� ����� �ӵ�
    public float _MoveSpeed = 10.0f;

    // > ���� ���͸� ������ ����
    private Vector2 _DirectionVector = Vector2.zero;

    // > ����, ������, ����, �Ʒ����� �� ��ǥ
    private const float LeftPositionX = -8.87f;
    private const float RightPositionX = 8.87f;
    private const float UpPositionY = 3.7f;
    private const float DownPositionY = -4.5f;

    // ���� ������ų �̻����� ���� ������Ʈ�� ������ ����
    public GameObject m_MissileOri = null;

    // �̻����� �� �� ���� �ð��� üũ�� ����
    public float _MissileShootCheckTime = 0.0f;

    // ���� ������ų ��ź�� ���� ������Ʈ�� ������ ����
    public GameObject m_BombOri = null;

    public static int _BombCount = 3;


    private void Update()
    {
        // Ű �Է�
        InputKey();

        // ������ ���� ������
        MovePlayerCharacter();
    }

    // �밢�� �Է� �ȵ�
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
            // �����̽� ������ ���� �� ����Ű �ȴ����� �ȸ���
    }

    private void MovePlayerCharacter()
    {
        // > _DirectionVector �������� _MoveSpeed �ӵ���ŭ �̵�
        transform.Translate(_DirectionVector * _MoveSpeed * Time.deltaTime, Space.World);

        // > �÷��̾��� x ��ġ�� �� ������ �Ѿ�� �ʵ���
        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x, LeftPositionX, RightPositionX),
            Mathf.Clamp(transform.position.y, DownPositionY, UpPositionY)
            );
    }

    // �̻��� �߻�
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

    // ��ź �߻�
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
