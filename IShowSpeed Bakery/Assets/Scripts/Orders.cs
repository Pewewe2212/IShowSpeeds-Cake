using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Orders : MonoBehaviour
{
    [SerializeField] public GameObject correctItem;
    [SerializeField] List<GameObject> items;

    [SerializeField] public Minigame1 mg1;
    [SerializeField] public Minigame2 mg2;

    [SerializeField] bool done;
    [SerializeField] public int score;

    [SerializeField] TextMeshProUGUI text;
    [SerializeField] GameObject order;

    private void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame || Input.GetButtonDown("Fire1"))
        {
            correctItem.SetActive(false);
            order.SetActive(false);
        }
    }

    public void GetOrder()
    {
        int time = mg1.goalTime = Random.Range(3, 10);
        correctItem = items[Random.Range(0, items.Count)];

        foreach (var item in items)
        {
            item.SetActive(false);
        }

        text.text = $"Order:\nBake Time: {time}\nHidden Item:";
        correctItem.SetActive(true);
        order.SetActive(true);
    }

    public void FinishOrder()
    {
        done = false;
        mg1.ResetGame();
        mg2.ResetMinigame();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!done)
            {
                done = true;
                GetOrder();
            }
        }
    }
}