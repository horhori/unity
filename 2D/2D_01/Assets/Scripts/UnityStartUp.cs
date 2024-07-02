using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class UnityStartUp : MonoBehaviour
{
    #region ����Ƽ �����ֱ�
    // �� ó�� ��������� �� �ѹ� ȣ��˴ϴ�.
    private void Awake()
    {
        // > Log�� ����մϴ�. (����Ƽ â����)
        Debug.Log("Awake!");
    }

    // ������Ʈ�� Ȱ��ȭ�� �Ǿ��� ��� �ѹ� ȣ��˴ϴ�.
    private void OnEnable()
    {
        Debug.Log("OnEnable");
    }

    // OnEnable ������ �ѹ� ȣ��˴ϴ�.
    private void Start()
    {
        Debug.Log("Start");
    }

    // > Edit -> ProjectSettings -> Time -> FixedTimeStamp �������� ȣ���
    // ��Ģ������ ȣ���� �� ����
    private void FixedUpdate()
    {
        Debug.Log("FixedUpdate");
    }

    // �� �����Ӹ��� ȣ��
    // - ȣ���� �ұ�Ģ��
    private void Update()
    {
        Debug.Log("Update");
    }

    // > FixedUpdate�� Update ���Ŀ� ȣ��˴ϴ�.
    private void LateUpdate()
    {
        Debug.Log("LateUpdate");
    }

    // > ������Ʈ�� ��Ȱ��ȭ�� �� ȣ��
    private void OnDisable()
    {
        Debug.Log("OnDisable");
    }

    // > ������Ʈ�� ������ �� ȣ���
    private void OnDestroy()
    {
        Debug.Log("OnDestroy");
    }
    #endregion

}
