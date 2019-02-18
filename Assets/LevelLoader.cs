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

    public void LoadNextScene()
    {
        SceneManager.LoadScene(buildIndex + 1);
    }

    private IEnumerator SplashToMenuDelay()
    {
        yield return new WaitForSeconds(splashToMenuDelay);
        LoadNextScene();
    }
}
