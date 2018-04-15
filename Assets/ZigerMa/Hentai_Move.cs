using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hentai_Move : MonoBehaviour
{
    //public GameObject hentai;
    public float speed;
    public Rigidbody rb;
    public  bool kid_num;



    




    private void Start()
    {
        rb = GetComponent<Rigidbody>();
       
    }


    public void Update()
    {   //最簡單的GetAxis位移
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }



}
