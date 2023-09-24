using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    public float speed = 5.0f;
    private float boundary = 9.6f;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * horizontalInput * speed * Time.deltaTime);
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -boundary, boundary), transform.position.y);
    }
}
