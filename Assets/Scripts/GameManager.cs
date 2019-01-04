using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public delegate void WaveStartAction();
    public static event WaveStartAction WaveStartEvent;

    public bool isPlayingAWave = false;
    public int score;

    [SerializeField]
    GameObject titleMenu;

    [SerializeField]
    GameObject gameOverScreen;

    [SerializeField]
    Timer timer;

    [SerializeField]
    GameObject gloves;

	// Use this for initialization
	void Start () {
        if (instance == null) {
            instance = this;
        } else if (this != instance) {
            Destroy(this);
        }
        RenderSettings.fogColor = Camera.main.backgroundColor;
        RenderSettings.fogDensity = 0.03f;
        RenderSettings.fog = true;
        DontDestroyOnLoad(this);
        gloves.SetActive(false);
        gameOverScreen.SetActive(false);

        Timer.TimerIsOverEvent += EndGame;
    }
	
    public void StartGame() {
        score = 0;
        timer.UpdateScoreText();
        timer.StartTimer();
        titleMenu.SetActive(false);
        gameOverScreen.SetActive(false);
        isPlayingAWave = true;
        gloves.SetActive(true);
        RemoveAllFish();

    }

    void EndGame() {
        isPlayingAWave = false;
        gloves.SetActive(false);
        gameOverScreen.GetComponentInChildren<TextMeshProUGUI>().text = "You punched " + score + " fish. That wasn't very nice.";
        gameOverScreen.SetActive(true);
    }

    void RemoveAllFish() {

        Fish[] allFish = FindObjectsOfType<Fish>();

        for (int i = allFish.Length - 1; i >= 0; i--) {
            Destroy(allFish[i].gameObject);
        }
    }

}
