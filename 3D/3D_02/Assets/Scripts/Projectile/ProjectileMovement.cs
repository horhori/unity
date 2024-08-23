using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class ProjectileMovement : MonoBehaviour, IMovement
{
    // 초기 속도
    [SerializeField] private float _InitialSpeed = 500.0f;

    // 최대 속도
    [SerializeField] private float _MaxSpeed = 600.0f;

    // 방향
    public Vector3 direction { get; set; } = Vector3.zero;

    // 현재 속도
    public float currentSpeed { get; set; } = 0.0f;

    private void Awake()
    {
        currentSpeed = _InitialSpeed;
        direction = Vector3.forward;
    }

    private void Update()
    {
        (this as IMovement).Movement();
        if(!Mathf.Approximately(currentSpeed, _MaxSpeed))
        {
            currentSpeed = Mathf.Lerp(currentSpeed, _MaxSpeed, 0.2f * Time.deltaTime);
        }
    }

    void IMovement.Movement()
    {
        // Self로 해서 본인 앞으로 움직일 수 있도록 함
        transform.Translate(direction * currentSpeed * Time.deltaTime, Space.Self);
    }

    // 초기화
    public void Initialize()
    {
        Initialize(Quaternion.Euler(0, 0, 0));
    }

    public void Initialize(Quaternion rotation)
    {
        transform.rotation = rotation;
        currentSpeed = _InitialSpeed;
    }

    public void Initialize(Vector3 direction)
    {
        currentSpeed = _InitialSpeed;
        gameObject.RotateTo(direction);
    }
}
