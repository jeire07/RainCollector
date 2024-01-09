using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Rain;
    public GameObject Panel;

    public static GameManager Instance;

    public Text ScoreText;
    public Text TimeText;

    private int _totalScore = 0;
    private float _limit = 10.0f;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("makeRain", 0.0f, 0.5f);
        InitGame();
    }

    // Update is called once per frame
    void Update()
    {
        _limit -= Time.deltaTime;

        if (_limit < 0)
        {
            _limit = 0.0f;
            Panel.SetActive(true);
            Time.timeScale = 0.0f;
        }

        TimeText.text = _limit.ToString("N2");
    }

    private void MakeRain()
    {
        //Debug.Log("비를 내려라!");
        Instantiate(Rain);
    }

    public void AddScore(int score)
    {
        _totalScore += score;
        ScoreText.text = _totalScore.ToString();
    }

    public void Retry()
    {
        SceneManager.LoadScene("MainScene");
    }

    private void InitGame()
    {
        Time.timeScale = 1.0f;
        _totalScore = 0;
        _limit = 10.0f;
    }
}
