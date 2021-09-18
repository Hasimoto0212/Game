using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearingConditions : MonoBehaviour
{
    [SerializeField] int m_clearingConditions;
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
        if (crearitem >= m_clearingConditions && collision.gameObject.tag == "Player")
        {
            Debug.Log("crear");
        }
    }
}
