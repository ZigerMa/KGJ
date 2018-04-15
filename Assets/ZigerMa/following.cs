using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class following : MonoBehaviour
{
    public GameObject move, target;
    private float MoveRotataionSpeed = 5f;
    public Rigidbody rb;
    public float dis;
    public bool _isclose=false;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }



    void FixedUpdate()
    {   //計算兩點距離
        
        dis = Vector3.Distance(move.transform.position, target.transform.position);
        
        if (dis < 6)
        {
            _isclose = true;
            
        }
        if(dis <2 )
        {  //夠接近時停止跟蹤
            _isclose = false;
        }
        if (_isclose == true)
        {   //轉向移動
            Quaternion MoveRotation = Quaternion.LookRotation(target.transform.position - move.transform.position, Vector3.up);//
         
            move.transform.rotation = Quaternion.Slerp(move.transform.rotation, MoveRotation, Time.deltaTime * MoveRotataionSpeed);
            move.transform.rotation = MoveRotation;
            transform.position += transform.forward * MoveRotataionSpeed * Time.deltaTime;
           
            //Quaternion MoveRotation = Quaternion.LookRotation(target.transform.position - move.transform.position, Vector3.up);//視差向量
            //move.transform.rotation = Quaternion.Slerp(move.transform.rotation, MoveRotation, Time.deltaTime * MoveRotataionSpeed);//轉向視差向量
            //rb.AddForce(transform.forward * MoveRotataionSpeed * Time.deltaTime);
        }
    }

}

