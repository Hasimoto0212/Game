using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    int m_score;
    public int CoinCounter;
    [SerializeField] GameObject m_scoreText;
    [SerializeField] GameObject m_clearScoreText;

    // Start is called before the first frame update
    void Start()
    {
        Text scoreText = m_scoreText.GetComponent<Text>();
        scoreText.text = m_score.ToString() + "枚";
        Text clearScoreText = m_clearScoreText.GetComponent<Text>();
        clearScoreText.text = m_score.ToString() + "  枚";
    }
    public void AddScore(int score)
    {
        m_score += score;   // m_score = m_score + score の短縮形

        // スコアを画面に表示する
        Text scoreText = m_scoreText.GetComponent<Text>();
        scoreText.text = m_score.ToString() + "枚";
        Text clearScoreText = m_clearScoreText.GetComponent<Text>();
        clearScoreText.text = m_score.ToString() + "  枚";
    }

    // Update is called once per frame
    void Update()
    {

    }
}
