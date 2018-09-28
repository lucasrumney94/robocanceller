using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

	public GameObject axle;
	public GameObject BeamDispenser;

	// Use this for initialization
	void Start () 
	{
		Fire();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void Fire()
	{
		foreach (Transform child in BeamDispenser.transform)
		{
			if (child.CompareTag("BeamComponent"))
			{
				child.gameObject.GetComponent<MeshRenderer>().enabled = true;
				child.gameObject.GetComponent<BeamComponent>().activated = true;
			}
		}	
	}

	void Sweep()
	{

	}
}
