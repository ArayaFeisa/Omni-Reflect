using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    private HashSet<GameObject> portalObjects = new HashSet<GameObject>();
    [SerializeField] private Transform destination;
    [SerializeField] private string playerTag = "Player";
    
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag(playerTag))
        {
            return;
        }
        if (portalObjects.Contains(collision.gameObject)){
            return;
        }
        if (destination.TryGetComponent(out Teleporter destinastionPortal)){
            destinastionPortal.portalObjects.Add(collision.gameObject);
        }
        collision.transform.position = destination.position;
    }

    private void OnTriggerExit2D(Collider2D collision) {
        portalObjects.Remove(collision.gameObject);
    }
}

