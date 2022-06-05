using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] float loadDelay = 5f;
    // [SerializeField] GameObject _healthUI;
    // [SerializeField] GameObject _scoreUI;
    // [SerializeField] GameObject _Heart;
    // [SerializeField] GameObject _Skull;
    [SerializeField] GameObject oldHealth;
    [SerializeField] GameObject oldHeart;
    [SerializeField] GameObject oldScore;
    [SerializeField] GameObject oldSkull;
    [SerializeField] GameObject oldTIME;
    // Start is called before the first frame update


    public void PlayGame()
    {
        SceneManager.LoadScene(2);
    }

    public void Controls()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(LoadNextLevel());
        }
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(loadDelay);

         int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
         int nextSceneIndex = currentSceneIndex + 1;

        // if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        // {
        //     nextSceneIndex = 0;
        // }

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings - 1)
        {
            // _healthUI.SetActive(true);
            // _scoreUI.SetActive(true);
            // _Heart.SetActive(true);
            // _Skull.SetActive(true);
            // oldHealth.SetActive(false);
            // oldHeart.SetActive(false);
            // oldScore.SetActive(false);
            // oldSkull.SetActive(false);
            // oldTIME.SetActive(false);

        }

        SceneManager.LoadScene(nextSceneIndex);

    }

    public void ExitWinScreen()
    {
        FindObjectOfType<GameManager>().ResetGame();
        
    }

    public void RetryWinScreen()
    {
        FindObjectOfType<GameManager>().ResetGame();
        SceneManager.LoadScene(2);
    }
}
