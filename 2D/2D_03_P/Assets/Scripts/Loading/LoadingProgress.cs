using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingProgress : MonoBehaviour
{
    private LoadManager _LoadManager= null;

    private Image _ProgressImage = null;

    // 로딩 상태를 저장할 변수
    private float _Progress = 0.0f;

    private void Awake()
    {
        _LoadManager = GameManager.GetManagerClass<LoadManager>();
        _ProgressImage = GetComponent<Image>();
    }

    private void Start()
    {
        // 프로그래스 이미지 채움 상태를 0.0f로 설정 합니다.
        _ProgressImage.fillAmount = 0.0f;

        // 다음 씬을 비동기적으로 로딩하는 코루틴
        IEnumerator Load()
        {
            AsyncOperation op = SceneManager.LoadSceneAsync(_LoadManager.nextScene.ToString());
            /// - AsyncOperation : 비동기적으로 코루틴을 수행하는 클래스
            /// - 비동기 작업중 yield 기능을 사용할 수 있으며, isDone, progress를 통해서
            /// 작업의 진행 상태를 확인할 수 있습니다.
            /// 

            op.allowSceneActivation = false;
            /// - 다음씬이 완료되어도 바로 전환시키지 않습니다.
            /// - progress의 값이 0.9를 초과하지 않습니다.
            
            while(_Progress < 0.9f)
            {
                _Progress = Mathf.Min(op.progress, _Progress + 0.1f);
                yield return new WaitForSecondsRealtime(Random.Range(0.1f, 0.3f));
            }

            _Progress = 1.0f;
            // 프로그래스바 이미지가 다 채워질때까지 대기
            yield return new WaitUntil(() => Mathf.Approximately(_ProgressImage.fillAmount, 1.0f));

            // 로드한 씬으로 전화
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
