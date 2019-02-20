using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour
{
    private int finishedSpawner = 0;
    private int attackerSpawners = default;
    [SerializeField] GameObject winCanvas = default;
    [SerializeField] GameObject loseCanvas = default;

    private void Start()
    {
        Time.timeScale = 1f;
        winCanvas.SetActive(false);
        loseCanvas.SetActive(false);
        attackerSpawners = FindObjectsOfType<AttackerSpawner>().Length;
    }

    private void Update()
    {
        if (finishedSpawner == attackerSpawners)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    private IEnumerator HandleWinCondition()
    {
        Time.timeScale = 0.5f;
        winCanvas.SetActive(true);
        yield return new WaitForSeconds(3f);
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }

    //Called from LivesDisplay
    public void HandleLoseCondition()
    {
        Time.timeScale = 0f;
        loseCanvas.SetActive(true);
    }

    //Called from AttackerSpawner
    public void FinishedSpawnerLane()
    {
        finishedSpawner++;
        Debug.Log(finishedSpawner);
    }
}
