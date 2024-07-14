using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// > GameManager?
// - 보통 [싱글톤] 패턴을 사용해서 게임이 실행되는 시점부터
// 게임이 끝나는 시점까지 존재해야 하며, 게임 전체에 사용되는 데이터를 관리하거나,
// 씬이 전환되어도 유지되어야 하는 데이터를 관리합니다.

// 레벨, 생명력, 돈, 스탯

// [싱글톤]
// = 하나의 인스턴스만 생성해서 사용하기 위한 디자인 패턴
// 프로그램이 시작될 때 딱 한번만 메모리에 할당하고, 그 인스턴스만 사용

public class GameManager : MonoBehaviour
{
    private static GameManager _GameManagerInstance = null;

    public static GameManager gameManager
    {
        get
        {
            return _GameManagerInstance ?? (_GameManagerInstance = GameObject.Find("GameManager").GetComponent<GameManager>());
        }
    }

    // 플레이어 캐릭터 인스턴스에 대한 프로퍼티
    public PlayerInstance playerInstance { get; set; } = null;

    private void Awake()
    {
        #region GameManager 중복 방지
        // 만약 _GameManagerInstance가 null이 아니라면
        if(_GameManagerInstance)
        {
            // 오브젝트를 제거합니다.
            Destroy(gameObject);
            return;
        }
        #endregion

        // 씬이 전환되어도 지정한 오브젝트를 삭제하지 않도록 유지합니다
        DontDestroyOnLoad(gameObject);
    }
}
