using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _GameManagerInstance = null;

    public List<IManager> _ManagerClass = null;

    public static GameManager gameManager
    {
        get
        {
            // ���� �Ŵ����� ��ȿ���� �ʴٸ�
            if (!_GameManagerInstance)
            {
                // ���忡�� ã��
                _GameManagerInstance = GameObject.Find("GameManager").GetComponent<GameManager>();

                // GameManager �ʱ�ȭ
                _GameManagerInstance.InitializeGameManager();
            }

            return _GameManagerInstance;
        }
    }

    private void InitializeGameManager()
    {
        // ���� �Ŵ��� Ŭ���� ����Ʈ �ʱ�ȭ
        _ManagerClass = new List<IManager>();

        // ���� �Ŵ��� Ŭ���� ���
        RegisterManagerClass<CharacterManager>();

        // �ε�Ŵ��� �߰�

    }

    // �Ŵ��� ���
    private void RegisterManagerClass<T>() where T : IManager
    {
        _ManagerClass.Add(transform.GetComponentInChildren<T>());
    }

    // �Ŵ��� �ν��Ͻ� ������
    public static T GetManagerClass<T>() where T : class, IManager
    {
        return gameManager._ManagerClass.Find(
            (IManager managerClass) => managerClass.GetType() == typeof(T)) as T;
    }

    private void Awake()
    {
        if(_GameManagerInstance && _GameManagerInstance != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
}
