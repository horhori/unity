using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    // ����ٴ� Ÿ�� ����
    [SerializeField] private Transform _FollowTargetTrasnform = null;

    // ���� �ӵ�
    [SerializeField][Range(0.0f, 10.0f)] private float _FollowSpeed = 5.0f;

    // ī�޶� ���� ������Ƽ
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
