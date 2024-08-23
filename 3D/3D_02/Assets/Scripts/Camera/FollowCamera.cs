using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    // ����ٴ� Ÿ�� ����
    [SerializeField] private Transform _FollowTargetTransform = null;

    // ���� �ӵ�
    [SerializeField][Range(0.0f, 10.0f)] private float _FollowSpeed = 5.0f;

    // ī�޶�
    public Camera camera {  get; private set; }

    private void Awake()
    {
        // ī�޶� �ε巴�� ���󰡰�
        IEnumerator FollowTarget()
        {
            while(true)
            {
                if(_FollowTargetTransform)
                {
                    transform.position = Vector3.Lerp(
                        transform.position, _FollowTargetTransform.position,
                        _FollowSpeed * Time.deltaTime);

                }

                yield return null;
            }
        }
        camera = GetComponentInChildren<Camera>();

        StartCoroutine(FollowTarget());
    }
}
