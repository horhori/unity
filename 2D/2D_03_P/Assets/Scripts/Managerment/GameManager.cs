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
            // 게임매니저 유효하지 않다면
            if(!_GameManagerInstance)
            {
                // 월드에서 찾습니다.
                _GameManagerInstance = GameObject.Find("GameManager").GetComponent<GameManager>();

                // GameManager 초기화
                _GameManagerInstance.InitializeGameManager();
            }

            return _GameManagerInstance;
        }
    }

    private void InitializeGameManager()
    {
        // 하위 매니저 클래스 리스츠 초기화
        _ManagerClass = new List<IManager>();

        // 하위 매니저 클래스 등록
        RegisterManagerClass<CharacterManager>();
        RegisterManagerClass<LoadManager>();
    }

    // 매니저 등록
    private void RegisterManagerClass<T>() where T : IManager
    {
        _ManagerClass.Add(transform.GetComponentInChildren<T>());
    }

    // 매니저 인스턴스 얻어오기
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
