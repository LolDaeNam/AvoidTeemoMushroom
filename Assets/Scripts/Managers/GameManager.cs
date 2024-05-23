using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameObject mushroom;   // 버섯 프리펩
    
    public bool isActiveEskill = false;     // E스킬 사용 중 여부 
    public bool isActiveRskill = false;     // R스킬 사용 중 여부

    [SerializeField] GameObject[] items;    // 아이템 배열
    
    private float startTime, nowTime;       // 게임 시작시간, 시작 이후 시간
    private bool isPlaying = false;         // 플레이 중 여부
    
    public int totalScore = 0;              // 획득 점수
    private int bestScore = 0;              // 최고 기록 점수


    public void Awake()
    {
        // 싱글톤
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        startTime = Time.time;
    }

    public void Start()
    {
        // 저장된 최고 기록 점수 불러오기
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
    }

    public void FixedUpdate()
    {
        // 플레이 중일 경우
        if (isPlaying)
        {
            nowTime = Time.time - startTime;
            // 10초마다 아이템 랜덤 생성
            if (nowTime % 10 == 0)
            { 
                int randomItemIndex = Random.Range(0, items.Length);
                Instantiate(items[randomItemIndex]);
            }
            // 0.25초마다 1 ~ 3개의 버섯 랜덤 생성
            if (nowTime % 0.25 == 0)
            {
                int num = Random.Range(1, 4);
                for (int i = 0; i < num; i++)
                {
                    MakeMushroom();
                }
            }
        }
    }

    // 게임 시작
    public void GameStart()
    {
        isPlaying = true;
        Time.timeScale = 1f;
        totalScore = 0;
    }

    // 게임 종료
    public void GameOver()
    {
        isPlaying = false;
        SceneManager.LoadScene(2);  // 엔드 씬
    }

    // 게임 일시정지
    public void GamePause()
    {
        Time.timeScale = 0f;
    }

    // 게임 재개
    public void GamePlay()
    {
        Time.timeScale = 1f;
    }

    // 버섯 생성
    public void MakeMushroom()
    {
        Instantiate(mushroom);
    }

    // 최고 기록 점수 갱신
    public void UpdateBestScore(int newScore)
    {
        if(newScore > bestScore)
        {
            bestScore = newScore;
            PlayerPrefs.SetInt("BestScore", bestScore);
           
        }
    }
}
