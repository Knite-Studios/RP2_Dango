using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float jumpForce = 5.0f;

    private bool isRecording = false;
    private bool isUpsideDown = false;
    private bool isPlaying = false;
    private Rigidbody2D rb;
    private List<RecordedInput> recordedInputs = new List<RecordedInput>();
    private float recordStartTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isPlaying) return;

        float moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.S))
        {
            isUpsideDown = !isUpsideDown;
            rb.gravityScale = isUpsideDown ? -1 : 1;
            transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
        }

        if (isRecording)
        {
            recordedInputs.Add(new RecordedInput
            {
                timeStamp = Time.time - recordStartTime,
                movement = new Vector2(moveX, rb.velocity.y),
                jump = Input.GetKeyDown(KeyCode.S)
            });
        }
    }

    public void StartRecording()
    {
        if (isPlaying) return;

        isRecording = true;
        recordStartTime = Time.time;
        recordedInputs.Clear();
    }

    public void StopRecordingAndPlay()
    {
        isRecording = false;
        StartCoroutine(Playback());
    }

    private IEnumerator<WaitForSeconds> Playback()
    {
        isPlaying = true;

        float playbackStartTime = Time.time;
        foreach (var input in recordedInputs)
        {
            yield return new WaitForSeconds(input.timeStamp - (Time.time - playbackStartTime));
            
            rb.velocity = input.movement * moveSpeed;
            if (input.jump)
            {
                isUpsideDown = !isUpsideDown;
                rb.gravityScale = isUpsideDown ? -1 : 1;
                transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
            }
        }

        isPlaying = false;
    }

    public bool IsRecording
    {
        get { return isRecording; }
    }
}

[System.Serializable]
public class RecordedInput
{
    public float timeStamp;
    public Vector2 movement;
    public bool jump;
}
