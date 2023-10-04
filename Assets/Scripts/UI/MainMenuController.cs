using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class MainMenuController : MonoBehaviour
{
    [Header("Play Button Sprites")]
    [SerializeField] private Image playButtonImage;
    [SerializeField] private Sprite idlePlaySprite;
    [SerializeField] private Sprite hoverPlaySprite;

    [Header("Quit Button Sprites")]
    [SerializeField] private Image quitButtonImage;
    [SerializeField] private Sprite idleQuitSprite;
    [SerializeField] private Sprite hoverQuitSprite;

    private int selectedIndex = 0;

    AudioSource UISpeaker;

    [Header("Audio")]
    [SerializeField]
    private AudioClip hoverClip;
    [SerializeField]
    private AudioClip pressedClip;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        UpdateUI();
        UISpeaker = GetComponent<AudioSource>();
        UISpeaker.clip = hoverClip;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            selectedIndex--;
            if (selectedIndex < 0)
                selectedIndex = 1; // Wrap around
            UISpeaker.Play();
            UpdateUI();
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            selectedIndex++;
            if (selectedIndex > 1)
                selectedIndex = 0; // Wrap around
            UISpeaker.Play();
            UpdateUI();
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            UISpeaker.clip = pressedClip;
            UISpeaker.Play();
           
            if (selectedIndex == 0)
            {
                Invoke("PlayGame", 1f);
            }
            else
            {
                Invoke("QuitGame", 1f);
            }
        }
    }

    private void UpdateUI()
    {
        playButtonImage.sprite = (selectedIndex == 0) ? hoverPlaySprite : idlePlaySprite;
        quitButtonImage.sprite = (selectedIndex == 1) ? hoverQuitSprite : idleQuitSprite;
    }

    private void PlayGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

    private void QuitGame()
    {
        Application.Quit();
        EditorApplication.isPlaying = false;
    }
}
