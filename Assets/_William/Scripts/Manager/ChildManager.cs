using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildManager  {

    private GameObject ChildPrefab;
    private ChildPool m_ChildPool;

    public ChildManager()
    {
        Debug.Log("ChildManager");
        m_ChildPool = GameObject.Find("ChildPool").GetComponent<ChildPool>();
        Init();
    }

    private void Init()
    {
        if(m_ChildPool == null)
        {
            Debug.Log("No m_ChildPool");
            return;
        }

    }

    public bool GetChildObjBool()
    {
        if(m_ChildPool.ChildPrefab1 != null)
        {
            return true;
        }
        return false;
    }

    public GameObject GetChildObj()
    {
        return  m_ChildPool.GetChild();
    }

}
