using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePoint : MonoBehaviour {
	public GameObject Right;
	public GameObject Left;
	public LineRenderer Line;
	public GameObject RightRay;
	public GameObject LeftRay;
	public bool isBase;
    public Hentai_Move move;

	void Start()
	{
        move = GameObject.Find("Billy").GetComponent<Hentai_Move>();
		Line.transform.position = Vector3.zero;
	}

	void Update()
	{
		if (Right != null) 
		{
			if (Right.transform.name == "Point(Clone)" || isBase) 
			{
				Line.SetPosition (0, Right.transform.position);
			}
			else
			{
				Line.SetPosition (0, transform.position);
			}
			RightRay.transform.LookAt (Right.transform);
		}
		if (Left != null) 
		{
			if (Left.transform.name == "Point(Clone)" || isBase) 
			{
				Line.SetPosition (2, Left.transform.position);
			} 
			else 
			{
				Line.SetPosition (2, transform.position);
			}
			LeftRay.transform.LookAt (Left.transform);
		}
		Line.SetPosition (1, transform.position);
	}
	void FixedUpdate()
	{
		RaycastHit Righthit;
		// Does the ray intersect any objects excluding the player layer
		if (Physics.Raycast(transform.position, RightRay.transform.forward, out Righthit, Mathf.Infinity))
		{
			if (Righthit.transform.name == "Billy") 
			{
				if (Right.GetComponent<MovePoint> ().Left.GetComponent<MovePoint> ().isBase == false && Right.GetComponent<MovePoint> ().isBase == false) 
				{
					Destroy (Right.GetComponent<MovePoint>().Left);
					Destroy (Right);
                    move._Ismove = false;
					//Do Something.
				}
			}
			if (Righthit.transform.name == "Police") 
			{
				if (Righthit.transform.gameObject.GetComponent<PoliceMove> ().Left == null) 
				{
					Righthit.transform.gameObject.GetComponent<PoliceMove> ().Left = gameObject;
				}
			}
			if (Right == null && Righthit.transform.tag == "MovePoint") 
			{
				Right = Righthit.transform.gameObject;
			}
		}
		RaycastHit Lefthit;
		// Does the ray intersect any objects excluding the player layer
		if (Physics.Raycast(transform.position, LeftRay.transform.forward, out Lefthit, Mathf.Infinity))
		{
			if (Lefthit.transform.name == "Police") 
			{
				if (Lefthit.transform.gameObject.GetComponent<PoliceMove> ().Right == null) 
				{
					Lefthit.transform.gameObject.GetComponent<PoliceMove> ().Right = gameObject;
				}
			}
			if (Left == null && Lefthit.transform.tag == "MovePoint") 
			{
				Left = Lefthit.transform.gameObject;
			}
		}
	}
}
