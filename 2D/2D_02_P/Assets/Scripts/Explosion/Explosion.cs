using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour, IRecyclableGameObject
{ 
    // 재사용 오브젝트 활성화 프로퍼티
    public bool isActive { get; set; } = true;

    private void OnExplosionAnimEnded()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        isActive = true;
    }
    private void OnDisable()
    {
        isActive = false;
    }
}
