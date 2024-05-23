using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private Text totalScoreTxt;    // 현재 점수
    [SerializeField] private Text bestScoreTxt;     // 최고 점수

    private void Update()
    {
        // 게임매니저에서 현재 점수를 받아와서 텍스트 UI에 반영
        totalScoreTxt.text = GameManager.Instance.totalScore.ToString();
        // 게임매니저에서 최고 점수를 계산하고 텍스트 UI에 반영
        GameManager.Instance.UpdateBestScore(GameManager.Instance.totalScore);
        bestScoreTxt.text = PlayerPrefs.GetInt("BestScore").ToString();
    }
}
