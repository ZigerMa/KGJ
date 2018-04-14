using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameTask : MonoBehaviour {

    public Transform[] address;

    bool isStart = false;

    // Use this for initialization
	void Start () {

        StartCoroutine(StartShowRandomChild());
        InvokeRepeating ("setBarrack",1,3f); 
	}

	private void Update()
	{
        
	}

    IEnumerator  StartShowRandomChild()
    {
        Debug.Log("StartShowRandomChild");

        yield return new WaitUntil(() => { return Services.Get<ChildManager>().GetChildObjBool(); });

        Debug.Log("child pool 預載好了");

        GameObject child = Services.Get<ChildManager>().GetChildObj();


        Instantiate(child, new Vector3(Random.Range(-5.5f, 5.5f), Random.Range(-5.5f, 5.5f), Random.Range(-5.5f, 5.5f)), Quaternion.identity);
    }

    void setBarrack(){  
        Transform tf = address [Random.Range (0, address.Length)];  
        Bound bound = getBound (tf);  
        Vector3 pos = new Vector3 (bound.getRandomX(),bound.y,bound.getRandomZ());  
        GameObject child = Services.Get<ChildManager>().GetChildObj();
        Instantiate (child,pos,Quaternion.identity); 
    } 

    Bound getBound(Transform tf){  
        Vector3 center = tf.GetComponent<Collider>().bounds.center;  
        Vector3 extents = tf.GetComponent<Collider>().bounds.extents;  
        Vector3 dL = new Vector3 (center.x - extents.x,center.y,center.z - extents.z);  
        Vector3 dR = new Vector3 (center.x + extents.x,center.y,center.z - extents.z);  
        Vector3 sR = new Vector3 (center.x + extents.x,center.y,center.z + extents.z);  
        Vector3 sL = new Vector3 (center.x - extents.x,center.y,center.z + extents.z);  
        Bound bound = new Bound (dL,dR,sR,sL,center.y);  
  
  
        return bound;  
    }


    class Bound
    {
        public Vector3 dL;
        public Vector3 dR;
        public Vector3 sR;
        public Vector3 sL;
        public float y;


        public Bound(Vector3 dL, Vector3 dR, Vector3 sR, Vector3 sL, float y)
        {
            this.dL = dL;
            this.dR = dR;
            this.sR = sR;
            this.sL = sL;
            this.y = y;
        }




        public float getRandomX()
        {
            float num = Random.Range(dL.x, dR.x);
            return num;
        }
          public float getRandomZ(){  
            float num = Random.Range (dL.z,sL.z);  
            return num;  
        } 
    }
}
