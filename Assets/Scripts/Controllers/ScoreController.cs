using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private Text totalScoreTxt;
    [SerializeField] private Text bestScoreTxt;

    private void Update()
    {
        
        totalScoreTxt.text = GameManager.Instance.totalScore.ToString();

        GameManager.Instance.UpdateBestScore(GameManager.Instance.totalScore);
        bestScoreTxt.text = PlayerPrefs.GetInt("BestScore").ToString();
    }
}
