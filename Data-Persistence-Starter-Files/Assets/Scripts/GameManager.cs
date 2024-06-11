using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public Text bestScore;
    void Start()
    {
        BestScoreSaver.Instance.LoadScore();
        bestScore.text = $"Best Score: " + BestScoreSaver.Instance.bestName + " : " + BestScoreSaver.Instance.BestScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
