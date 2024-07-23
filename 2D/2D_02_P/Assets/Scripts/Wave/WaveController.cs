using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    // ���̺� ����
    [SerializeField]
    private List<Wave> _Waves = null;

    // ���� ���̺�ī��Ʈ�� ����
    private int _CurrentWave = 1;

    private void Start()
    {
        StartCoroutine(RunWave());

    }

    private IEnumerator RunWave()
    {
        // ���� Ȱ��ȭ �� ���̺� ��ü�� ����ų ����
        Wave currentWave;

        // ����
        while(_Waves.Count > _CurrentWave - 1 &&
            GameManager.gameManager.playerInstance.gameObject.activeSelf)
        {
            // 1�� ���
            yield return new WaitForSecondsRealtime(1.0f);

            // > ���̺� ������Ʈ ����
            currentWave = Instantiate(_Waves[_CurrentWave - 1]);

            // ���̺� Ȱ��ȭ  
            currentWave.WaveEnable();

            // > �ش� ���̺갡 Ŭ����ɶ����� ���
            yield return new WaitUntil(() => currentWave.WaveClear);

            // ���̺� ī��Ʈ �߰�
            ++_CurrentWave;
        }

        // 1�� �� ���� ����
        yield return new WaitForSecondsRealtime(1.0f);

        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOverScene");
    }
        
}
