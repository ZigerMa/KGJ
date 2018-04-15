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
        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        //Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        //rb.AddForce(movement * speed);
    }



}
