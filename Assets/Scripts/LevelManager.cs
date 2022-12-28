using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    private bool win = false;
    private bool death = false;

    public Transform Player;

    [SerializeField] private GameObject deathPanel;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject pausePanel;

    private void Awake()
    {
        if (LevelManager.instance == null) instance = this;
        else Destroy(gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GamePause();
        }
    }

    public void GameOver()
    {
        deathPanel.SetActive(!deathPanel.activeSelf);
        Player.gameObject.SetActive(false);
        death = !death;
        if (deathPanel.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void GameWin()
    {
        winPanel.SetActive(!winPanel.activeSelf);
        Player.gameObject.SetActive(false);
        win = !win;
        if (winPanel.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void GamePause()
    {
        if (!win && !death)
        {
            pausePanel.SetActive(!pausePanel.activeSelf);
            if (pausePanel.activeSelf)
            {
                Player.gameObject.SetActive(false);
                Time.timeScale = 0f;
            }
            else
            {
                Player.gameObject.SetActive(true);
                Time.timeScale = 1f;
            }
        }
    }
}
