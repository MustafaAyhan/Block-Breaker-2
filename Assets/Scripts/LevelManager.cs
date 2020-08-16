using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    
    //public void LoadLevel(string name)
    //{
    //    Brick.brickableCount = 0;
    //    SceneManager.LoadScene(name);
    //}

    //public void QuitRequest()
    //{
    //    Application.Quit();
    //}

    //public void LoadNextLevel()
    //{
    //    Brick.brickableCount = 0;
    //    SceneManager.LoadScene(Application.loadedLevel + 1);
    //}

    //public void BrickDestroyed()
    //{
    //    if (Brick.brickableCount <= 0)
    //    {
    //        LoadNextLevel();
    //    }
    //}

    //  NOTE:   Be aware that loading scenes by SceneBuildIndex will require you 
    //          to have your scenes in a specific order, see this post for details;
    //          https://community.gamedev.tv/t/solved-application-loadlevel-obsolete/8200/2

    private int _activeSceneBuildIndex = 0;

    /// <summary>
    /// Initialisation
    /// </summary>
    void Start()
    {
        Initialise();
    }

    /// <summary>
    /// Initialises the SceneController
    /// </summary>
    private void Initialise()
    {
        Scene activeScene = SceneManager.GetActiveScene();

        _activeSceneBuildIndex = activeScene.buildIndex;
    }

    /// <summary>
    /// Loads a scene for the specified name
    /// </summary>
    /// <param name="name">The name of the scene to load</param>
    public void LoadSceneAsync(string sceneName)
    {
        // Debug.Log("New Scene load: " + sceneName);
        Brick.breakableCount = 0;
        SceneManager.LoadSceneAsync(sceneName);
    }

    /// <summary>
    /// Loads the next scene in order of build index
    /// </summary>
    public void LoadNextSceneAsync()
    {
        Brick.breakableCount = 0;
        SceneManager.LoadSceneAsync(++_activeSceneBuildIndex);
    }

    /// <summary>
    /// Checks to see if the final brick has been destroyed and loads the next scene if so
    /// </summary>
    public void BrickDestroyed()
    {
        if (Brick.breakableCount <= 0)
        {
            LoadNextSceneAsync();
        }
    }

    /// <summary>
    /// Handles a request to quit the game
    /// </summary>
    public void QuitRequest()
    {
        // Debug.Log("Quit requested");
        Application.Quit();
    }

}
