using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    //public TextMeshProUGUI pointText;
    public void Setup(int score)
    {
        gameObject.SetActive(true);
        //pointText.text = score.ToString() + " Kills";
    }
    public void Restart()
    {
        SceneManager.LoadScene("Level01");
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("Level01");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void GameStart()
    {
        SceneManager.LoadScene("Terrain");
    }
    public void Quit()
    {
        Application.Quit();
    }
    private void Start()
    {
         Cursor.lockState = CursorLockMode.None;
    }
}
