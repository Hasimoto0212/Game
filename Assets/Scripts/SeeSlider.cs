using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeeSlider : MonoBehaviour/*, IPause*/
{

    [SerializeField] GameObject m_slider;
    [SerializeField] GameObject m_Player;
    [SerializeField] float m_maxHp = 0f;

    float m_nowHp;

    // Use this for initialization
    void Start()
    {
        Slider slider = m_slider.GetComponent<Slider>();

        m_nowHp = m_maxHp;

        //スライダーの最大値の設定
        slider.maxValue = m_maxHp;
        slider.value = m_nowHp;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (m_nowHp <= 0)
        {
            Destroy(m_Player);
        }
    }

    public void Addhp(float hp)
    {
        Slider slider = m_slider.GetComponent<Slider>();

        m_nowHp -= hp;
        slider.value = m_nowHp;
    }

    //public void Pause()
    //{
    //    throw new System.NotImplementedException();
    //}

    //public void Resume()
    //{
    //    throw new System.NotImplementedException();
    //}
}
