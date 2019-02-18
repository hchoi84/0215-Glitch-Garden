using UnityEngine;

public class Trophy : MonoBehaviour
{
    [SerializeField] private GameObject trophyBase = default;
    private float trophyBasePosX;
    private float shakeSpeed = 100f;
    private float shakeAmount = .03f;
    private float shakeDuration = 0f;
    private float shakeStart = 0f;

    void Start()
    {
        trophyBasePosX = trophyBase.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        ShakeTrophyBase();
    }

    private void ShakeTrophyBase()
    {
        if (Time.time < (shakeStart + shakeDuration))
        {
            trophyBase.transform.position = new Vector2(
                trophyBasePosX + Mathf.Sin(Time.time * shakeSpeed) * shakeAmount,
                trophyBase.transform.position.y);
        }
        else
        {
            trophyBase.transform.position = new Vector2(trophyBasePosX, trophyBase.transform.position.y);
        }
    }

    // Called from Trophy Animation at time 0:22
    public void InitiateShakeTrophyBase()
    {
        shakeDuration = .1f;
        shakeStart = Time.time;
    }
}
