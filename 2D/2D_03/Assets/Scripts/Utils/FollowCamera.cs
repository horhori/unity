using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class FollowCamera : MonoBehaviour
{
    // ī�޶� �߰��� �ݶ��̴� ������Ƽ
    public BoxCollider2D cameraCollider {  get; private set; }

    private CharacterManager _CharacterManager = null;

    // ī�޶� ���� �ӵ�
    private float _FollowSpeed = 4.0f;

    // ī�޶� ��ǥ ��ġ
    private Vector3 _CameraTargetPosition;

    // ī�޶��� �̵� ���� ������ ����
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

    // �÷��̾��� �� ������ ����Ǿ��� ���
    // ī�޶��� �̵� ���� ������ �ڵ����� ������ִ� �ڷ�ƾ

    private IEnumerator AutoCalculateCameraArea()
    {
        // ī�޶� �̵� ������ ������ ���
        void CalculateCameraArea()
        {
            // ī�޶��� ���� ũ�⸦ ������ ����
            // BoxCollider2D.Bounds : ��ü�� ��� ����
            // Bounds.center    : Collider2D�� �߽� ��ġ    
            // Bounds.extents   : Collider2D�� ����
            // Bounds.min & max : �ּ����� ������, �ִ����� ������
            // Bounds.size      : bounding box�� ũ��
            Vector3 cameraHalfSize = cameraCollider.bounds.extents;

            _CameraArea.SetMinMax(
                _CharacterManager.playerExistenceArea.area.bounds.min + cameraHalfSize,
                _CharacterManager.playerExistenceArea.area.bounds.max - cameraHalfSize);

            bool calculateXError = (_CameraArea.min.x > _CameraArea.max.x);
            bool calculateYError = (_CameraArea.min.y > _CameraArea.max.y);

            // min x, y ���� max x, y ������ ũ�ٸ� ������
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

    // ��ǥ��ġ�� ī�޶� �̵�
    private void FollowTarget()
    {
        // �÷��̾� ĳ���� �ν��Ͻ��� ���ٸ� �������� �ʽ��ϴ�.
        if (!_CharacterManager.playerCharacter) return;

        // ��ǥ ��ġ ������Ʈ
        void UpdateTargetPosition()
        {
            // �÷��̾� ĳ���� ��ġ
            _CameraTargetPosition = _CharacterManager.playerCharacter.transform.position;

            // ��ǥ ��ġ z���� ī�޶� z�� ����
            _CameraTargetPosition.z = transform.position.z;

            // ��ǥ ��ġ�� ī�޶� �̵� ���� ������ �ʰ����� �ʵ��� ���Ӵϴ�.
            _CameraTargetPosition.Set(
                // ��ǥ ��ġ�� x, y ���� ī�޶� �̵� ���� ������ ���Ӵϴ�.
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
