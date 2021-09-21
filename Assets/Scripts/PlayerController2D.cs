using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour, IPause
{
    [SerializeField] float m_moveSpeed = 0f;
    float m_mmoveSpeed;
    [SerializeField] float m_jump = 5f;
    Rigidbody2D m_rb = default;

    /// <summary>接地フラグ</summary>
    [SerializeField] float m_site = 1.0f;
    [SerializeField] LayerMask m_groundLayer = default;
    [SerializeField] bool m_layLog = false;

    Vector2 m_velocity;
    Animator m_anim;
    SpriteRenderer m_sprite;

    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_anim = GetComponent<Animator>();
        m_sprite = GetComponent<SpriteRenderer>();
        m_mmoveSpeed = m_moveSpeed;
    }

    void Update()
    {
        Movement();
        Jumpup();
        if(m_layLog)
        {
            Ground();
        }

        if (m_anim)
        {
            bool isGrounded = Ground();
            m_anim.SetBool("isGrounded", isGrounded);

            if (isGrounded)
            {
                m_anim.SetFloat("RunSpeed", Mathf.Abs(m_rb.velocity.x));
            }
        }
    }

    void Movement()
    {
        float h = Input.GetAxisRaw("Horizontal");
        Vector2 velocity = m_rb.velocity;   // この変数 velocity に速度を計算して、最後に Rigidbody2D.velocity に戻す

        if (h != 0)
        {
            m_sprite.flipX = (h < 0);
            velocity.x = h * m_mmoveSpeed;
        }

        m_rb.velocity = velocity;
    }
    void Jumpup()
    {
        Vector2 velocity = m_rb.velocity;   // この変数 velocity に速度を計算して、最後に Rigidbody2D.velocity に戻す

        if (Input.GetButtonDown("Jump") && Ground())
        {
            velocity.y = m_jump;
        }
        m_rb.velocity = velocity;
    }

    bool Ground()
    {
        bool isGrounded = Physics2D.Raycast(transform.position , Vector2.down ,m_site , m_groundLayer);
        Debug.DrawRay(transform.position, Vector2.down * m_site , Color.red);
        return isGrounded;
    }

    public void Pause()
    {
        m_velocity = m_rb.velocity;
        m_mmoveSpeed = 0f;
        m_rb.Sleep();
        m_rb.simulated = false;
    }

    public void Resume()
    {
        m_rb.simulated = true;
        m_rb.WakeUp();
        m_rb.velocity = m_velocity;
        m_mmoveSpeed = m_moveSpeed;
    }
}


