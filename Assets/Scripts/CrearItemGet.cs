using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearItemGet : MonoBehaviour
{
    int m_itemCount = 0;
    [SerializeField] GameObject m_goalObject;
    [SerializeField] GameObject m_prefab;

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
        ClearingConditions cc = m_goalObject.GetComponent<ClearingConditions>();
        if (collision.gameObject.tag == ("Player"))
        {
            Instantiate(m_prefab);
            m_itemCount += 1;
            cc.crearitem += m_itemCount;
            Destroy(this.gameObject);
        }
    }
}
