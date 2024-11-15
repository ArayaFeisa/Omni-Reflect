using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class River : MonoBehaviour
{
    [SerializeField] private float damage;
    private Animator anim;

    private void Awake() {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player"){
            collision.GetComponent<Health>().takeDamage(damage);
        }
    }
}
