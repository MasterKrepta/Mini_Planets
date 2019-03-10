using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject WinScreen;
    // Start is called before the first frame update
    void Start()
    {
        StatsManager.OnGameOver += ToggleGameOver;
        StatsManager.OnGameWin += ToggleWin;
    }

    public void Restart() {
        SceneManager.LoadScene(1);
    }

    public void QuitGame() {
        Application.Quit();
    }

    void ToggleGameOver() {
        gameOverScreen.SetActive(true);
    }

    void ToggleWin() {
        WinScreen.SetActive(true);
    }
    private void OnDisable() {
        StatsManager.OnGameOver -= ToggleGameOver;
        StatsManager.OnGameWin -= ToggleWin;
    }
}
