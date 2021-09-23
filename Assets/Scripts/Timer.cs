using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour, IPause
{
    [SerializeField] Text m_text;
    [SerializeField] Text m_clearText;
    public float m_timer;
    float m_saveTimer;
    bool m_timebool = true;
    public float m_clearTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_timebool)
        {
            m_timer += Time.deltaTime;
            m_text.text = "Time : " + m_timer.ToString("n2");
        }
        else
        {
            m_timer = m_saveTimer;
            m_text.text = "Time : " + m_saveTimer.ToString("n2");
        }
        m_clearText.text = "Time : " + m_clearTime.ToString("n2");
    }

    public void Pause()
    {
        m_saveTimer = m_timer;
        m_timebool = false;
    }

    public void Resume()
    {
        m_timebool = true;
    }
}
