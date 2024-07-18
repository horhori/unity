using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour, IRecyclableGameObject
{
    // ���� ������Ʈ Ȱ��ȭ ������Ƽ
    public bool isActive { get; set; } = true;

    private void OnExplosionAnimEnded()
    {
        gameObject.SetActive(false);
    }

    // ExplosionPool�� ���� ������ 
    private void OnEnable()
    {
        isActive = true;
    }

    private void OnDisable()
    {
        isActive = false;
    }
}
