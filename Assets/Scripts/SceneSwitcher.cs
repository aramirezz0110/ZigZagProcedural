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
    public void LoadMainScene()
    {
        SceneManager.LoadScene(SceneNames.MainScene);
    }
}
