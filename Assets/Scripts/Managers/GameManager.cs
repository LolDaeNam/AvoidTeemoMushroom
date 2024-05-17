using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameObject mushroom;
    private float intervalTime = 1f;
    private bool isPlaying = false;

    [SerializeField] private Text totalScoreTxt;

    public int totalScore = 0;

    public void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        totalScoreTxt.text = totalScore.ToString();
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
    }

    public void GameOver()
    {
        isPlaying = false;
    }

    public void GamePause()
    {
        Time.timeScale = 0;
    }

    public void MakeMushroom()
    {
        Instantiate(mushroom);
    }

}
