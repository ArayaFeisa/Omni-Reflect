using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossChasing : MonoBehaviour
{
    [SerializeField] private BossArriving[] enemyArray;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")){
            foreach (BossArriving enemy in enemyArray)
            {
                enemy.chase = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Player")){
            foreach (BossArriving enemy in enemyArray)
            {
                enemy.chase = false;
            }
        }
    }
}
