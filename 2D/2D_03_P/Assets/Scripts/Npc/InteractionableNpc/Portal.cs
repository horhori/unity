using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : NpcBase
{
    [SerializeField] private LoadManager.SceneName _LoadScene =
        LoadManager.SceneName.VillageScene;

    public override void Interaction()
    {
        // 상호작용시 설쟁된 다음 씬으로 전환합니다.
        GameManager.GetManagerClass<LoadManager>().LoadScene(_LoadScene);
    }
}
