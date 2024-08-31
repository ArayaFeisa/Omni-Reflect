using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTrap : MonoBehaviour
{
    [SerializeField] private float attackCD;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] lasers;
    private float cooldownTimer;
    private void Attack(){
        cooldownTimer = 0;

        lasers[findLaser()].transform.position = firePoint.position;
        lasers[findLaser()].GetComponent<EnemyProjectile>().ActivateProjectile();
    }

    private int findLaser(){
        for (int i=0; i<lasers.Length; i++){
            if (!lasers[i].activeInHierarchy){
                return i;
            }
        }
        return 0;
    }

    private void Update() {
        cooldownTimer += Time.deltaTime;
        if (cooldownTimer >= attackCD){
            Attack();
        }
    }
}
