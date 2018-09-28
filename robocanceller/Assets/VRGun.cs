using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRGun : MonoBehaviour {

	public GameObject CameraRig;
	public GameObject bulletPrefab;
	public GameObject bulletSpawnPoint;
	public float fireT = 0.2f;

	private float lastFireTime;


	private SteamVR_TrackedObject trackedObj;
	private SteamVR_LaserPointer myLaser;

	private building myBuilding;

	private SteamVR_Controller.Device Controller
	{
		get {return SteamVR_Controller.Input((int)trackedObj.index); }
	}


	void Awake()
	{
		trackedObj = GetComponentInParent<SteamVR_TrackedObject>();
		myLaser = GetComponentInParent<SteamVR_LaserPointer>();
		myLaser.PointerIn -= HandlePointerIn;
        myLaser.PointerIn += HandlePointerIn;
        myLaser.PointerOut -= HandlePointerOut;
        myLaser.PointerOut += HandlePointerOut;

		myBuilding = null;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Controller.GetHairTriggerDown())
		{
			fire();
		}
		if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
		{
			Debug.Log("Grip Pressed");
			
			myLaser.thickness = 0.01f;

		}
		else if (Controller.GetPressUp(SteamVR_Controller.ButtonMask.Grip))
		{
			if (myBuilding != null)
			{
				Debug.Log("Building is not null, setting CameraRig Position");
				CameraRig.transform.position = myBuilding.playerTeleportPosition.transform.position;
				CameraRig.transform.rotation = myBuilding.playerTeleportPosition.transform.rotation;
				Controller.TriggerHapticPulse(1000);
			}
			myLaser.thickness = 0.0f;
		}


	}

	private void HandlePointerIn(object sender, PointerEventArgs e)
    {
		//Debug.Log("Point in event");
		myBuilding = e.target.GetComponent<building>();		
    }

	private void HandlePointerOut(object sender, PointerEventArgs e)
    {
		//Debug.Log("Point out event");
		myBuilding = null;
	}

	void fire()
	{
		//if (Time.time-lastFireTime > fireT)
		//{
			Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
			Controller.TriggerHapticPulse(2000);

			lastFireTime = Time.time;
		//}
	}

}
