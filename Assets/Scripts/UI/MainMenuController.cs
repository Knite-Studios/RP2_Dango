using UnityEngine;
using TMPro;
using UnityEditor;

public class MainMenuController : MonoBehaviour
{
    public TMP_Text playText;
    public TMP_Text quitText;
    public Color highlightColor = Color.yellow;
    public Color normalColor = Color.white;
    private int selectedIndex = 0;

    AudioSource UISpeaker;
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
        playText.color = (selectedIndex == 0) ? highlightColor : normalColor;
        quitText.color = (selectedIndex == 1) ? highlightColor : normalColor;
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
