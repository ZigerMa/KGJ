using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kid_Move : MonoBehaviour {

    public GameObject kid;
    public Transform pos;
    public int x,z,y;



    public void FixedUpdate()
    {
        y = Random.Range(-1, 100);
        if (y % 17 == 0)
        {

            x = Random.Range(-1, 2);
            z = Random.Range(-1, 2);
            kid.transform.position += new Vector3(x, 0, z);
        }
    }
}
