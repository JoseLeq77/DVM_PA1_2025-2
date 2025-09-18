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
}
