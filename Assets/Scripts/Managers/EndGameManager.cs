using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    public static EndGameManager Instance;

    [HideInInspector]
    public string lvlUnclock = "LevelUnlock";

    public bool gameOver;
    private int score;

    private PanelContoller panelContoller;
    private TextMeshProUGUI scoreText;



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    public void UpdateScore(int addScore)
    {
        score += addScore;
        scoreText.text = "Score: " + score.ToString();
    }

    public void WinGame()
    {
        ScoreSet();
        panelContoller.ActivateWin();

        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        if(nextLevel > PlayerPrefs.GetInt(lvlUnclock, 0))
        {
            PlayerPrefs.SetInt(lvlUnclock, nextLevel);
        }
    }

    public void LoseGame()
    {
        ScoreSet();
        panelContoller.ActivateLose();
    }

    public void ResolveGame()
    {
        if (gameOver == false)
        {
            WinGame();
        }
        else
        {
            LoseGame();
        }
    }

    public void RegisterPanelController(PanelContoller pC)
    {
        panelContoller = pC;
    }

    public void RegisterScoreText(TextMeshProUGUI scoreTextComp)
    {
        scoreText = scoreTextComp;
    }

    public void StartResolveSequence()
    {
        StopCoroutine(ResolveSequence());
        StartCoroutine(ResolveSequence());
    }


    private IEnumerator ResolveSequence()
    {
        yield return new WaitForSeconds(2);
        ResolveGame();
    }

    private void ScoreSet()
    {
        PlayerPrefs.SetInt("Score" + SceneManager.GetActiveScene().name, score);
        int highScore = PlayerPrefs.GetInt("HighScore" + SceneManager.GetActiveScene().name, 0);

        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore" + SceneManager.GetActiveScene().name, score);
        }

        score = 0;
    }
}
