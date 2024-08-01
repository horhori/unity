using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingProgress : MonoBehaviour
{
    private LoadManager _LoadManager = null;

    private Image _ProgressImage = null;

    // �ε� ���¸� ������ ����
    private float _Progress = 0.0f;

    private void Awake()
    {
        _LoadManager = GameManager.GetManagerClass<LoadManager>();
        _ProgressImage = GetComponent<Image>();
    }

    private void Start()
    {
        // Progress Image ä�� ���¸� 0.0f�� ����
        _ProgressImage.fillAmount = 0.0f;

        // ���� ���� �񵿱������� �ε��ϴ� �ڷ�ƾ
        IEnumerator Load()
        {
            AsyncOperation op = SceneManager.LoadSceneAsync(_LoadManager.nextScene.ToString());
            // AsyncOperation : �񵿱������� �ڷ�ƾ�� �����ϴ� Ŭ����
            // - �񵿱� �۾��� yield ����� ����� �� ������, isDone, progress�� ���ؼ�
            // �۾��� ���� ���¸� Ȯ���� �� ����

            op.allowSceneActivation = false;
            /// - ���� ���� �Ϸ�Ǿ �ٷ� ��ȯ��Ű�� ����
            /// - progress�� ���� 0.9�� �ʰ����� ����
            
            while (_Progress < 0.9f)
            {
                // �� �߿� �� ���� ��
                _Progress = -Mathf.Min(op.progress, _Progress + 0.1f);
                yield return new WaitForSecondsRealtime(Random.Range(0.1f, 0.3f));
            }

            _Progress = 1.0f;
            // Progress Image�� �� ä���� ������ ���
            yield return new WaitUntil(() => Mathf.Approximately(_ProgressImage.fillAmount, 1.0f));

            // �ε��� ������ ��ȯ
            op.allowSceneActivation = true;

        }

        StartCoroutine(Load());

    }

    private void Update()
    {
        _ProgressImage.fillAmount = Mathf.MoveTowards(_ProgressImage.fillAmount, _Progress, 0.6f * Time.deltaTime);
    }
}
