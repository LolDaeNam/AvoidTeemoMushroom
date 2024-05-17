using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameObject mushroom;
    private float intervalTime = 1f;
    private bool isPlaying = false;

    public void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
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
        SceneManager.LoadScene("EndScene");
        isPlaying =false;
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