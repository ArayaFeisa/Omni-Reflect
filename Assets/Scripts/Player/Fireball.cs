using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] private float speed;
    public GameObject firebal;
    private float direction;
    private bool hit;
    private BoxCollider2D boxCollider;
    private Animator anim;
    private ParticleSystem em;
    private float lifetime;
    

    private void Awake() {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void Update() {
        if (hit) {
            return;
        }
        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);
        lifetime += Time.deltaTime;
        if (lifetime > 3){
            gameObject.SetActive(false);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Enemy" || collision.tag == "Ground")
        {
            hit = true;
            boxCollider.enabled = false;
            anim.SetTrigger("explode");
            GetComponent<ParticleSystem>().Play();
            ParticleSystem.EmissionModule em = GetComponent<ParticleSystem>().emission;
            em.enabled = true;
        }

        if(collision.tag == "Enemy"){
            collision.GetComponent<Health>().takeDamage(20);
        }
    }
    public void setDirection(float _direction){
        lifetime = 0;
        direction = _direction;

        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != _direction){
            localScaleX = -localScaleX;
        };
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }
    private void deactivate(){
        gameObject.SetActive(false);
    }
}
