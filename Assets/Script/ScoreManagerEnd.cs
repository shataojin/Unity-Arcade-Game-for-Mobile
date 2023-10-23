using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManagerEnd : MonoBehaviour
{
    [Header("BackgroundStarsBehaviour,Student Name: Sha taojin , StudentID:101334639," +
"Date last Modified:2023/10/22,Program description:ScoreManagerEnd  " +
"Revision History :new C# for move player score to end scene, still need some fix")]
    private TMP_Text scoreLabel;
    private int score = 0;
    public ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        scoreLabel = GameObject.Find("ScoreLabel").GetComponent<TMP_Text>();
        SetScore(0);
    }

    public int GetScore()
    {
        return score;
    }

    public void SetScore(int newScore)
    {
        score = newScore;
        UpdateScoreLabel();
    }

    public void AddPoints()
    {
        score = scoreManager.GetScore();
        UpdateScoreLabel();
    }

    public void UpdateScoreLabel()
    {
        scoreLabel.text = $"Score: {score}";
    }
}
