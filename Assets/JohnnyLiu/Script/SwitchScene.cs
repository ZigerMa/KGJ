using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour {

	/// <summary>
	/// 這是2018 KusoGameJam 第五組跟第九組的程式碼 嚴禁盜用！！！！！
	/// </summary> 
	public void Switch(string SceneName)
	{
		SceneManager.LoadScene (SceneName);
	}
}
