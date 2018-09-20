using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

	public float speed = 0.5f;
	public float lifeTime = 5.0f;


	private float timeOfBirth;
	// Use this for initialization
	void Start () 
	{
		timeOfBirth = Time.time;
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate(Vector3.forward*speed*Time.deltaTime, Space.Self);

		if (Time.time-timeOfBirth > lifeTime)
		{
			Destroy(gameObject);
		}

	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Enemy"))
		{
			other.gameObject.SendMessage("damage");
		}
	}
}
