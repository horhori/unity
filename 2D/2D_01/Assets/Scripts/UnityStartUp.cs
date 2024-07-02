using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class UnityStartUp : MonoBehaviour
{
    #region 유니티 생명주기
    // 맨 처음 실행시켰을 때 한번 호출됩니다.
    private void Awake()
    {
        // > Log를 출력합니다. (유니티 창에서)
        Debug.Log("Awake!");
    }

    // 오브젝트가 활성화가 되었을 경우 한번 호출됩니다.
    private void OnEnable()
    {
        Debug.Log("OnEnable");
    }

    // OnEnable 다음에 한번 호출됩니다.
    private void Start()
    {
        Debug.Log("Start");
    }

    // > Edit -> ProjectSettings -> Time -> FixedTimeStamp 기준으로 호출됨
    // 규칙적으로 호출할 수 있음
    private void FixedUpdate()
    {
        Debug.Log("FixedUpdate");
    }

    // 매 프레임마다 호출
    // - 호출이 불규칙적
    private void Update()
    {
        Debug.Log("Update");
    }

    // > FixedUpdate와 Update 이후에 호출됩니다.
    private void LateUpdate()
    {
        Debug.Log("LateUpdate");
    }

    // > 오브젝트가 비활성화될 때 호출
    private void OnDisable()
    {
        Debug.Log("OnDisable");
    }

    // > 오브젝트가 삭제될 때 호출됨
    private void OnDestroy()
    {
        Debug.Log("OnDestroy");
    }
    #endregion

}
