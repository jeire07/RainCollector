using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject rain;
    public GameObject panel;
    public static GameManager I;
    public Text scoreText;
    public Text timeText;
    int totalScore = 0;
    float limit = 10.0f;

    void Awake()
    {
        I = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("makeRain", 0.0f, 0.5f);
        initGame();
    }

    // Update is called once per frame
    void Update()
    {
        limit -= Time.deltaTime;

        if (limit < 0)
        {
            limit = 0.0f;
            panel.SetActive(true);
            Time.timeScale = 0.0f;
        }

        timeText.text = limit.ToString("N2");
    }

    void makeRain()
    {
        //Debug.Log("비를 내려라!");
        Instantiate(rain);
    }

    public void addScore(int score)
    {
        totalScore += score;
        scoreText.text = totalScore.ToString();
    }

    public void retry()
    {
        SceneManager.LoadScene("MainScene");
    }

    void initGame()
    {
        Time.timeScale = 1.0f;
        totalScore = 0;
        limit = 10.0f;
    }
}
