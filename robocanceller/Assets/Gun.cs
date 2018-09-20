using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

	public GameObject bulletPrefab;
	public GameObject bulletSpawnPoint;
	public float fireT = 0.2f;

	private float lastFireTime;
	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		 if (Input.GetMouseButton(0))
		 {
			 fire();
		 }

	}

	void fire()
	{
		if (Time.time-lastFireTime > fireT)
		{
			Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
			lastFireTime = Time.time;
		}
	}

}
