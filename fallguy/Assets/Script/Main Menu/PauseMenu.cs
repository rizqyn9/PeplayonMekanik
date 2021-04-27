using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject PauseMenuCanvas;

    public GameObject PauseMenuPanel;

    public float TweenTimePauseMenu;
    private bool isPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                Paused();
            }
            else
            {
                Resume();
            }
        }
    }

    private void Paused()
    {
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;

        PauseMenuPanel.SetActive(true);
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        /*PauseMenuPanel.transform.localScale = Vector3.zero;*/
        isPaused = false;
        Time.timeScale = 1f;
        /*  Canvas tt = GetComponent<Canvas>();
          tt.enabled = false;*/

        PauseMenuPanel.SetActive(false);
    }
}