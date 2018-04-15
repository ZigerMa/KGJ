using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public GameObject GameOverUI;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GameOver()
    {
        if(GameOverUI != null)
        {
            GameOverUI.SetActive(true);
            Main.Instance.m_AudioManager.PlayOneShot("警笛");
            Main.Instance.m_AudioManager.PlayOneShot("母湯歐");
        }
    }
}
