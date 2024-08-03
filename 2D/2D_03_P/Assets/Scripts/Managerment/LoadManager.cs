using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour, IManager
{
    public GameManager gameManager { get { return GameManager.gameManager; } }
    
    public enum SceneName { LoadingScene, VillageScene, DungeonScene}
    public SceneName nextScene { get; set; } = SceneName.VillageScene;

    public void LoadScene(SceneName nextScene)
    {
        this.nextScene= nextScene;

        SceneManager.LoadScene(SceneName.LoadingScene.ToString());
    }
}
