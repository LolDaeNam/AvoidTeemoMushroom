using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameObject mushroom;
 

    private float intervalTime = 1f;
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
            if (intervalTime > 0)
            {
                intervalTime -= Time.fixedDeltaTime;
            }
            else
            {
                MakeMushroom();
                intervalTime = 1;
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
