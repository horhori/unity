using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : NpcBase
{
    [SerializeField] private LoadManager.SceneName _LoadScene = LoadManager.SceneName.VillageScene;

    public override void Interaction()
    {
        // 상호작용 시 실행된 다음 씬으로 전환
        GameManager.GetManagerClass<LoadManager>().LoadScene(_LoadScene);
    }
}
