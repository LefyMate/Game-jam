using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    [SerializeField] private GameObject deathPanel;
    [SerializeField] private GameObject winPanel;

    private void Awake()
    {
        if (LevelManager.instance == null) instance = this;
        else Destroy(gameObject);
    }

    public void GameOver()
    {
        deathPanel.SetActive(!deathPanel.activeSelf);
    }

    public void GameWin()
    {
        winPanel.SetActive(!winPanel.activeSelf);
    }
}
