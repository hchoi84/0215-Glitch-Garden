using UnityEngine;
using System.Collections;

public class AttackerSpawner : MonoBehaviour
{
    private bool spawn = true;
    private float spawnDurationMin = 2f, spawnDurationMax = 5f;
    [SerializeField] private GameObject lizardPrefab = default;

    private void Start()
    {
        StartCoroutine(SpawnAttacker());
    }

    private IEnumerator SpawnAttacker()
    {
        while (spawn)
        {
            float spawnDuration = Random.Range(spawnDurationMin, spawnDurationMax);
            yield return new WaitForSeconds(spawnDuration);
            GameObject attacker = Instantiate(lizardPrefab, transform.position, Quaternion.identity);
            attacker.transform.parent = this.gameObject.transform;
        }
    }


    private void Update()
    {
        
    }
}
