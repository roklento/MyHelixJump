using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool isGameOver;
    public static bool isLevelWin;
    public static int currentLevelIndex;
    public static int currentScore = 0;
    public static int maxScore = 0;
    public static float numberOfPassingRings;

    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject levelWinPanel;
    [SerializeField] private TextMeshProUGUI currentLevelText;
    [SerializeField] private TextMeshProUGUI nextLevelText;
    [SerializeField] private TextMeshProUGUI CurrentScoreText;
    [SerializeField] private TextMeshProUGUI MaxScoreText;
    [SerializeField] private Slider proggressBar;
    [SerializeField] private Camera newCamera;
    [SerializeField] private Color[] colors;
    private void Awake()
    {
        //PlayerPrefs.DeleteAll();
        maxScore = PlayerPrefs.GetInt("maxScore", 0);
        currentLevelIndex = PlayerPrefs.GetInt("CurrentLevelIndex", 1);
    }
    private void Start()
    {
        newCamera.backgroundColor = colors[Random.Range(0, colors.Length - 1)];
        numberOfPassingRings = 0;
    }
    private void Update()
    {
        if(isGameOver)
        {
            Time.timeScale = 0;
            currentScore = 0;
            gameOverPanel.SetActive(true);
            if(Input.GetMouseButton(0))
            {
                SceneManager.LoadScene(0);
                isGameOver = false;
                Time.timeScale = 1f;
            }
        }

        currentLevelText.text = currentLevelIndex.ToString();
        nextLevelText.text = (currentLevelIndex + 1).ToString();

        float proggress = numberOfPassingRings / FindObjectOfType<HelixManager>().numberOfRings;
        proggressBar.value = proggress;
  
        if(maxScore < currentScore )
        {
            maxScore = currentScore;
            PlayerPrefs.SetInt("maxScore", maxScore);
        }
        CurrentScoreText.text = currentScore.ToString();
        MaxScoreText.text = maxScore.ToString();


        if (isLevelWin)
        {
            levelWinPanel.SetActive(true);
            if(Input.GetMouseButton(0))
            {
                PlayerPrefs.SetInt("CurrentLevelIndex", ++currentLevelIndex);
                SceneManager.LoadScene(0);
                isLevelWin = false;
            }
        }
    }
}
