using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Minigame2 : MonoBehaviour
{
    /// <summary>
    /// Objects appear on screen, click A/Space when the right item is on screen
    /// </summary>

    // The minigame before this one, to make sure you did it before this minigame
    [SerializeField] Minigame1 minigame1;
    [SerializeField] Orders orders;

    [SerializeField] public int score;

    // The text to display your score
    [SerializeField] private GameObject scoreText;
    [SerializeField] private TextMeshProUGUI scoreT;

    // Bools to check if the game is real and done
    [SerializeField] public bool isActive;
    [SerializeField] public bool hasThisGameBeenDone;

    [Tooltip("What items are in existence")]
    [SerializeField] List<GameObject> items;

    [Tooltip("What items is currently being shown")]
    [SerializeField] GameObject currentItem;

    private float timer;


    private void Start()
    {
        gameObject.SetActive(false);
        scoreText.SetActive(false);
        foreach (var item in items)
        {
            item.SetActive(false);
        }
        currentItem = items[Random.Range(0, items.Count)];
    }

    private void Update()
    {
        if (isActive && !hasThisGameBeenDone && minigame1.hasThisGameBeenDone)
        {
            Minigame();
        }
        if (hasThisGameBeenDone)
        {
            if (Keyboard.current.eKey.wasPressedThisFrame || Input.GetButtonDown("Jump"))
            {
                gameObject.SetActive(false);
                currentItem.SetActive(false);
                FindFirstObjectByType<PlayerScript>().CanMove = true;
            }
        }
    }

    public void Minigame()
    {
        timer += Time.deltaTime;
        currentItem.SetActive(true);
        if (timer > 3)
        {
            timer = 0;
            currentItem.SetActive(false);
            currentItem = items[Random.Range(0, items.Count)];
            currentItem.SetActive(true);
        }
        if (Keyboard.current.spaceKey.wasPressedThisFrame || Input.GetButtonDown("Fire1"))
        {
            if (currentItem == orders.correctItem)
            {
                score = 10;
            }
            else
            {
                score = 0;
            }
            scoreT.text = "Score: " + score.ToString();
            hasThisGameBeenDone = true;
        }
    }

    public void ResetMinigame()
    {
        gameObject.SetActive(false);
        hasThisGameBeenDone = false;
        score = 0;
    }
}
