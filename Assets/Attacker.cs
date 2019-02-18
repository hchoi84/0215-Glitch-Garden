using UnityEngine;

public class Attacker : MonoBehaviour
{
    private float moveSpeed = 1f;

    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * moveSpeed);
    }

    // This method is called from Animation
    public void SetMovementSpeed(float speed)
    {
        moveSpeed = speed;
    }
}
