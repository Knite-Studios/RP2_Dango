using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject restartPrompt;

    public static int score = 0;

    void Update()
    {
        scoreText.text = "Score: " + score;

        if (GameObject.FindGameObjectsWithTag("Block").Length == 0)
        {
            WinGame();
        }

        if (!Time.timeScale.Equals(1) && Input.GetKeyDown(KeyCode.X))
        {
            RestartGame();
        }
    }

    public static void GameOver()
    {
        Time.timeScale = 0;
        instance.restartPrompt.SetActive(true);
    }

    void WinGame()
    {
        Time.timeScale = 0;
        restartPrompt.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public static GameManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
