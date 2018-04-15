using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildPool : MonoBehaviour {

    private GameObject ChildPrefab;

    public Transform[] spwanPoint;

    public static bool isReady = false;

	void Start () {
        //StartCoroutine(LoadChildPrefab());
    }

    IEnumerator LoadChildPrefab()
    {
        ResourceRequest request = Resources.LoadAsync("Child/ChildObj");
        yield return request;
        Debug.Log("LoadChildPrefab Succeeded");
        //ChildPrefab1 = request.asset as GameObject;
        //ChildPrefab.transform.parent = this.transform;
    }

    public GameObject GetChild()
    {
        Debug.Log("ShowChild");
        return ChildPrefab;
    }
}
