// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class BossArriving : MonoBehaviour
// {
//     [SerializeField] private float speed;
//     private GameObject player;
//     public bool chase = false;
//     [SerializeField] private Transform enemy;
//     private Transform enemyInitial;

//     private void Start() {
//         enemyInitial = enemy; //store the position from the initial start
//         player = GameObject.FindGameObjectWithTag("Player");
//     }

//     private void Update() {
//         if (player == null)
//         return;
//         if (!chase){
//             // keep staying still or back to the initial position when the game start
//         } else {
//             Chase();
//         }
//     }

//     private void Chase(){
//         transform.position = player.transform.position;
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossArriving : MonoBehaviour
{
    [SerializeField] private float speed; // Speed to return to initial position
    private GameObject player;
    public bool chase = false; // Set this to true or false based on your detection script
    [SerializeField] private Transform enemy;
    private Vector3 enemyInitialPosition; // Store the initial position of the enemy

    private void Start() {
        enemyInitialPosition = enemy.position; // Store the initial position at the start of the game
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update() {
        if (player == null)
            return;

        if (chase) {
            Chase();
        } else {
            ReturnToInitialPosition();
        }
    }

    private void Chase() {
        transform.position = player.transform.position;
    }

    private void ReturnToInitialPosition() {
        transform.position = enemyInitialPosition;
    }
}
