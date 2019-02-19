using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("In seconds")] [SerializeField] private float levelTime = 10f;
    private Slider slider;
    private AttackerSpawner[] attackerSpawners;
    private bool done = false;

    private void Start()
    {
        attackerSpawners = FindObjectsOfType<AttackerSpawner>();
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        slider.value = Time.timeSinceLevelLoad / levelTime;
        bool timerFinished = slider.value >= 1;
        if (!done && timerFinished)
        {
            foreach (AttackerSpawner attackerSpawner in attackerSpawners)
            {
                attackerSpawner.Spawn();
                Debug.Log("Timer finished");
            }
            done = true;
        }
    }
}
