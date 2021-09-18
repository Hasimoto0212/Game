using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    int m_score;
    public int CoinCounter;
    [SerializeField] GameObject m_scoreText;

    // Start is called before the first frame update
    void Start()
    {
        Text scoreText = m_scoreText.GetComponent<Text>();
        scoreText.text = "SCORE: " + m_score.ToString();
    }
    public void AddScore(int score)
    {
        m_score += score;   // m_score = m_score + score の短縮形
        Debug.LogFormat("Score: {0}", m_score);

        // スコアを画面に表示する
        Text scoreText = m_scoreText.GetComponent<Text>();
        scoreText.text = "SCORE: " + m_score.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
