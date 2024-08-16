using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // > Character Controller 참조 변수
    private CharacterController _Controller = null;

    // 캐릭터 이동에 사용될 방향 벡터
    private Vector3 _DirectionVector = Vector3.zero;

    // 이동 속도
    [Range(0.1f, 1000.0f)]
    public float m_MoveSpeed = 10.0f;

    // 플레이어 회전값 저장
    private float _RotateYaw = 0.0f;
    private float _RotatePitch = 0.0f;

    // 카메라 오브젝트를 참조하는 변수
    private GameObject _CameraObject = null;

    // 추가 중력
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
        // 회전 제어

        // 게임엔진 용어 좌표
        // 유니티 : x, y, z
        // 언리얼 : x(Roll), y(Pitch), z(Yaw)

        void RotatePlayer()
        {
            _RotateYaw += Input.GetAxisRaw("Mouse X");
            _RotatePitch = Mathf.Clamp(_RotatePitch -= Input.GetAxisRaw("Mouse Y"), -60.0f, 60.0f);

            // 플레이어 오브젝트 회전 설정
            transform.rotation = Quaternion.Euler(0.0f, _RotateYaw, 0.0f);

            // 카메라 회전
            // transform.rotation : 현재 상태에서 오일러각 만큼 회전
            // Quaternion.Euler : 현재 상태에서 오일러 각으로 회전
            _CameraObject.transform.rotation = Quaternion.Euler(
                _RotatePitch, _CameraObject.transform.eulerAngles.y, 0.0f);
            // transform.eulerAugles : 오일러 각
        }

        RotatePlayer();

        if(_Controller.isGrounded)
        {
            _DirectionVector = ((transform.forward * Input.GetAxisRaw("Vertical")) +
          (transform.right * Input.GetAxisRaw("Horizontal")));

            _DirectionVector *= m_MoveSpeed;

           // 점프 키
           if(Input.GetKey(KeyCode.Space))
            {
                _DirectionVector.y = 15.0f;
            }
        }


        _DirectionVector.y += (Physics.gravity.y - _AddGravity) * Time.deltaTime;

        _Controller.Move(_DirectionVector * Time.deltaTime);
    }
    
}
