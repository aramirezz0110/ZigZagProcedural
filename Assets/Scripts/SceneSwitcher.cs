using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneSwitcher : MonoBehaviour
{
    public static SceneSwitcher Instance;
    private void Awake()
    {
        Instance = this;
    }
    public void LoadGameScene()
    {
        SceneManager.LoadScene(SceneNames.GameScene);
    }
    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene(SceneNames.MainMenu);
    }
}
