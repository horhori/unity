using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // > Character Controller ���� ����
    private CharacterController _Controller = null;

    // ĳ���� �̵��� ���� ���� ����
    private Vector3 _DirectionVector = Vector3.zero;

    // �̵� �ӵ�
    [Range(0.1f, 1000.0f)]
    public float m_MoveSpeed = 10.0f;

    // �÷��̾� ȸ���� ����
    private float _RotateYaw = 0.0f;
    private float _RotatePitch = 0.0f;

    // ī�޶� ������Ʈ�� �����ϴ� ����
    private GameObject _CameraObject = null;

    // �߰� �߷�
    private float _AddGravity = 15.0f;

    private void Awake()
    {
        _Controller = GetComponent<CharacterController>();
        _CameraObject = transform.Find("Camera").gameObject;

       
    }

    private void Update()
    {
        MoveControl();
    }

    private void MoveControl()
    {
        // ȸ�� ����

        // ���ӿ��� ��� ��ǥ
        // ����Ƽ : x, y, z
        // �𸮾� : x(Roll), y(Pitch), z(Yaw)

        void RotatePlayer()
        {
            _RotateYaw += Input.GetAxisRaw("Mouse X");
            _RotatePitch = Mathf.Clamp(_RotatePitch -= Input.GetAxisRaw("Mouse Y"), -60.0f, 60.0f);

            // �÷��̾� ������Ʈ ȸ�� ����
            transform.rotation = Quaternion.Euler(0.0f, _RotateYaw, 0.0f);

            // ī�޶� ȸ��
            // transform.rotation : ���� ���¿��� ���Ϸ��� ��ŭ ȸ��
            // Quaternion.Euler : ���� ���¿��� ���Ϸ� ������ ȸ��
            _CameraObject.transform.rotation = Quaternion.Euler(
                _RotatePitch, _CameraObject.transform.eulerAngles.y, 0.0f);
            // transform.eulerAugles : ���Ϸ� ��
        }

        RotatePlayer();

        if(_Controller.isGrounded)
        {
            _DirectionVector = ((transform.forward * Input.GetAxisRaw("Vertical")) +
          (transform.right * Input.GetAxisRaw("Horizontal")));

            _DirectionVector *= m_MoveSpeed;

           // ���� Ű
           if(Input.GetKey(KeyCode.Space))
            {
                _DirectionVector.y = 15.0f;
            }
        }


        _DirectionVector.y += (Physics.gravity.y - _AddGravity) * Time.deltaTime;

        _Controller.Move(_DirectionVector * Time.deltaTime);
    }
    
}
