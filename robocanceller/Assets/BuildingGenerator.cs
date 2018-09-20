using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGenerator : MonoBehaviour {

	public GameObject buildingPrefab;
	public int numberOfBuildings = 10;
	public float radius = 5.0f;
	public float heightVariance = 3.0f;
	public float spacing = 0.05f;



	private Vector3 spawnPosition;
	private GameObject building;
	private GameObject centerBuilding;
	// Use this for initialization
	void Start () 
	{

		centerBuilding = Instantiate(buildingPrefab, Vector3.zero, Quaternion.identity) as GameObject;

		for (int i = 0; i < numberOfBuildings; i++)
		{
			spawnPosition.x = i*radius*Mathf.Sin(i*spacing);
			spawnPosition.z = i*radius*Mathf.Cos(i*spacing);
			spawnPosition.y = 1/Vector3.Distance(centerBuilding.transform.position,spawnPosition) + Random.Range(-heightVariance, heightVariance);
			building = Instantiate(buildingPrefab, spawnPosition, Quaternion.identity) as GameObject;

		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
