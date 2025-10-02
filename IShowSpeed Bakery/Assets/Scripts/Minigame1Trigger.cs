using UnityEngine;
using UnityEngine.InputSystem;

public class Minigame1Trigger : MonoBehaviour
{
    public Minigame1 game;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Keyboard.current.eKey.wasPressedThisFrame || Input.GetKeyDown("Jump"))
            {
                game.isActive = true;
                // Make it so the player can't move
            }
        }
    }
}
