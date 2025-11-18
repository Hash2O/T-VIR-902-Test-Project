using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameManager : MonoBehaviour
{
    //public static GameManager Instance { get; private set; }

    //private void Awake()
    //{
    //    if (Instance != null)
    //    {
    //        Destroy(gameObject);
    //        return;
    //    }

    //    // this : the current instance of MainManager.
    //    Instance = this;
    //    DontDestroyOnLoad(gameObject);
    //}

    public void ReloadScene()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Calcule l’index de la scène suivante
        int nextSceneIndex = currentSceneIndex + 1;

        // Si on dépasse, on reboucle à 0
        if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }

        // Charge la scène correspondante
        SceneManager.LoadScene(nextSceneIndex);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();     //Original code to quit Unity player
#endif
    }
}
