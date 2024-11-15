// using System;
// using UnityEngine;

// public class EnemyProjectile : EnemyDamage
// {
//     [SerializeField] private float speed;
//     [SerializeField] private float resetTime;
//     private float lifetime;
//     private Animator anim;
//     private BoxCollider2D coll;

//     private bool hit;

//     private void Awake()
//     {
//         anim = GetComponent<Animator>();
//         coll = GetComponent<BoxCollider2D>();
//     }

//     public void ActivateProjectile()
//     {
//         hit = false;
//         lifetime = 0;
//         gameObject.SetActive(true);
//         coll.enabled = true;
//     }
//     private void Update()
//     {
//         if (hit) return;
//         float movementSpeed = speed * Time.deltaTime;
//         transform.Translate(movementSpeed, 0, 0);

//         lifetime += Time.deltaTime;
//         if (lifetime > resetTime)
//             gameObject.SetActive(false);
//     }

//     private void OnTriggerEnter2D(Collider2D collision)
//     {
//         if (collision.CompareTag("InPortal")){
//             speed = -speed;
//         }
//         if (collision.CompareTag("Player") || collision.CompareTag("Ground"))
//         {
//             hit = true;
//             base.OnTriggerEnter2D(collision);
//             coll.enabled = false;
//             if (anim != null)
//                 anim.SetTrigger("explode");
//             else
//                 gameObject.SetActive(false);
//         }
//     }
//     private void Deactivate()
//     {
//         gameObject.SetActive(false);
//     }
// }

using System;
using UnityEngine;

public class EnemyProjectile : EnemyDamage
{
    [SerializeField] private float speed;
    [SerializeField] private float resetTime;
    
    private float originalSpeed;  // To store the initial speed
    private float lifetime;
    private Animator anim;
    private BoxCollider2D coll;
    private bool hit;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
        originalSpeed = speed;  // Store the initial speed at the start
    }

    public void ActivateProjectile()
    {
        hit = false;
        lifetime = 0;
        gameObject.SetActive(true);
        coll.enabled = true;
        speed = originalSpeed;  // Reset speed to original when activating
    }

    private void Update()
    {
        if (hit) return;
        float movementSpeed = speed * Time.deltaTime;
        transform.Translate(movementSpeed, 0, 0);

        lifetime += Time.deltaTime;
        if (lifetime > resetTime)
            gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("InPortal"))
        {
            speed = -speed;  // Reverse speed upon hitting the "InPortal"
        }

        if (collision.CompareTag("Player") || collision.CompareTag("Enemy") ||collision.CompareTag("Ground"))
        {
            hit = true;
            base.OnTriggerEnter2D(collision);
            coll.enabled = false;

            if (anim != null)
                anim.SetTrigger("explode");
            else
                gameObject.SetActive(false);
        }
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
