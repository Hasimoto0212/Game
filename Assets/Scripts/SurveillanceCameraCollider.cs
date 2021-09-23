using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurveillanceCameraCollider : MonoBehaviour
{
    [SerializeField] GameObject m_enemycamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        SurveillanceCamera sc = m_enemycamera.GetComponent<SurveillanceCamera>();
        if (collision.gameObject.tag == "Player")
        {
            sc.Surveillance();
            sc.m_saveRoat = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        SurveillanceCamera sc = m_enemycamera.GetComponent<SurveillanceCamera>();
        if (collision.gameObject.tag == "Player")
        {
            sc.m_saveRoat = sc.m_Roat;
        }
    }
}
