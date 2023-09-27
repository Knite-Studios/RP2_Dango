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

    private void Start()
    {
        UpdateUI();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            selectedIndex--;
            if (selectedIndex < 0)
                selectedIndex = 1; // Wrap around
            UpdateUI();
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            selectedIndex++;
            if (selectedIndex > 1)
                selectedIndex = 0; // Wrap around
            UpdateUI();
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            if (selectedIndex == 0)
            {
                PlayGame();
            }
            else
            {
                QuitGame();
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
