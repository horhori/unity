using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class FollowCamera : MonoBehaviour
{
    // 카메라에 추가된 콜라이더 프로퍼티
    public BoxCollider2D cameraCollider {  get; private set; }

    private CharacterManager _CharacterManager = null;

    // 카메라 추적 속도
    private float _FollowSpeed = 4.0f;

    // 카메라 목표 위치
    private Vector3 _CameraTargetPosition;

    // 카메라의 이동 가능 영역을 저장
    private Bounds _CameraArea;

    private void Awake()
    {
        cameraCollider = GetComponent<BoxCollider2D>();
        cameraCollider.isTrigger = true;

        _CharacterManager = GameManager.GetManagerClass<CharacterManager>();

        StartCoroutine(AutoCalculateCameraArea());
    }

    private void Update()
    {
        FollowTarget();
    }

    // 플레이어의 맵 영역이 변경되었을 경우
    // 카메라의 이동 가능 영역을 자동으로 계산해주는 코루틴

    private IEnumerator AutoCalculateCameraArea()
    {
        // 카메라가 이동 가능한 영역을 계산
        void CalculateCameraArea()
        {
            // 카메라의 절반 크기를 저장할 변수
            // BoxCollider2D.Bounds : 객체의 경계 영역
            // Bounds.center    : Collider2D의 중심 위치    
            // Bounds.extents   : Collider2D의 절반
            // Bounds.min & max : 최소지점 꼭지점, 최대지점 꼭지점
            // Bounds.size      : bounding box의 크기
            Vector3 cameraHalfSize = cameraCollider.bounds.extents;

            _CameraArea.SetMinMax(
                _CharacterManager.playerExistenceArea.area.bounds.min + cameraHalfSize,
                _CharacterManager.playerExistenceArea.area.bounds.max - cameraHalfSize);

            bool calculateXError = (_CameraArea.min.x > _CameraArea.max.x);
            bool calculateYError = (_CameraArea.min.y > _CameraArea.max.y);

            // min x, y 값이 max x, y 값보다 크다면 재조정
            if(calculateXError || calculateXError)
            {
                Vector2 fixedMin = new Vector2(
                    (calculateXError) ? _CharacterManager.playerExistenceArea.area.bounds.center.x :
                    _CameraArea.min.x,
                    (calculateYError) ? _CharacterManager.playerExistenceArea.area.bounds.center.y :
                    _CameraArea.min.y);

                Vector2 fixedMax = new Vector2(
                    (calculateXError) ? _CharacterManager.playerExistenceArea.area.bounds.center.x :
                    _CameraArea.max.x,
                    (calculateYError) ? _CharacterManager.playerExistenceArea.area.bounds.center.y :
                    _CameraArea.max.y);

                _CameraArea.SetMinMax(fixedMin, fixedMax);
            }
        }

        BoxCollider2D prevExistenceArea = null;

        while (true)
        {
            yield return new WaitWhile(() =>
                prevExistenceArea == _CharacterManager.playerExistenceArea?.area);
  

                CalculateCameraArea();
        }
    }

    // 목표위치로 카메라 이동
    private void FollowTarget()
    {
        // 플레이어 캐릭터 인스턴스가 없다면 실행하지 않습니다.
        if (!_CharacterManager.playerCharacter) return;

        // 목표 위치 업데이트
        void UpdateTargetPosition()
        {
            // 플레이어 캐릭터 위치
            _CameraTargetPosition = _CharacterManager.playerCharacter.transform.position;

            // 목표 위치 z값에 카메라 z값 설정
            _CameraTargetPosition.z = transform.position.z;

            // 목표 위치가 카메라 이동 가능 영역을 초과하지 않도록 가둡니다.
            _CameraTargetPosition.Set(
                // 목표 위치의 x, y 값을 카메라 이동 영역 안으로 가둡니다.
                Mathf.Clamp(_CameraTargetPosition.x, _CameraArea.min.x, _CameraArea.max.x),
                Mathf.Clamp(_CameraTargetPosition.y, _CameraArea.min.y, _CameraArea.max.y),
                _CameraTargetPosition.z);

        }

        
        UpdateTargetPosition();

        transform.position = Vector3.Lerp(
            transform.position, _CameraTargetPosition, _FollowSpeed * Time.deltaTime );

        //transform.position = Vector3.MoveTowards(
        //    transform.position, _CameraTargetPosition, _FollowSpeed * Time.deltaTime);
    }
}
