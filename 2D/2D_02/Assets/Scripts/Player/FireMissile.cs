using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMissile : MonoBehaviour
{
    // 복사 생성시킬 미사일 오브젝트 원본
    [SerializeField]
    private MissileInstance _MissileObjectOri = null;

    // 오브젝트 풀링에 사용될 객체를 참조할 변수
    private ObjectPool<MissileInstance> _MissilePool = null;

    // 미사일 발사를 검사하는 변수
    private bool _MissileLaunchable = false;

    // 미사일 발사 딜레이
    private float _MissileLaunchDelay = 0.07f;

    // 미사일 발사 위치를 지정할 때 사용할 열거형
    private enum MissileLaunchLoc { Left, Right };

    private MissileLaunchLoc _MissileLoc = MissileLaunchLoc.Left;

    // 미사일 발사 위치
    public Transform m_MissileLeftLoc, m_MissileRightLoc;

    private void Awake()
    {
        Initialize();
    }

    // 초기화
    private void Initialize()
    {
        // 오브젝트 풀 초기화
        _MissilePool = new ObjectPool<MissileInstance>();

        // 발사 코루틴
        StartCoroutine(MissileShotDelay());
    }

    private IEnumerator MissileShotDelay()
    {
        // 코루틴?
        // 진입점을 여러 개 가질 수 있는 함수
        // 동시에 처리할 때 시간 간격을 두고 어떠한 작업들을 통해서
        // 처리할 수 있도록 도와주는 함수 형식
        // 코루틴을 실행시키기 위해 StartCoroutine을 통해서 사용한다.

        // Update 이외에서 사용할 때 보통 사용함

        // yield return WaitUntil(Func<bool> predicate)
        /// - predicate가 True가 될 때까지 대기

        // yield return WaitWhile(Func<bool> predicate)
        /// - predicate가 False가 될 때까지 대기

        // yield return WaitForSeconds(float time)
        /// - time이 지날 때까지 대기(시간 속도의 영향을 받음)
        
        // yield return WaitForSecondsRealTime(float time)
        /// - time이 지날 때까지 대기(시간 속도의 영향을 안받음)

        // yield return WaitForFixedUpdate
        /// - FixedUpdate() 호출 후까지 대기
        

        // yield return WaitForEndOfFrame
        /// - Update(), FixedUpdate(), 화면 렌더링이 끝난 후까지 대기

        // yield return null or 0
        /// - Update() 후까지 대기

        // yield break
        /// - 실행중인 현재 코루틴을 종료
        
        while(true)
        {
            // > _MissileLaunchable이 false가 될 때까지 대기
            yield return new WaitWhile(() => _MissileLaunchable);

            // _MissileLaunchDelay(시간)만큼 대기
            yield return new WaitForSeconds(_MissileLaunchDelay);

            // _MissileLaunchable을 true 변경해서 미사일이 발사될 수 있도록
            _MissileLaunchable = true;
        }
    }

    private void Update()
    {
        InputKey();
    }

    private void InputKey()
    {
        // 스페이스바 눌렀고, 미사일도 발사 가능 상태
        if(Input.GetKey(KeyCode.Space) && _MissileLaunchable)
        {
            // 재사용이 가능한 오브젝트를 찾은 뒤
            // 만일 찾지 못했다면 새로운 미사일 오브젝트를 생성 후 오브젝트 풀 등록

            // _missilePool 널체크를 해서 널이면 생성
            MissileInstance missile = _MissilePool.GetRecyclableObject() ??
                _MissilePool.RegisterRecyclableObject(Instantiate(_MissileObjectOri));

            // 미사일을 활성화
            missile.gameObject.SetActive(true);

            // 미사일 위치 설정
            missile.transform.position = (_MissileLoc == MissileLaunchLoc.Left) ?
                m_MissileLeftLoc.position : m_MissileRightLoc.position;

            // 발사 위치 설정
            _MissileLoc = (_MissileLoc == MissileLaunchLoc.Left) ?
                MissileLaunchLoc.Right : MissileLaunchLoc.Left;

            _MissileLaunchable = false;
        }
    }
}
