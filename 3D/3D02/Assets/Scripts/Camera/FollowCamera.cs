using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    // 따라다닐 타겟 참조
    [SerializeField] private Transform _FollowTargetTrasnform = null;

    // 추적 속도
    [SerializeField][Range(0.0f, 10.0f)] private float _FollowSpeed = 5.0f;

    // 카메라에 대한 프로퍼티
    public Camera camera { get; private set; }

    private void Awake()
    {
        IEnumerator FollowTarget()
        {
            while(true)
            {
                if (_FollowTargetTrasnform)
                    transform.position = Vector3.Lerp(
                        transform.position, _FollowTargetTrasnform.position,
                        _FollowSpeed * Time.deltaTime);

                yield return null;
            }
        }
        camera = GetComponentInChildren<Camera>();

        StartCoroutine(FollowTarget());
    }
}
