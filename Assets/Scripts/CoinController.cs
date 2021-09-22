using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField] int m_score;
    [SerializeField] GameObject m_scoreManager;
    [SerializeField] GameObject m_prefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(m_prefab);
            if (m_scoreManager != null)
            {
                ScoreManager sm = m_scoreManager.GetComponent<ScoreManager>();
                sm.AddScore(m_score);
                sm.CoinCounter += 1;
            }
            Destroy(this.gameObject);
        }
    }
}
