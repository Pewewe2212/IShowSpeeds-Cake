using UnityEngine;
using UnityEngine.InputSystem;

public class Minigame2Trigger : MonoBehaviour
{
    public Minigame2 game;
    public GameObject gameObject_;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Keyboard.current.eKey.wasPressedThisFrame || Input.GetButtonDown("Jump"))
            {
                game.isActive = true;
                gameObject_.SetActive(true);
                FindFirstObjectByType<PlayerScript>().CanMove = false;
                gameObject.SetActive(false);
            }
        }
    }
}
