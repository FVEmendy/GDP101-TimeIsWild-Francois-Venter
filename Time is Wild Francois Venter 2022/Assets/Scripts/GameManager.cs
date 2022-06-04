using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] TextMeshProUGUI livesUI;
    [SerializeField] TextMeshProUGUI timeUI;
    [SerializeField] TextMeshProUGUI scoreUI;
    [SerializeField] TextMeshProUGUI healthWinUI;
    [SerializeField] TextMeshProUGUI scoreWinUI;
    public TimeIsWild _timeScript;
   
    int playerScore = 0;
    
    // Start is called before the first frame update

    void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameManager>().Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        _timeScript = FindObjectOfType<TimeIsWild>();
        livesUI.text = playerLives.ToString();
        scoreUI.text = playerScore.ToString();
        healthWinUI.text = playerLives.ToString();
        scoreWinUI.text = playerScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
         timeUI.text = TimeIsWild.showTimeUI;
    }

    public void processDeath()
    {
        if (playerLives > 1)
        {
            TakeLife();
        }

        else 
        {
            ResetGame();
        }


    }

    void TakeLife()
    {
        playerLives--;
        livesUI.text = playerLives.ToString();
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

    public void Retry()
    {
        SceneManager.LoadScene(2);
        Destroy(gameObject);
    }

    public void AddScore()
    {
        playerScore ++;
        scoreUI.text = playerScore.ToString();
    }
}
