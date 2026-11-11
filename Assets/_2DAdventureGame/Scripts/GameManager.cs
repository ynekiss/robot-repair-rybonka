using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    private bool m_IsGameOver = false;

    private void Awake()
    {
        instance = this;
    }

    // Тригер поразки
    public void GameOver()
    {
        if (m_IsGameOver) return;
        m_IsGameOver = true;

        Time.timeScale = 0; // Зупиняємо гру
        if (UIHandler.instance != null)
        {
            UIHandler.instance.ShowEndScreen("Game Over!");
        }
    }

    // Тригер перемоги (наприклад, при полагодженні всіх роботів / розмові з NPC)
    public void WinGame()
    {
        if (m_IsGameOver) return;
        m_IsGameOver = true;

        Time.timeScale = 0; // Зупиняємо гру
        if (UIHandler.instance != null)
        {
            UIHandler.instance.ShowEndScreen("You Win!");
        }
    }
}