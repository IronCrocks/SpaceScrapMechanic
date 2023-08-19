using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameManager GameManager;

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void Revive()
    {
        GameManager.KillEnemies();
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        Time.timeScale = 0f;
    }

    private void OnDisable()
    {
        Time.timeScale = 1f;
        GameManager.Player.SetActive(true);
    }
}
