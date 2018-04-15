using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour 
{
    private static Main s_Instance;

    public static Main Instance
    {
        get
        {
            if (s_Instance == null)
            {
                s_Instance = FindObjectOfType(typeof(Main)) as Main;
                if (s_Instance == null)
                {
                    GameObject go = new GameObject("Main");
                    s_Instance = go.AddComponent<Main>();
                }
            }
            return s_Instance;
        }
    }

    private static bool m_servicesInited = false;
    private MainGameTask m_MainGameTask;
    public Material[] Skyboxes;
    public UIController m_UIController;
    public AudioManager m_AudioManager;


    public Text timerLabel; //#2
    private string timerText; 
    public float temp;

    bool gameOn = true;

    void Start()
    {
        //if (Instance != this) Destroy(this);
        s_Instance = this;
        InitGame();
        RenderSettings.skybox = Skyboxes[0];
        RenderSettings.skybox.SetFloat("_Rotation", 0);
    }

	private void InitGame()
    {
        if (!m_servicesInited)
        {
            Services.Set<EventManager>(new EventManager());
            Services.Set<PoliceManager>(new PoliceManager());
            Services.Set<HentaiManager>(new HentaiManager());
            //Services.Set<ChildManager>(new ChildManager());


            m_servicesInited = true;
        }
        //m_MainGameTask = gameObject.AddComponent<MainGameTask>();
    }

    private void TestMethod()
    {

    }


    void Update()
    {
        if(temp > 0 && gameOn)
        {
            temp -= Time.deltaTime; //#3
            TimeSpan timeSpan = TimeSpan.FromSeconds(temp); //#4

            timerText = string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds); //#5
            timerLabel.text = timerText; //#6 
        }else
        {
            GameOver();
            gameOn = false;
            Debug.Log("遊戲時間到了");
        }
      

    }

    void GameOver()
    {
        Debug.Log("遊戲結束");
        m_UIController.GameOver();
    }

}
