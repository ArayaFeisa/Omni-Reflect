using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickInPortal : MonoBehaviour
{
    public GameObject inPortal; 
    public GameObject outPortal; 
    private bool isInPortalPlaced = false;
    private bool isOutPortalPlaced = false;

    private void Awake() {
        inPortal.SetActive(false);
        outPortal.SetActive(false);
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            if (!isInPortalPlaced) {
                PlaceInPortal();
            } else {
                CheckPortalClick(inPortal, 0);
            }
        }

        if (Input.GetMouseButtonDown(1)) {
            if (!isOutPortalPlaced) {
                PlaceOutPortal();
            } else {
                CheckPortalClick(outPortal, 1);
            }
        }
    }

    private void PlaceInPortal() {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 0;
        Vector3 inPortalPos = Camera.main.ScreenToWorldPoint(mousePosition);
        inPortalPos.z = 0;

        inPortal.transform.position = inPortalPos;
        inPortal.SetActive(true);

        isInPortalPlaced = true;
    }

    private void PlaceOutPortal() {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 0;
        Vector3 outPortalPos = Camera.main.ScreenToWorldPoint(mousePosition);
        outPortalPos.z = 0;

        outPortal.transform.position = outPortalPos;
        outPortal.SetActive(true);

        isOutPortalPlaced = true;
    }

    private void CheckPortalClick(GameObject portal, int mouseButton) {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

        if (hit.collider != null && hit.collider.gameObject == portal) {
            if (mouseButton == 0) {
                inPortal.SetActive(false);
                isInPortalPlaced = false;
            } else if (mouseButton == 1) {
                outPortal.SetActive(false);
                isOutPortalPlaced = false;
            }
        }
    }
}
