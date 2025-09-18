using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController[] Players;
    [SerializeField] private int index = 0; 

    [SerializeField] private GameObject GameOverPanel;
    [SerializeField] private GameObject WinPanel;
    
    public void ChangePlayerPositive(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Players[index].enabled = false;
            Players[index].ModifyCanJump(false);

            index++;
            index %= Players.Length;

            Players[index].enabled = true;
            Players[index].ModifyCanJump(true);
        }
    }

    public void ChangePlayerNegative(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Players[index].enabled = false;
            Players[index].ModifyCanJump(false);

            index--;
            index = index < 0 ? Players.Length - 1 : index;

            Players[index].enabled = true;
            Players[index].ModifyCanJump(true);
        }
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GameOver()
    {
        GameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void WinGame()
    {
        WinPanel.SetActive(true);
        Time.timeScale = 0f;
    }
}

