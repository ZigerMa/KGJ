using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceMove : MonoBehaviour {
	public List<GameObject> MovePoint;
	public GameObject Left;
	public GameObject Right;
	public float Speed;
	public GameObject Point;
	public GameObject FirstPoint;
	public bool RightSide;

	void Start () {
		
	}

	void Update ()
	{
		if (Input.GetKey (KeyCode.RightArrow)) 
		{
			gameObject.transform.position = Vector3.MoveTowards (gameObject.transform.position, Right.transform.position, Time.deltaTime * Speed);
			RightSide = true;
		}
		if (Input.GetKey (KeyCode.LeftArrow)) 
		{
			gameObject.transform.position = Vector3.MoveTowards (gameObject.transform.position, Left.transform.position, Time.deltaTime * Speed);
			RightSide = false;
		}
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			if (FirstPoint == null)
			{
				GameObject NewPoint = Instantiate (Point, transform.position, transform.rotation);
				NewPoint.GetComponent<MovePoint> ().Right = Right;
				NewPoint.GetComponent<MovePoint> ().Left = Left;
				Left.GetComponent<MovePoint> ().Right = NewPoint;
				Right.GetComponent<MovePoint> ().Left = NewPoint;
				FirstPoint = NewPoint;
			} 
			else 
			{
				GameObject NewPoint = Instantiate (Point, transform.position, transform.rotation);
				NewPoint.GetComponent<MovePoint> ().Right = Right;
				NewPoint.GetComponent<MovePoint> ().Left = Left;
				Left.GetComponent<MovePoint> ().Right = NewPoint;
				Right.GetComponent<MovePoint> ().Left = NewPoint;
				if (!RightSide) 
				{
					FirstPoint.GetComponent<MovePoint> ().Left = NewPoint;
					NewPoint.GetComponent<MovePoint> ().Right = FirstPoint;
					FirstPoint.GetComponent<MovePoint> ().Line.GetComponent<LineRenderer> ().enabled = true;
					NewPoint.GetComponent<MovePoint> ().Line.GetComponent<LineRenderer> ().enabled = true;
					Left = NewPoint;
				}
				else
				{
					FirstPoint.GetComponent<MovePoint> ().Right = NewPoint;
					NewPoint.GetComponent<MovePoint> ().Left = FirstPoint;
					FirstPoint.GetComponent<MovePoint> ().Line.GetComponent<LineRenderer> ().enabled = true;
					NewPoint.GetComponent<MovePoint> ().Line.GetComponent<LineRenderer> ().enabled = true;
					Right = NewPoint;
				}
				FirstPoint = null; 
				//連線
			}
		}
		if (Input.GetKeyDown (KeyCode.C)) 
		{
			FirstPoint.GetComponent<MovePoint> ().Right.GetComponent<MovePoint> ().Left = FirstPoint.GetComponent<MovePoint> ().Left;
			FirstPoint.GetComponent<MovePoint> ().Left.GetComponent<MovePoint> ().Right = FirstPoint.GetComponent<MovePoint> ().Right;
			Destroy (FirstPoint);
			FirstPoint = null;
		}
		if (Right == null) 
		{
			Debug.Log ("RightNull");
		}
		if (Left == null) 
		{
			Debug.Log ("LeftNull");
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "MovePoint") 
		{
			gameObject.transform.position = other.transform.position;
			if (Right == other.gameObject) 
			{
				Left = other.gameObject;
				Right = other.gameObject.GetComponent<MovePoint> ().Right;
			}
			else if (Left == other.gameObject) 
			{
				Right = other.gameObject;
				Left = other.gameObject.GetComponent<MovePoint> ().Left;
			}
		}
	}
}
