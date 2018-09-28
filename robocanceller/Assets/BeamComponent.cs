using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamComponent : MonoBehaviour {

	//public float propagationSpeed = 0.01f;
	public float firingRange = 100.0f;

	public bool activated = false;
	private bool keepPropagating = true;

	private Vector3 FiringPosition;

	private Vector3 ToHitPoint;
	// Use this for initialization
	void Start () 
	{
		FiringPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(activated)
		{
			RaycastHit hit;
			if (Physics.Raycast(FiringPosition, Vector3.forward, out hit, firingRange))
			{
				if (hit.collider)
				{
 					ToHitPoint = hit.transform.position-FiringPosition;
					transform.position = FiringPosition+ToHitPoint*0.5f;
					transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, ToHitPoint.magnitude);
				}
			}
			else
			{
				ToHitPoint = Vector3.forward*firingRange;
				transform.position = FiringPosition+ToHitPoint*0.5f;
				transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, ToHitPoint.magnitude);
			}
		}
		
		
	}

	private void OnTriggerEnter(Collider other)
	{
		keepPropagating = false;
	}

	private void OnTriggerExit(Collider other)
	{
		keepPropagating = true;
	}
}
