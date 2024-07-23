using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainButton : MonoBehaviour
{
    // Start ��ư ������ ��
    public void OnStartBtnClicked()
    {
        // ���Ӿ����� ��ȯ
        // SceneManager : ��Ÿ�� �� ���� �����ϴ� Ŭ����
        SceneManager.LoadScene("GameScene");
    }

    // Exit ��ư ������ ��
    public void OnExitBtnClicked()
    {
#if UNITY_EDITOR
        // > �������� �÷��� ���¸� ���� ���·� ����
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // > ���� �ÿ��� ������ ����
        Application.Quit();
#endif
    }

}
