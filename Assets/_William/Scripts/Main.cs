using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour 
{
    private static bool m_servicesInited = false;
    private MainGameTask m_MainGameTask;


    void Start()
    {
        InitGame();
    }

	private void InitGame()
    {
        if (!m_servicesInited)
        {
            Services.Set<EventManager>(new EventManager());
            Services.Set<PoliceManager>(new PoliceManager());
            Services.Set<HentaiManager>(new HentaiManager());
            Services.Set<ChildManager>(new ChildManager());


            m_servicesInited = true;
        }
        m_MainGameTask = gameObject.AddComponent<MainGameTask>();
    }

    private void TestMethod()
    {

    }

}
