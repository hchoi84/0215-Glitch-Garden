using UnityEngine;
using System.Collections;

public class AttackerSpawner : MonoBehaviour
{
    private bool spawn = true;
    private bool notifiedLevelController = false;
    private float spawnDurationMin = 2f, spawnDurationMax = 5f;
    private LevelController levelController;
    [SerializeField] private Attacker[] attackerArray = default;

    private void Start()
    {
        StartCoroutine(SpawnAttacker());
        spawn = true;
        levelController = FindObjectOfType<LevelController>();
    }

    private IEnumerator SpawnAttacker()
    {
        while (spawn)
        {
            float spawnDuration = Random.Range(spawnDurationMin, spawnDurationMax);
            int attackerIndex = Random.Range(0, attackerArray.Length);
            yield return new WaitForSeconds(spawnDuration);
            Attacker attacker = Instantiate(attackerArray[attackerIndex], transform.position, Quaternion.identity);
            attacker.transform.parent = this.gameObject.transform;
        }
    }

    private void Update()
    {
        if (!notifiedLevelController && !spawn && transform.childCount == 0)
        {
            levelController.FinishedSpawnerLane();
            notifiedLevelController = true;
        }
    }

    public void Spawn()
    {
        spawn = !spawn;
    }
}
