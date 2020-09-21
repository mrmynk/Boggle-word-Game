using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI ScoreTxt;
    int _score;
    public TextMeshProUGUI WordCountTxt;
    int _wordCount;


    public int Score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
            ScoreTxt.text = _score.ToString();
        }
    }

    public int WordCount
    {
        get
        {
            return _wordCount;
        }
        set
        {
            _wordCount = value;
            WordCountTxt.text =_wordCount.ToString();
        }
    }

    public TextMeshProUGUI TimerTxt;
    int Timer;

    void Start()
    {
        Score = 0;
        WordCount = 0;
    }

    
    void Update()
    {
        UpdateTimer();
    }

    void UpdateTimer()
    {

    }

    public void AddScore(int score)
    {
        Score += score;
    }
}
