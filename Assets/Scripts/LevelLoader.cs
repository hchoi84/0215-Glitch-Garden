using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private int buildIndex;
    private float splashToMenuDelay = 2f;

    private void Start()
    {
        buildIndex = SceneManager.GetActiveScene().buildIndex;
        if (buildIndex == 0)
        {
            StartCoroutine(SplashToMenuDelay());
        }
    }

    private IEnumerator SplashToMenuDelay()
    {
        yield return new WaitForSeconds(splashToMenuDelay);
        LoadNextScene();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadOptionMenue()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(buildIndex + 1);
    }

    public void LoadGameOverScene()
    {
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(buildIndex);
    }
}
