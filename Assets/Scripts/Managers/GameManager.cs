using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameObject mushroom;
    
    public bool isActiveSkill = false;

    [SerializeField] GameObject[] items;
    
    private float startTime, nowTime;
    private bool isPlaying = false;
    
    public int totalScore = 0;
    private int bestScore = 0; //최고점


    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        startTime = Time.time;
    }

    public void Start()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        
    }

    public void FixedUpdate()
    {
        if (isPlaying)
        {
            nowTime = Time.time - startTime;
            if (nowTime % 10 == 0)
            { 
                int randomItemIndex = Random.Range(0, items.Length);
                Instantiate(items[randomItemIndex]);
            }
            if (nowTime % 0.25 == 0)
            {
                int num = Random.Range(1, 4);
                for (int i = 0; i < num; i++)
                {
                    Instantiate(mushroom);
                }
            }
        }
    }

    public void GameStart()
    {
        isPlaying = true;
        Time.timeScale = 1f;
        totalScore = 0;
    }

    public void GameOver()
    {
        isPlaying = false;
        SceneManager.LoadScene(2);
    }

    public void GamePause()
    {
        Time.timeScale = 0f;
    }

    public void MakeMushroom()
    {
        Instantiate(mushroom);
    }

    public void UpdateBestScore(int newScore)
    {
        if(newScore > bestScore)
        {
            bestScore = newScore;
            PlayerPrefs.SetInt("BestScore", bestScore);
           
        }
    }
}
