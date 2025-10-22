using UnityEngine;
using UnityEngine.InputSystem;

public class OrderFinishedArea : MonoBehaviour
{
    [SerializeField] Orders order;
    [SerializeField] Minigame1 game1;
    [SerializeField] Minigame2 game2;
    // Add a score for time
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if ((Keyboard.current.eKey.wasPressedThisFrame || Input.GetButtonDown("Jump")) && game2.hasThisGameBeenDone)
            {
                order.score = game1.score + game2.score;
            }
        }
    }
}
