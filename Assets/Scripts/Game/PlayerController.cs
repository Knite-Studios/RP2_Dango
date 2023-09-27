using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    private bool isUpsideDown = false;
    private Rigidbody2D rb;
    [SerializeField] CameraManager cameraManager;
    public TMP_Text livesText;
    private int lives = 3;

    private Vector3 initialPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
        UpdateLivesDisplay();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.S))
        {
            SwitchGravity();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            SwitchDimension();
        }
    }

    public void Move(float moveX)
    {
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);
    }

    public void SwitchGravity()
    {
        isUpsideDown = !isUpsideDown;
        rb.gravityScale = isUpsideDown ? -4 : 4;
        transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
    }

    public void SwitchDimension()
    {
        Debug.Log("Switching dimensions");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
        {
            LoseLife();
        }

    }
    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.CompareTag("CamBox"))
        {
            int camNum;
            camNum = int.Parse(col.gameObject.name);//get the number from the name of the object
            cameraManager.SwitchCam(camNum);
        }

    }
    private void LoseLife()
    {
        lives--;
        UpdateLivesDisplay();

        if (lives <= 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            transform.position = initialPosition;
            rb.velocity = Vector2.zero;
        }
    }

    private void UpdateLivesDisplay()
    {
        if (livesText)
        {
            livesText.text = "Lives: " + lives;
        }
    }
}
