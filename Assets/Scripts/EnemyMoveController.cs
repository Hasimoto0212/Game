using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveController : MonoBehaviour
{
    [SerializeField] public float m_speed;
    [SerializeField] float m_damage;
    [SerializeField] GameObject m_gameManager;

    [SerializeField] float m_wall = 1.0f;
    [SerializeField] float m_site = 1.0f;
    [SerializeField] LayerMask m_returnLayer = default;
    [SerializeField] LayerMask m_groundLayer = default;
    [SerializeField] bool m_layLog = false;
    [SerializeField] public Vector2 m_dir = Vector2.right;

    public Rigidbody2D m_rb = default;

    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_layLog)
        {
            Patrol();
        }
    }

    public void attack()
    {
        SeeSlider ss = m_gameManager.GetComponent<SeeSlider>();
        ss.Addhp(m_damage);
    }

    public bool Patrol()
    {
        bool isPatrol = Physics2D.Raycast(transform.position, m_dir, m_wall, m_returnLayer);
        Debug.DrawRay(transform.position, m_dir * m_site, Color.white);

        if (isPatrol)
        {
            m_dir *= -1;
            transform.Rotate(0, transform.rotation.y + 180, 0);
        }

        return isPatrol;
    }
}