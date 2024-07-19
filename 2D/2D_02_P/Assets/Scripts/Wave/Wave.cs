using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    // 웨이브가 끝났는지 검사할 프로퍼티
    public bool waveClear { get; private set; } = false;

    // 하나의 웨이브에 추가된 적 오브젝트를 가리킬 요소 리스트
    private List<EnemyBase> _WaveEnemies = null;

    private void Awake()
    {
        InitializeWave();
    }

    private void InitializeWave()
    {
        _WaveEnemies = new List<EnemyBase>();

        // > 하위 오브젝트 중 EnemyBase 컴포넌트를 모두 찾음
        EnemyBase[] enemies = transform.GetComponentsInChildren<EnemyBase>();

        // 리스트에 추가
        foreach(EnemyBase enemy in enemies)
        {
            _WaveEnemies.Add(enemy);

            // 부모 오브젝트 제거
            enemy.transform.SetParent(null);
        }
    }

    public void WaveEnable()
    {
        // 웨이브 클리어 대기 코루틴
        IEnumerator WaveClearCheck()
        {
            yield return new WaitUntil(() =>
            _WaveEnemies.Find((EnemyBase enemy) => enemy.gameObject.activeSelf) == null);

            // > 웨이브 클리어
            waveClear = true;

            // 해당 웨이브에 있는 모든 적을 제거
            foreach (EnemyBase enemy in _WaveEnemies)
            {
                Destroy(enemy.gameObject);
            }
        }

        // 웨이브 클리어 대기 시작
        StartCoroutine(WaveClearCheck());
    }
}
