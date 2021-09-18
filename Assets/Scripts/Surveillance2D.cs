using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Surveillance2D : MonoBehaviour, IPause
{

    [SerializeField] GameObject m_enemy;
    Vector2 m_velocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMoveController emc = m_enemy.GetComponent<EnemyMoveController>();
        if (emc.Patrol() == false)
        {
            emc.m_rb.velocity = emc.m_dir * emc.m_speed;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        EnemyMoveController emc = m_enemy.GetComponent<EnemyMoveController>();
        if (collision.gameObject.tag == "Player")
        {
            emc.attack();
        }
    }

    public void Pause()
    {
        EnemyMoveController emc = m_enemy.GetComponent<EnemyMoveController>();
        m_velocity = emc.m_rb.velocity;
        emc.m_rb.Sleep();
        emc.m_rb.simulated = false;
    }

    public void Resume()
    {
        EnemyMoveController emc = m_enemy.GetComponent<EnemyMoveController>();
        emc.m_rb.simulated = true;
        emc.m_rb.WakeUp();
        emc.m_rb.velocity = m_velocity;
    }
}
