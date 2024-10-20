using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTimer : MonoBehaviour
{
    public float timePerWater = 10f;
    public float currentTime;
    public bool timerRunning = false;
    public TMP_Text timerText;
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

            if (currentTime <= 0)
            {
                currentTime = 0;
                TimerEnded();  
            }

            UpdateTimerDisplay();
        }
    }
    void UpdateTimerDisplay()
    {
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(currentTime / 60);
            int seconds = Mathf.FloorToInt(currentTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
    void TimerEnded()
    {
        timerRunning = false;
        SceneManager.LoadScene("World");
        ResourceManager.instance.NextDay();
    }
    void UpdateTimer()
    {
        timerRunning = true;
        currentTime = ResourceManager.instance.carriedWater * timePerWater;
        UpdateTimerDisplay();
    }
}
