using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // > �÷��̾ �̵��� �� ����� �ӵ�
    public float _MoveSpeed = 10.0f;
    /// public���� ������ ��� �ν�����(����Ƽ ����)�� ����

    // > ���� ���͸� ������ ����
    private Vector2 _DirectionVector = Vector2.zero;
    /// Vector2 : x,y ��ǥ
    /// Vector2.zero : (0.0 , 0.0)
    /// Vector3 : x,y,z ��ǥ

    // > ����, �������� �� ��ǥ
    private const float LeftPositionX = -6.3f;
    private const float RightPositionX = 6.3f;
    /// - �̵� ������ ��Ű�� ���ؼ� ���

    // ����Ƽ���� ������Ʈ ��ġ�� �����ϴ� 3���� ��� 
    /// - ������Ʈ�� ��ǥ�� Ư���� ��ǥ�� �̵�
    ///   transform.poition = Vector2
    /// - Ư���� �������� �̵�
    ///   transform.position += Vector2
    ///   tranform.Translate((x,y,z))
    /// - ���������� ���ؼ� Ư���� ����� ���� �־� �̵�
    ///   Rigidbody.velocity / AddForce()

    Vector2 tempPos = new Vector2(3.0f, 3.0f);

    private void Start()
    {
        /// - ������Ʈ�� ��ǥ�� Ư���� ��ǥ�� �̵�
        //transform.position = tempPos;
        /// - Ư���� �������� �̵�
        //transform.Translate(-1, 0, 0);
    }

    private void Update()
    {
        // Ű �Է�
        InputKey();

        // ������ ���� ������
        MovePlayerCharacter();
    }

    private void SetPosition()
    {
        // gameObject�� ����Ƽ ���� Player�� ����
        gameObject.transform.position = new Vector2(10.0f, 10.0f);
        /// - �ش� ������Ʈ�� �߰��� GameObject�� Transform ������Ʈ �Ӽ� ��
        ///   position �Ӽ��� ���� (10.0f, 10.0f)�� ����
        /// - gameObject : �ش�(�� ��ũ��Ʈ) ������Ʈ�� �߰��� GameObject�� ����
        ///   �б� ���� ������Ƽ
        /// - gameObject.transform : GameObject�� Transform Component�� ����
        ///   �б� ���� ������Ƽ
        /// - transform.position : Transform ������Ʈ�� position �Ӽ��� ���� ������Ƽ
        /// - Vector2(float x, float y) : 2���� ���� ���ο��� ��ġ, ũ�� ����
        ///   ��Ÿ���� ���ؼ� ���Ǵ� ����ü
    }

    private void MovePosition()
    {
        // > ���� ���� (MoveSpeed, 0.0f)��ŭ�� �̵�
        transform.Translate(new Vector2(_MoveSpeed, 0.0f) * Time.deltaTime, Space.World);

        /// - transform.Translate(translation, relativeTo)
        /// - relativeTo �������� translation��ŭ�� �̵�
        /// - translation : �̵���ų �Ÿ�
        /// - relativeTo : Space.Self   : ������ �ڱ� �ڽ����� ���� 
        ///                Space.World  : ������ ����� ����
        ///                

        // Time.deltaTime
        /// ���� Frame�� ���� Frame ������ �ɸ� �ð� ���ݿ� ���� �б� ���� ������Ƽ
        /// PC�� ����� �ٸ����� ���� ����� �ٸ��� �ʵ��� �ϱ� ���ؼ�
        /// 
        /// - 1�� PC : 1�ʿ� 60Frame | Time.deltaTime = 1frame �� 0.01666 : 16.66
        /// - 2�� PC : 1�ʿ� 30Frame | Time.deltaTime = 1frame �� 0.03333 : 33.33
        /// ĳ������ �ӵ� 10
        /// 
        /// - ���
        /// 1�� �� 1�� PC�� ĳ���Ͱ� �̵��� �Ÿ� : 10(�ӵ�) * 60 : 600
        /// 1�� �� 2�� PC�� ĳ���Ͱ� �̵��� �Ÿ� : 10(�ӵ�) * 30 : 300
        /// 
        /// Time.deltaTime�� �߰� ���� X ���
        /// 1�� �� 1�� PC�� ĳ���Ͱ� �̵��� �Ÿ� : 10(�ӵ�) * 60 : 600 * 16.66 = 9.996
        /// 1�� �� 2�� PC�� ĳ���Ͱ� �̵��� �Ÿ� : 10(�ӵ�) * 30 : 300 * 33.33 = 9.999
        /// 
        /// Time.deltaTime�� ������ ��ǻ�� ��翡 ���� �̵� ����� ���̳��Ƿ�
        /// �ִ��� ������ ����� ��� ���� deltaTime�� ���
        /// 
    }

    // Ű �Է¹޴� �޼���
    private void InputKey()
    {
        // ����Ƽ���� Ű �Է¹޴� ���
        /// - bool Input.GetKey(KeyCode key)  : ������ Ű�� �������� ��� True ����
        /// - bool Input.GetKeyDown(KeyCode key) : ������ Ű�� ���� �� �ѹ� True ����
        /// - bool Input.GetKeyUp(KeyCode key) : ������ Ű�� ���ȴٰ� �������� ��� �ѹ� True ����
        /// 
        /// - float Input.GetAxis(string name) : -1.0f ~ 1.0f������ ���� ����
        /// - float Input.GetAxisRaw(string name) : -1.0f, 0.0f, 1.0f�� ���� ����
        /// 
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            _DirectionVector = Vector2.zero;
        }
        // ���� Ű�� ���� ���
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            _DirectionVector = Vector2.left;
        }
        // ������ Ű�� ���� ���
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            _DirectionVector = Vector2.right;
        }
        // ���� Ű�� �Ѵ� �ȴ��� ���
        else
        {
            _DirectionVector = Vector2.zero;
        }

    }

    // ������ �������� �̵�
    private void MovePlayerCharacter()
    {
        // > _DirectionVector �������� _MoveSpeed �ӵ���ŭ �̵�
        transform.Translate(_DirectionVector * _MoveSpeed * Time.deltaTime, Space.World);

        // > �÷��̾��� x ��ġ�� �� ������ �Ѿ�� �ʵ���
        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x, LeftPositionX, RightPositionX),
            transform.position.y
            );

        /// - Mathf : �ﰢ, �α� �� ��Ÿ �Ϲ� ���� �Լ��� ���� ��� �� ���� �޼��� �����ϴ� ����ü
        /// - Mathf.Clamp(value, min, max) : value�� min�� max ���̷� ����
    }
}
