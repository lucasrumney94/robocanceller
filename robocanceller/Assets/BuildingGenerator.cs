using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGenerator : MonoBehaviour {


	public GameObject buildingPrefab;
	public List<float> radii;
	public List<int> BuidlingsPerRing;

	public float heightMultiplier = 2.0f;
	public float heightVariance = 1.0f;


	private Vector3 spawnPosition;
	private GameObject building;
	private GameObject centerBuilding;
	private Vector3 lookPoint;
	private Vector3 workingPosition;
	// Use this for initialization
	void Start () 
	{
		// Center Building is special, last building, spawn separately. 
		centerBuilding = Instantiate(buildingPrefab, Vector3.zero, Quaternion.identity) as GameObject;
		centerBuilding.transform.SetParent(transform);
		lookPoint = centerBuilding.transform.position;

		for (int ring = 0; ring < radii.Count; ring++)
		{
			for (int j = 0; j < BuidlingsPerRing[ring]; j++)
			{
				workingPosition = new Vector3(radii[ring]*Mathf.Cos(Mathf.Deg2Rad*j*360.0f/(BuidlingsPerRing[ring])), 0.0f, radii[ring]*Mathf.Sin(Mathf.Deg2Rad*j*360.0f/(BuidlingsPerRing[ring])));
				//Debug.Log(workingPosition);
				building = Instantiate(buildingPrefab, workingPosition, Quaternion.identity) as GameObject;
				building.transform.SetParent(transform);
				building.transform.position += -Vector3.up*heightMultiplier*radii[ring] + Vector3.up*Random.Range(0,heightVariance);
				//lookPoint = Vector3.zero;
				//building.transform.LookAt(lookPoint);
			}
		}

	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
