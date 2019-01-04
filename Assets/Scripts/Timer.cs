using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour {

    [SerializeField]
    float waveLength = 60;
    public float currentTime = 60;
    public bool isRunning = false;

    public delegate void TimerIsOverAction();
    public static event TimerIsOverAction TimerIsOverEvent;
    

    [SerializeField]
    TextMeshProUGUI timeText;


	// Update is called once per frame
	void Update () {
        if (isRunning && currentTime > 0) {
            currentTime -= Time.deltaTime;
            UpdateScoreText();
        } else if(isRunning && currentTime <= 0) {
            currentTime = 0;
            StopTimer(); 
            UpdateScoreText();
            TimerIsOverEvent.Invoke();
        }
    }

    public void StartTimer() {
        Reset();
        isRunning = true;
    }

    public void UpdateScoreText() {
        timeText.text = "Time: " +  currentTime.ToString("F2");
    }

    public void StopTimer() {
        isRunning = false;
    }

    public void Reset() {
        currentTime = waveLength;
        UpdateScoreText();
    }
    
}
