using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayController : MonoBehaviour
{
    public static GamePlayController Instance { get; private set; }
    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    [SerializeField] int score;
    [SerializeField] int highscore;
    public Color[] template = { new Color32(255, 81, 81, 255), new Color32(255, 129, 82, 255), new Color32(255, 233, 82, 255), new Color32(163, 255, 82, 255), new Color32(82, 207, 255, 255), new Color32(170, 82, 255, 255) };
    [SerializeField] int[] level = { 3, 4, 6 };

    private UIController uiController;

    public List<int> currentIndex = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        uiController = GetComponent<UIController>();
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        uiController.GameOver();
    }

    public void UpdateScore()
    {
        score++;
        uiController.UpdateScore(score);
        if (score > highscore)
        {
            highscore = score;
            uiController.UpdateHighScore(highscore);
            int levelIndex = PlayerPrefs.GetInt("level");
            PlayerPrefs.SetInt("highscore"+ levelIndex, highscore);
        }
    }

    public void Reset()
    {
        Time.timeScale = 1;
        score = 0;
        int levelIndex = PlayerPrefs.GetInt("level");
        highscore = PlayerPrefs.GetInt("highscore"+levelIndex);
        uiController.UpdateScore(score);
        uiController.UpdateHighScore(highscore);
    }

    public int GetMaxColor()
    {
        int levelIndex = PlayerPrefs.GetInt("level");

        return level[levelIndex];
    }
}
