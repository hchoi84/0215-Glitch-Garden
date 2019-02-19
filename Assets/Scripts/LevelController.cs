using UnityEngine;

public class LevelController : MonoBehaviour
{
    private int finishedSpawner = 0;
    private int attackerSpawners = default;

    private void Start()
    {
        attackerSpawners = FindObjectsOfType<AttackerSpawner>().Length;
    }

    void Update()
    {
        if (finishedSpawner == attackerSpawners)
        {
            Debug.Log("End Level Now");
        }
    }

    public void FinishedSpawnerLane()
    {
        finishedSpawner++;
        Debug.Log(finishedSpawner);
    }
}
