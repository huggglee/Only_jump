using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private bool isGameOver = false;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    
    public void GameOver()
    {
        if (isGameOver) return;
        isGameOver = true;
        Invoke("RestartGame", 2f);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
