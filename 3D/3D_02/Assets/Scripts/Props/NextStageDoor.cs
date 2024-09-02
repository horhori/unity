using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextStageDoor : MonoBehaviour
{
    private MonsterManager _MonsterManager = null;
     
    private void Awake()
    {
        IEnumerator AutoDoorOpen()
        {
            yield return new WaitUntil(()=> _MonsterManager.stageMonsters != null);

            yield return new WaitUntil(() => _MonsterManager.stageMonsters.Count == 0);

            GameManager.gameManager.stageClear = true;
        }
        
        _MonsterManager = GameManager.GetManagerClass<MonsterManager>();
        StartCoroutine(AutoDoorOpen());
    }

    private void OnTriggerEnter(Collider other)
    {
        if(GameManager.gameManager.stageClear)
        {
            if(other.CompareTag("Player"))
            {
                Loading.LoadScene("Stage" + (++GameManager.gameManager.StageCount));
                GameManager.gameManager.stageClear = false;
            }
        }
    }
}
