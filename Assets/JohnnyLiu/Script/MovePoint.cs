using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePoint : MonoBehaviour {
	public GameObject Right;
	public GameObject Left;
	public LineRenderer Line;

	void Start()
	{
		Line.transform.position = Vector3.zero;
	}

	void Update()
	{
		Line.SetPosition (0, Right.transform.position);
		Line.SetPosition (1, transform.position);
		Line.SetPosition (2, Left.transform.position);
	}
}
