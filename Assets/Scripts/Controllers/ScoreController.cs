using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private Text totalScoreTxt;

    private void Update()
    {
        totalScoreTxt.text = GameManager.Instance.totalScore.ToString();
    }
}
