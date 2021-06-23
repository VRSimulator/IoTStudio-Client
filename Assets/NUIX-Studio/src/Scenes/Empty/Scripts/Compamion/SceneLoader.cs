using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private static SceneLoader sceneLoaderInstance;

    public static SceneLoader GetInstance()
    {
        if (sceneLoaderInstance == null)
            sceneLoaderInstance = new SceneLoader();
        return sceneLoaderInstance;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
