using UnityEngine;
using UnityEngine.InputSystem;

public class OrderFinishedArea : MonoBehaviour
{
    //section for the order script

    [SerializeField] Minigame1 game1;
    [SerializeField] Minigame2 game2;

    [SerializeField] int score;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if ((Keyboard.current.eKey.wasPressedThisFrame || Input.GetButtonDown("Jump")) && game2.hasThisGameBeenDone)
            {
                score = game1.score + game2.score;
            }
        }
    }
}
