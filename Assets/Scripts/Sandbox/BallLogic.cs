using UnityEngine;

public class BallLogic : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            GameManager.score += 10;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("BottomBoundary"))
        {
            GameManager.GameOver();
        }
    }

    void Update()
    {
        if (transform.position.y < -9)
        {
            GameManager.GameOver();
        }
    }
}
