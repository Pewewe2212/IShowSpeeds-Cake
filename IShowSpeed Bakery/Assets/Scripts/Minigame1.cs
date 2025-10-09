using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Minigame1 : MonoBehaviour
{
    // Idea of the minigame, you are told that the cake needs to be baked for X seconds and you will have to remember it and take it out of the oven before it burns, but not too fast so its not raw

    // Checks if the minigame is active
    public bool isActive;
    [SerializeField] private bool isGameStarted;

    [Tooltip("Checks wether the game has been done once before, so you can't do the same minigame twice")]
    [SerializeField] public bool hasThisGameBeenDone;

    // Timer for making the minigame have a time limit
    [SerializeField] private float currentTimer;

    [Tooltip("Add a goal time when the order is given")]
    [SerializeField] private int goalTime;

    [Tooltip("The score that you add to the final score")]
    [SerializeField] public int score;

    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject button; // The image of X and Space
    [SerializeField] private GameObject ovenON;

    private void Start()
    {
        isActive = false;
        gameObject.SetActive(false);
        ovenON.SetActive(false);
    }

    private void Update()
    {
        if (isActive && !hasThisGameBeenDone)
        {
            Minigame();
            // Failsafe if you forget to add a goal time
            if (goalTime == 0)
            {
                goalTime = 10;
            }
        }
    }

    // The actual minigame
    private void Minigame()
    {
        // Idea: Just start with something simple, press X or Space within a specific time frame
        if (isGameStarted)
        {
            currentTimer += Time.deltaTime;
            timerText.text = ((int)currentTimer).ToString();
        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame || Input.GetButtonDown("Fire1"))
        {
            // Starts the game
            if (!isGameStarted)
            {
                isGameStarted = true;
                button.SetActive(true);
                ovenON.SetActive(true);
                // Add an animation or smth
            }
            else
            {
                // Determines the score based on how accurate you were to the timer, if you overcook or undercook it, you lose score
                if (goalTime > currentTimer)
                {
                    score = 10 - (goalTime - (int)currentTimer);
                }
                else if (goalTime < currentTimer)
                {
                    score = 10 - ((int)currentTimer - goalTime);
                }
                else { score = 10; }

                if (score < 0) { score = 0; }

                hasThisGameBeenDone = true;
                // Add something to increase the score
            }
        }
    }

    // Call this when you turn the minigame off
    public void ResetGame()
    {
        isActive = false;
        isGameStarted = false;
        button.SetActive(false);
        ovenON.SetActive(false);
        currentTimer = 0;
        score = 0;
    }
}