﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{

    public bool isTitleScreen;
    public GameObject pausePanel;
    public GameObject inGamePanel;
    public GameManager GM;
    public GameObject winPanel;
    public GameObject lostPanel;

    [Header("In Game UI")]
    public Image seed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Pause(bool pause)
    {
        if (pausePanel != null)
        {
            pausePanel.SetActive(pause);
            inGamePanel.SetActive(!pause);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}