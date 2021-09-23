using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurveillanceCamera : MonoBehaviour, IPause
{
    [SerializeField] GameObject EnemyCamera;
    [SerializeField] GameObject Player;
    [SerializeField] float m_damage;
    [SerializeField] GameObject m_gameManager;

    [SerializeField]public float m_Roat = 0.01f;
    public float m_saveRoat;
    bool m_work = true;

    // Start is called before the first frame update
    void Start()
    {
        m_saveRoat = m_Roat;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_work) 
        {
            transform.Rotate(0f, 0f, 90.0f * m_saveRoat);
        }
    }

    public void Surveillance()
    {
        SeeSlider ss = m_gameManager.GetComponent<SeeSlider>();
        ss.Addhp(m_damage);
        var vec = (EnemyCamera.transform.position - Player.transform.position).normalized;
        EnemyCamera.transform.rotation = Quaternion.FromToRotation(Vector3.up, vec);
    }

    public void Pause()
    {
        m_work = false;
    }

    public void Resume()
    {
        m_work = true;
    }
}

