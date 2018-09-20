using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class building : MonoBehaviour {

	public GameObject EnemyPrefab;
	public bool spawnEnemies = true;
	public int numberOfEnemies = 3;

	public float buildingTopSize = 3.0f;

	public GameObject BuildingTop;
	public GameObject playerTeleportPosition;


	// Use this for initialization
	void Start () 
	{
		transform.LookAt(new Vector3(0.0f, transform.position.y, 0.0f));

		if (spawnEnemies)
		{
			for (int i = 0; i < numberOfEnemies; i++)
			{
				Instantiate(EnemyPrefab, BuildingTop.transform.position+buildingTopSize*Random.insideUnitSphere+Vector3.up*buildingTopSize, Quaternion.identity);
			}
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
