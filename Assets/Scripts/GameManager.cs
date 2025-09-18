using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{

    [Header("Color Settings")]
    [SerializeField] private PlayerController[] Players;
    [SerializeField] private int index = 0;

    public void ChangePlayerPositive(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Players[index].enabled = false;
            Players[index + 1].enabled = true;
            index++;
            index %= Players.Length;
        }
    }

    public void ChangePlayerNegative(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Players[index].enabled = false;
            Players[index - 1].enabled = true;
            index--;
            index = index < 0 ? Players.Length - 1 : index;
        }
    }
}
