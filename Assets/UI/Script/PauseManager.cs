using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    private string pauseScene = "PauseScene";
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                UnloadPauseScene();
            }
            else
            {
                LoadPauseScene();
            }
        }
    }

    void LoadPauseScene()
    {
        SceneManager.LoadScene(pauseScene, LoadSceneMode.Additive);
        isPaused = true;
        Time.timeScale = 0f;
    }

    void UnloadPauseScene()
    {
        SceneManager.UnloadSceneAsync(pauseScene);
        isPaused = false;
        Time.timeScale = 1f;
    }
}
