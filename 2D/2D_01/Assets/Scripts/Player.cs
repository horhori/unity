using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // > 플레이어가 이동할 때 적용될 속도
    public float _MoveSpeed = 10.0f;
    /// public으로 선언할 경우 인스펙터(유니티 엔진)에 노출

    // > 방향 벡터를 저장할 변수
    private Vector2 _DirectionVector = Vector2.zero;
    /// Vector2 : x,y 좌표
    /// Vector2.zero : (0.0 , 0.0)
    /// Vector3 : x,y,z 좌표

    // > 왼쪽, 오른쪽의 끝 좌표
    private const float LeftPositionX = -6.3f;
    private const float RightPositionX = 6.3f;
    /// - 이동 제약을 시키기 위해서 사용

    // 유니티에서 오브젝트 위치를 변경하는 3가지 방법 
    /// - 오브젝트의 좌표를 특정한 좌표로 이동
    ///   transform.poition = Vector2
    /// - 특정한 방향으로 이동
    ///   transform.position += Vector2
    ///   tranform.Translate((x,y,z))
    /// - 물리엔진을 통해서 특정한 방향과 힘을 주어 이동
    ///   Rigidbody.velocity / AddForce()

    Vector2 tempPos = new Vector2(3.0f, 3.0f);

    private void Start()
    {
        /// - 오브젝트의 좌표를 특정한 좌표로 이동
        //transform.position = tempPos;
        /// - 특정한 방향으로 이동
        //transform.Translate(-1, 0, 0);
    }

    private void Update()
    {
        // 키 입력
        InputKey();

        // 지정된 방향 움직임
        MovePlayerCharacter();
    }

    private void SetPosition()
    {
        // gameObject는 유니티 상의 Player를 뜻함
        gameObject.transform.position = new Vector2(10.0f, 10.0f);
        /// - 해당 컴포넌트가 추가된 GameObject의 Transform 컴포넌트 속성 중
        ///   position 속성의 값을 (10.0f, 10.0f)로 설정
        /// - gameObject : 해당(이 스크립트) 컴포넌트가 추가된 GameObject에 대한
        ///   읽기 전용 프로퍼티
        /// - gameObject.transform : GameObject의 Transform Component에 대한
        ///   읽기 전용 프로퍼티
        /// - transform.position : Transform 컴포넌트의 position 속성에 대한 프로퍼티
        /// - Vector2(float x, float y) : 2차원 공간 내부에서 위치, 크기 등을
        ///   나타내기 위해서 사용되는 구조체
    }

    private void MovePosition()
    {
        // > 월드 기준 (MoveSpeed, 0.0f)만큼씩 이동
        transform.Translate(new Vector2(_MoveSpeed, 0.0f) * Time.deltaTime, Space.World);

        /// - transform.Translate(translation, relativeTo)
        /// - relativeTo 기준으로 translation만큼씩 이동
        /// - translation : 이동시킬 거리
        /// - relativeTo : Space.Self   : 기준을 자기 자신으로 설정 
        ///                Space.World  : 기준을 월드로 설정
        ///                

        // Time.deltaTime
        /// 이전 Frame과 다음 Frame 까지의 걸린 시간 간격에 대한 읽기 전용 프로퍼티
        /// PC의 사양이 다르더라도 실행 결과가 다르지 않도록 하기 위해서
        /// 
        /// - 1번 PC : 1초에 60Frame | Time.deltaTime = 1frame 당 0.01666 : 16.66
        /// - 2번 PC : 1초에 30Frame | Time.deltaTime = 1frame 당 0.03333 : 33.33
        /// 캐릭터의 속도 10
        /// 
        /// - 결과
        /// 1초 뒤 1번 PC의 캐릭터가 이동한 거리 : 10(속도) * 60 : 600
        /// 1초 뒤 2번 PC의 캐릭터가 이동한 거리 : 10(속도) * 30 : 300
        /// 
        /// Time.deltaTime의 추가 연산 X 결과
        /// 1초 뒤 1번 PC의 캐릭터가 이동한 거리 : 10(속도) * 60 : 600 * 16.66 = 9.996
        /// 1초 뒤 2번 PC의 캐릭터가 이동한 거리 : 10(속도) * 30 : 300 * 33.33 = 9.999
        /// 
        /// Time.deltaTime이 없으면 컴퓨터 사양에 따라서 이동 결과가 차이나므로
        /// 최대한 일정한 결과를 얻기 위해 deltaTime을 사용
        /// 
    }

    // 키 입력받는 메서드
    private void InputKey()
    {
        // 유니티에서 키 입력받는 방법
        /// - bool Input.GetKey(KeyCode key)  : 지정된 키가 눌려있을 경우 True 리턴
        /// - bool Input.GetKeyDown(KeyCode key) : 지정된 키가 눌릴 때 한번 True 리턴
        /// - bool Input.GetKeyUp(KeyCode key) : 지정된 키가 눌렸다가 떼어졌을 경우 한번 True 리턴
        /// 
        /// - float Input.GetAxis(string name) : -1.0f ~ 1.0f까지의 값을 리턴
        /// - float Input.GetAxisRaw(string name) : -1.0f, 0.0f, 1.0f의 값을 리턴
        /// 
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            _DirectionVector = Vector2.zero;
        }
        // 왼쪽 키만 눌린 경우
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            _DirectionVector = Vector2.left;
        }
        // 오른쪽 키만 눌린 경우
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            _DirectionVector = Vector2.right;
        }
        // 양쪽 키가 둘다 안눌린 경우
        else
        {
            _DirectionVector = Vector2.zero;
        }

    }

    // 지정된 방향으로 이동
    private void MovePlayerCharacter()
    {
        // > _DirectionVector 방향으로 _MoveSpeed 속도만큼 이동
        transform.Translate(_DirectionVector * _MoveSpeed * Time.deltaTime, Space.World);

        // > 플레이어의 x 위치가 맵 끝으로 넘어가지 않도록
        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x, LeftPositionX, RightPositionX),
            transform.position.y
            );

        /// - Mathf : 삼각, 로그 및 기타 일반 수학 함수에 대한 상수 및 정적 메서드 제공하는 구조체
        /// - Mathf.Clamp(value, min, max) : value를 min과 max 사이로 설정
    }
}
