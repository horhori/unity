using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainButton : MonoBehaviour
{
    // Start 버튼 눌렀을 때
    public void OnStartBtnClicked()
    {
        // 게임씬으로 전환
        // SceneManager : 런타임 중 씬을 관리하는 클래스
        SceneManager.LoadScene("GameScene");
    }

    // Exit 버튼 눌렀을 때
    public void OnExitBtnClicked()
    {
#if UNITY_EDITOR
        // > 에디터의 플레이 상태를 종료 상태로 변경
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // > 빌드 시에는 게임을 종료
        Application.Quit();
#endif
    }

}
