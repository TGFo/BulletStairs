using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTimer : MonoBehaviour
{
    public float timePerWater = 10f;          // Time in seconds after which to subtract
    public float currentTime;                 // Current time left in the level
    public bool timerRunning = false;         // Is the timer running?
    public TMP_Text timerText;                // UI text element to display the timer
    public int waterSubtractionAmount = 1;    // The amount to subtract from an int
    private float timeSinceLastSubtract = 0f; // Tracks time since the last subtraction

    // Start is called before the first frame update
    void Start()
    {
        UpdateTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerRunning)
        {
            currentTime -= Time.deltaTime;
            timeSinceLastSubtract += Time.deltaTime;  // Track the time passed since the last subtraction

            if (timeSinceLastSubtract >= timePerWater)
            {
                SubtractValue();
                timeSinceLastSubtract = 0f;  // Reset the subtraction timer
            }

            if (currentTime <= 0)
            {
                currentTime = 0;
                TimerEnded();
            }

            UpdateTimerDisplay();
        }
    }

    // Method to subtract the value
    void SubtractValue()
    {
        // Subtract the desired amount from the resource or value you're managing
        PlayerManager.instance.playerWater -= waterSubtractionAmount;
        Debug.Log("Subtracted " + waterSubtractionAmount + " from carriedWater. New value: " + ResourceManager.instance.carriedWater);

        // Optional: If you want to end the timer if a resource (e.g., water) runs out
        if (ResourceManager.instance.carriedWater <= 0)
        {
            ResourceManager.instance.carriedWater = 0;  // Prevent negative values
            TimerEnded();
        }
    }

    // Method to update the timer display on the UI
    void UpdateTimerDisplay()
    {
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(currentTime / 60);
            int seconds = Mathf.FloorToInt(currentTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    // Method called when the timer ends
    void TimerEnded()
    {
        timerRunning = false;
        SceneManager.LoadScene("World");
        ResourceManager.instance.NextDay();
    }

    // Method to initialize and start the timer
    void UpdateTimer()
    {
        timerRunning = true;
        currentTime = ResourceManager.instance.carriedWater * timePerWater;
        UpdateTimerDisplay();
    }
}
