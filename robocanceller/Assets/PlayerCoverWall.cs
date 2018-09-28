using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PlayerCoverWall : MonoBehaviour {

    private float playAreaSizeX;
    private float playAreaSizeZ;

	// Use this for initialization
	void Start () 
	{
		ScaleToPlayArea();
	}

	void ScaleToPlayArea()
	{
		var rect = new Valve.VR.HmdQuad_t();
		SteamVR_PlayArea.GetBounds(SteamVR_PlayArea.Size.Calibrated, ref rect);
		transform.localScale = new Vector3(Mathf.Abs(rect.vCorners0.v0 - rect.vCorners2.v0), transform.localScale.y, transform.localScale.z);
	
	}
}
