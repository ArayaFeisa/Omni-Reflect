using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lvl3FinishPortalScript : MonoBehaviour
{
    [SerializeField] private AudioClip completeSound;
    public Transform playerPos;
    private bool inPortal;
    public CinemachineVirtualCamera vcam;
    void Start()
    {
        inPortal = false;
    }
    private void Awake()
    {
        inPortal = false;
        StartCoroutine(zoomOut());
    }
    // Update is called once per frame
    void Update()
    {
        if (inPortal && Input.GetKeyDown(KeyCode.Q))
        {
            SoundManager.instance.PlaySound(completeSound);
            reenter();
        }
    }

    private void reenter()
    {
        StartCoroutine(zoomIn());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inPortal = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        inPortal = false;
    }

    private IEnumerator zoomOut()
    {
        vcam.m_Lens.OrthographicSize = 0.1f;
        for (int i = 0; i < 66; i++)
        {
            vcam.m_Lens.OrthographicSize = vcam.m_Lens.OrthographicSize + 0.1f;
            yield return new WaitForSeconds(0.015f);
        }
    }

    private IEnumerator zoomIn()
    {
        for (int i = 0; i < 66; i++)
        {
            vcam.m_Lens.OrthographicSize = vcam.m_Lens.OrthographicSize - 0.1f;
            yield return new WaitForSeconds(0.015f);
        }
        SceneManager.LoadScene("Selector");
        playerPos.transform.position = new Vector2(-19, -3);
    }
}
