using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : NpcBase
{
    [SerializeField] private LoadManager.SceneName _LoadScene = LoadManager.SceneName.VillageScene;

    public override void Interaction()
    {
        // ��ȣ�ۿ� �� ����� ���� ������ ��ȯ
        GameManager.GetManagerClass<LoadManager>().LoadScene(_LoadScene);
    }
}
