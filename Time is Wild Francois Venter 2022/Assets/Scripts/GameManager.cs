using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] TextMeshProUGUI livesUI;
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
        livesUI.text = playerLives.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
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

    void ResetGame()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
