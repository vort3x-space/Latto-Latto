using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using GameAnalyticsSDK;


public class GameManager : Singleton<GameManager>
{
    // Start is called before the first frame update
    public TMP_Text Text;
    public TMP_Text stageText;
    public float points;
    public float collisionCount;
    [SerializeField] public GameObject Sun;
    [SerializeField] private GameObject failMenu;
    public Image progressBar;
    public bool gamestart;
    public GameObject ball;
    public GameObject ball2;
    public int stage;
    public GameObject tutorial;
    public TMP_Text ComboText;
    public GameObject ComboObject;
    private bool gameover;

    private void Start()
    {
        gameover = false;
        GameAnalytics.Initialize();
        Time.timeScale = 1f;
        if (SceneManager.GetActiveScene().name == "Main")
        {
            gamestart = false;
            stage = 1;
        }
        else if (SceneManager.GetActiveScene().name == "Init")
        {
            stage = 1;
            Text = null;
            Sun = null;
            failMenu = null;
            progressBar = null;
            gamestart = false;
        }
    }

    private void Update()
    {
        stageText.text = "Stage" + stage.ToString();
        if (progressBar)
        {
            fillProgresbar();
        }

        if (points == 0 && gamestart&&!gameover)
        {
            Failed();
        }
    }

    public void Failed()
    {
        Destroy(Sun);
        failMenu.SetActive(true);
        Taptic.Failure();
        gameover = true;
    }

    public void startGame()
    {
        SceneManager.LoadScene("Main");
    }

    private void fillProgresbar()
    {
        progressBar.fillAmount = Mathf.Clamp(points / 100, 0, 1);
        if (progressBar.fillAmount == 1)
        {
            points = points - 100;
            stage++;
            GameAnalyticsAdaptor.Instance.NewResourceEvent(GAResourceFlowType.Sink, "currency", stage, "stages", "stageID");
            Taptic.Heavy();
            gamestart = false;
            progressBar.fillAmount = 0;
        }
    }

    public void restart()
    {
        SceneManager.LoadScene("Main");
    }
}