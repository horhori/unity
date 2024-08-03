using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingProgress : MonoBehaviour
{
    private LoadManager _LoadManager= null;

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
        // ���α׷��� �̹��� ä�� ���¸� 0.0f�� ���� �մϴ�.
        _ProgressImage.fillAmount = 0.0f;

        // ���� ���� �񵿱������� �ε��ϴ� �ڷ�ƾ
        IEnumerator Load()
        {
            AsyncOperation op = SceneManager.LoadSceneAsync(_LoadManager.nextScene.ToString());
            /// - AsyncOperation : �񵿱������� �ڷ�ƾ�� �����ϴ� Ŭ����
            /// - �񵿱� �۾��� yield ����� ����� �� ������, isDone, progress�� ���ؼ�
            /// �۾��� ���� ���¸� Ȯ���� �� �ֽ��ϴ�.
            /// 

            op.allowSceneActivation = false;
            /// - �������� �Ϸ�Ǿ �ٷ� ��ȯ��Ű�� �ʽ��ϴ�.
            /// - progress�� ���� 0.9�� �ʰ����� �ʽ��ϴ�.
            
            while(_Progress < 0.9f)
            {
                _Progress = Mathf.Min(op.progress, _Progress + 0.1f);
                yield return new WaitForSecondsRealtime(Random.Range(0.1f, 0.3f));
            }

            _Progress = 1.0f;
            // ���α׷����� �̹����� �� ä���������� ���
            yield return new WaitUntil(() => Mathf.Approximately(_ProgressImage.fillAmount, 1.0f));

            // �ε��� ������ ��ȭ
            op.allowSceneActivation = true;
        }
        StartCoroutine(Load());
    }

    private void Update()
    {
        _ProgressImage.fillAmount = Mathf.MoveTowards(
            _ProgressImage.fillAmount, _Progress, 0.6f * Time.deltaTime );
    }
}
