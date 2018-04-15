using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public GameObject GameOverUI;
    public GameObject GameOverUI2;
    public GameObject GameOverUI3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GameOver()
    {
        Random.seed = System.Guid.NewGuid().GetHashCode();
        int i = Random.Range(0, 10);


        if(GameOverUI != null)
        {
            if(i>5)
            {
                GameOverUI.SetActive(true); 
                Main.Instance.m_AudioManager.PlayOneShot("警笛");
                Main.Instance.m_AudioManager.PlayOneShot("母湯歐");
            }else
            {
                GameOverUI2.SetActive(true);
                Main.Instance.m_AudioManager.PlayOneShot("sexy");
            }
           
        }
    }

    public void TrueEnd()
    {
        Debug.Log("true end");
        GameOverUI3.SetActive(true);
        Main.Instance.m_AudioManager.PlayOneShot("嘿嘿逾期");
    }
}
