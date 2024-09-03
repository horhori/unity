using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loading : MonoBehaviour
{
    // �ε��� �� ����
    public static string NextSceneName;

    // �ε� ���� �� ������
    private float _BeginDelay = 1.0f;

    // �ε� �Ŀ� �� ������
    private float _EndDelay = 1.0f;

    private void Start()
    {
        StartCoroutine(LoadNextScene());
    }
    // ���� ���� LoadingScene���� ��ȯ��Ű�� �ε��� ���� ���� ����
    public static void LoadScene(string nextScene)
    {
        // �ε��� ������ ����
        NextSceneName = nextScene;

        // �ε������� ��ȯ
        UnityEngine.SceneManagement.SceneManager.LoadScene("LoadingScene");
    }
    
    private IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(_BeginDelay);

        // asyncoperation : �񵿱�� �ε�
        AsyncOperation ao = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(NextSceneName);

        // > ���� ���� ��� �غ�Ǿ ��ȭ��Ű�� �ʵ��� �մϴ�.
        ao.allowSceneActivation = false;

        // �������� ��� �غ�ɶ����� ���
        yield return new WaitUntil(() => ao.progress >= 0.9f);

        yield return new WaitForSeconds(_EndDelay);

        ao.allowSceneActivation = true;
    }
}
