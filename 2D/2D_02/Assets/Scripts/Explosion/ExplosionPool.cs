using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionPool : MonoBehaviour
{
    // 
    public Explosion m_ExplosionOri = null;
    private ObjectPool<Explosion> _ExplosionPool = null;

    // 
    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        _ExplosionPool = new ObjectPool<Explosion>();
    }

    // Æø¹ß ½ÇÇà
    public void PlayExplosion(Vector2 position)
    {
        Explosion explosion = _ExplosionPool.GetRecyclableObject() ??
            _ExplosionPool.RegisterRecyclableObject(Instantiate(m_ExplosionOri));
        explosion.gameObject.SetActive(true);
        explosion.transform.position = position;
    }
}
