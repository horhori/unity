using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSky : MonoBehaviour
{
    public Material m_SkyBox = null;

    [SerializeField] private float _RotateSpeed = 0.5f;

    private void Update()
    {
        m_SkyBox.SetFloat("_Rotation",
            m_SkyBox.GetFloat("_Rotation") + (Time.deltaTime *  _RotateSpeed));
    }
}
