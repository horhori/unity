using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    // ���̺갡 �������� �˻��� ������Ƽ
    public bool waveClear { get; private set; } = false;

    // �ϳ��� ���̺꿡 �߰��� �� ������Ʈ�� ����ų ��� ����Ʈ
    private List<EnemyBase> _WaveEnemies = null;

    private void Awake()
    {
        InitializeWave();
    }

    private void InitializeWave()
    {
        _WaveEnemies = new List<EnemyBase>();

        // > ���� ������Ʈ �� EnemyBase ������Ʈ�� ��� ã��
        EnemyBase[] enemies = transform.GetComponentsInChildren<EnemyBase>();

        // ����Ʈ�� �߰�
        foreach(EnemyBase enemy in enemies)
        {
            _WaveEnemies.Add(enemy);

            // �θ� ������Ʈ ����
            enemy.transform.SetParent(null);
        }
    }

    public void WaveEnable()
    {
        // ���̺� Ŭ���� ��� �ڷ�ƾ
        IEnumerator WaveClearCheck()
        {
            yield return new WaitUntil(() =>
            _WaveEnemies.Find((EnemyBase enemy) => enemy.gameObject.activeSelf) == null);

            // > ���̺� Ŭ����
            waveClear = true;

            // �ش� ���̺꿡 �ִ� ��� ���� ����
            foreach (EnemyBase enemy in _WaveEnemies)
            {
                Destroy(enemy.gameObject);
            }
        }

        // ���̺� Ŭ���� ��� ����
        StartCoroutine(WaveClearCheck());
    }
}
