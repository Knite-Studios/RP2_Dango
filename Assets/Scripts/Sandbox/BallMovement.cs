using UnityEngine;
public class BallMovement : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        LaunchBall();
    }
    void LaunchBall()
    {
        rb.velocity = new Vector2(Random.Range(-1, 1), 1).normalized * speed;
    }
}
