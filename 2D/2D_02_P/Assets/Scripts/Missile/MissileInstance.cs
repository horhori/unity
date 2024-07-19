using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MissileMovement))]
public class MissileInstance : MonoBehaviour, IRecyclableGameObject
{
    // 해당 오브젝트가 활성화되어서 재사용 불가능한지 나타냅니다.
    public bool isActive { get; set; } = true;

    // > 해당 컴포넌트를 소유하는 오브젝트 MissileMovement 접근을 위한 프로퍼티
    public MissileMovement movement { get; private set; }

    private void Awake()
    {
        Initialize();
    }
    private void OnEnable()
    {
        isActive = true;
        movement.Initialize();
    }
    private void OnDisable()
    {
        isActive = false;
    }
    private void Initialize()
    {
        movement = GetComponent<MissileMovement>();
        
    }
   
    // 충돌처리 : 2D 오브젝트끼리 Trigger = 통과했을 때 실행시킵니다.
    // Trigger, Collision
    // Enter : 충돌 했을 때
    // Stay : 충돌 중
    // Exit : 충돌이 막 끝났을 때
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
            gameObject.SetActive(false);
    }
}
