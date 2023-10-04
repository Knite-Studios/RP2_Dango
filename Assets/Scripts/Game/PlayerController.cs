using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveStep = 0.005f;
    private bool isUpsideDown = false;
    private Rigidbody2D rb;

    [Header("Dash Parameters")]
    public float dashSpeed = 75f;
    private float dashDuration = 0.2f; 
    private bool isDashing = false;

    [Header("Gravity Refinement Parameters")]
    public float reducedDrag = 0.5f; 
    public float normalDrag = 2.0f;  
    public float dragDuration = 0.5f;

    [SerializeField] CameraManager cameraManager;

    [Header("Life Images")]
    public List<GameObject> lifeImages = new List<GameObject>();
    private int lives = 3;
    public bool hasKey = false;


    private Vector3 initialPosition;
    Animator animator;

    [Header("Key UI Image")]
    [SerializeField] private Image keyUIImage;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
        animator = GetComponent<Animator>();

        if (keyUIImage)
        {
            keyUIImage.color = new Color(1f, 1f, 1f, 0.5f);
        }
    }

    void Update()
    {
        float moveX = 0;

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            moveX = -moveStep;
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            moveX = moveStep;
        }

        transform.position += new Vector3(moveX, 0, 0);

        if (Input.GetKeyDown(KeyCode.S))
        {
            SwitchGravity();
        }

        if (Input.GetKeyDown(KeyCode.X) && !isDashing)
        {
            StartCoroutine(Dash());
        }
    }

    void SwitchGravity()
    {
        isUpsideDown = !isUpsideDown;
        rb.gravityScale = isUpsideDown ? -4 : 4;
        transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
        rb.drag = reducedDrag; 
        StartCoroutine(ResetDrag()); 
        AudioManager.Instance.PlayJumpSound();
    }

    IEnumerator Dash()
    {
        isDashing = true;
        Vector2 originalVelocity = rb.velocity;
        rb.velocity = new Vector2((transform.localScale.x > 0 ? 1 : -1) * dashSpeed, rb.velocity.y);
        yield return new WaitForSeconds(dashDuration);
        rb.velocity = originalVelocity; 
        isDashing = false;
    }

    IEnumerator ResetDrag()
    {
        yield return new WaitForSeconds(dragDuration);
        rb.drag = normalDrag;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
        {
            LoseLife();
            AudioManager.Instance.PlayDeathSound();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("CamBox"))
        {
            Transform camNum;
            camNum = col.GetComponent<Transform>();
            cameraManager.SwitchCamera(camNum);
        }
        if (col.gameObject.CompareTag("Key"))
        {
            AudioManager.Instance.PlayCollectSound();

            if (keyUIImage)
            {
                keyUIImage.color = new Color(1f, 1f, 1f, 1f);
                Destroy(col.gameObject);
            }
            hasKey = true; 
        }
    }

    void LoseLife()
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

    void UpdateLivesDisplay()
    {
        if (lives > 0 && lives <= lifeImages.Count)
        {
            lifeImages[lives].SetActive(false);
        }
    }
}
