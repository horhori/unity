using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    // 웨이브 저장
    [SerializeField]
    private List<Wave> _Waves = null;

    // 현재 웨이브카운트를 저장
    private int _CurrentWave = 1;

    private void Start()
    {
        StartCoroutine(RunWave());

    }

    private IEnumerator RunWave()
    {
        // 현재 활성화 된 웨이브 객체를 가리킬 변수
        Wave currentWave;

        // 조건
        while(_Waves.Count > _CurrentWave - 1 &&
            GameManager.gameManager.playerInstance.gameObject.activeSelf)
        {
            // 1초 대기
            yield return new WaitForSecondsRealtime(1.0f);

            // > 웨이브 오브젝트 생성
            currentWave = Instantiate(_Waves[_CurrentWave - 1]);

            // 웨이브 활성화  
            currentWave.WaveEnable();

            // > 해당 웨이브가 클리어될때까지 대기
            yield return new WaitUntil(() => currentWave.WaveClear);

            // 웨이브 카운트 추가
            ++_CurrentWave;
        }

        // 1초 뒤 게임 종료
        yield return new WaitForSecondsRealtime(1.0f);

        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOverScene");
    }
        
}
