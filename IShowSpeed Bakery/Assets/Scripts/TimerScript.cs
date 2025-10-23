using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
 
    [Header("Timer Settings")]
    public float startTime = 120f; // sekunteina
    public bool autoStart = true;

    [Header("UI Reference")]
    public TextMeshProUGUI timerText;

    private float currentTime;
    private bool isRunning = false;

    void Start()
    {
        currentTime = startTime;

        if (autoStart)
            StartTimer();
    }

    void Update()
    {
        if (!isRunning) return;

        currentTime -= Time.deltaTime;
        currentTime = Mathf.Max(currentTime, 0f);

        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        timerText.text = $"Aika: {minutes:00}:{seconds:00}";

        // Kun aika loppuu
        if (currentTime <= 0)
        {
            isRunning = false;
            OnTimerEnd();
        }
    }

    public void StartTimer()
    {
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    private void OnTimerEnd()
    {
        Debug.Log("Aika loppui!");
        // Voit lisätä tähän esim. pelin päättymisen, varoituksen, äänen jne.
    }
}
