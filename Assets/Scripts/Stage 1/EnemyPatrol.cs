// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class EnemyPatrol : MonoBehaviour
// {
//     [Header ("Patrol Points")]
//     [SerializeField] private Transform leftEdge;
//     [SerializeField] private Transform rightEdge;

//     [Header ("Enemy")]
//     [SerializeField] private Transform enemy;

//     [Header ("Movement")]
//     [SerializeField] private float speed;
//     private float delayTime = 1f;
//     private Vector3 initScale;
//     private bool movingLeft;
//     private Animator enemyAnim;

//     private void Awake() {
//         initScale = enemy.localScale;
//         enemyAnim = enemy.GetComponentInChildren<Animator>();
//     }
//     private void Update() {
//         if (movingLeft){
//             if (enemy.position.x >= leftEdge.position.x){
//                 MoveInDirection(-1);
//             } else {
//                 // DirectionChange();
//                 StartCoroutine(WaitBeforeDirectionChange());
//             }
//         } else {
//             if (enemy.position.x <= rightEdge.position.x){
//                 MoveInDirection(1);
//             } else {
//                 // DirectionChange();
//                 StartCoroutine(WaitBeforeDirectionChange());
//             }
//         }
//     }
//     private void DirectionChange(){
//         movingLeft = !movingLeft;
//     }
//     private void MoveInDirection(int _direction){

//         enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction, 
//             initScale.y, initScale.z);

//         enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed,
//             enemy.position.y, enemy.position.z);
//     }

//     private IEnumerator WaitBeforeDirectionChange(){
//         if (enemyAnim != null)
//         {
//             enemyAnim.SetBool("idling", true); // Set the idle animation
//         }

//         yield return new WaitForSeconds(delayTime); // Wait for the specified delay time

//         if (enemyAnim != null)
//         {
//             enemyAnim.SetBool("idling", false); // Reset the idle animation
//         }
//         DirectionChange();
//     }
// }


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header ("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header ("Enemy")]
    [SerializeField] private Transform enemy;

    [Header ("Movement")]
    [SerializeField] private float speed;
    [SerializeField] private float delayTime;
    private Vector3 initScale;
    private bool movingLeft;
    private Animator enemyAnim;
    private bool isWaiting;  // New flag to check if the enemy is waiting

    private void Awake() {
        initScale = enemy.localScale;
        enemyAnim = enemy.GetComponentInChildren<Animator>();
    }

    private void Update() {
        if (isWaiting) return; // Skip the update if the enemy is waiting

        if (movingLeft) {
            if (enemy.position.x >= leftEdge.position.x) {
                MoveInDirection(-1);
            } else {
                StartCoroutine(WaitBeforeDirectionChange());
            }
        } else {
            if (enemy.position.x <= rightEdge.position.x) {
                MoveInDirection(1);
            } else {
                StartCoroutine(WaitBeforeDirectionChange());
            }
        }
    }

    private void DirectionChange() {
        movingLeft = !movingLeft;
    }

    private void MoveInDirection(int _direction) {
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction, 
            initScale.y, initScale.z);

        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed,
            enemy.position.y, enemy.position.z);
    }

    private IEnumerator WaitBeforeDirectionChange() {
        isWaiting = true; // Set waiting flag to true to prevent multiple coroutines

        if (enemyAnim != null) {
            enemyAnim.SetBool("idling", true); // Set the idle animation
        }

        yield return new WaitForSeconds(delayTime); // Wait for the specified delay time

        if (enemyAnim != null) {
            enemyAnim.SetBool("idling", false); // Reset the idle animation
        }

        DirectionChange();
        isWaiting = false; // Reset waiting flag after waiting
    }
}
