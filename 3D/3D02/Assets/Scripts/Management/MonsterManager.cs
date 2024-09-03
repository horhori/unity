using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour, IManager
{
    public GameManager gameManager { get { return GameManager.gameManager; } }

    private List<MonsterInstance> _StageMonsters = new List<MonsterInstance>();

    public List<MonsterInstance> stageMonsters { get { return _StageMonsters; } }

    private void Awake()
    {
        // ����Ϳ� �÷��̾�� �Ÿ��� ����� ������� ����
        IEnumerator SortStageMonsters()
        {
            yield return new WaitUntil(()
                => GameManager.GetManagerClass<CharacterManager>().player);

            while(true)
            {
                // ����
                if(_StageMonsters != null)
                {
                    _StageMonsters.Sort((A, B) =>
                    {
                        float ADistance = Vector3.Distance(
                            A.transform.position, A.player.transform.position);
                        float BDistance = Vector3.Distance(
                            B.transform.position, B.player.transform.position);

                        if (ADistance < BDistance) return -1;
                        else if( ADistance > BDistance) return 1;
                        return 0;
                    });
                }
                yield return null;
            }
        }
        StartCoroutine(SortStageMonsters());
    }

    // _StageMonster�� ��� ��Ҹ� ���� �޼���
    public void ClearStageMonsters()
    {
        _StageMonsters.Clear();
    }
}
