using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinScreen : MonoBehaviour
{
    // Start is called before the first frame update
    public float winLives = 0f;
    public float winScore = 0f;

    public TextMeshProUGUI winLivesUI;
    public TextMeshProUGUI winScoreUI;
    void Awake()
    {
        winLives = FindObjectOfType<GameManager>().playerLives;
        winScore = FindObjectOfType<GameManager>().playerScore;
    }

    void Start()
    {
        winLivesUI.text = winLives.ToString();
        winScoreUI.text = winScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
      
    }


}
