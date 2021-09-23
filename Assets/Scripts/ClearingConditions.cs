using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClearingConditions : MonoBehaviour
{
    [SerializeField] GameObject gameManager;
    [SerializeField] int m_clearingConditions;
    [SerializeField] UnityEvent panelObject;
    public int crearitem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Timer T = gameManager.GetComponent<Timer>();
        AudioSource audio = gameManager.GetComponent<AudioSource>();
        if (crearitem >= m_clearingConditions && collision.gameObject.tag == "Player")
        {
            audio.Stop();
            T.m_clearTime = T.m_timer;
            panelObject.Invoke();
        }
    }
}
