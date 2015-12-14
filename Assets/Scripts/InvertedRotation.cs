using UnityEngine;
using System.Collections;

public class InvertedRotation : MonoBehaviour {

	public GameObject OculusEye;
	public bool xInvert, yInvert, zInvert;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//FULL INVERSION
		//this.transform.rotation = Quaternion.Inverse (OculusEye.transform.rotation);

		//SINGLE INVERSION
		if(xInvert&&yInvert&&zInvert)
			this.transform.eulerAngles = new Vector3 (OculusEye.transform.rotation.x*-133.3f, OculusEye.transform.rotation.y*-133.3f, OculusEye.transform.rotation.z*-133.3f);
		if(!xInvert&&yInvert&&zInvert)
			this.transform.eulerAngles = new Vector3 (OculusEye.transform.rotation.x*133.3f, OculusEye.transform.rotation.y*-133.3f, OculusEye.transform.rotation.z*-133.3f);
		if(xInvert&&!yInvert&&zInvert)
			this.transform.eulerAngles = new Vector3 (OculusEye.transform.rotation.x*-133.3f, OculusEye.transform.rotation.y*133.3f, OculusEye.transform.rotation.z*-133.3f);
		if(xInvert&&yInvert&&!zInvert)
			this.transform.eulerAngles = new Vector3 (OculusEye.transform.rotation.x*-133.3f, OculusEye.transform.rotation.y*-133.3f, OculusEye.transform.rotation.z*133.3f);
		if(!xInvert&&!yInvert&&zInvert)
			this.transform.eulerAngles = new Vector3 (OculusEye.transform.rotation.x*133.3f, OculusEye.transform.rotation.y*133.3f, OculusEye.transform.rotation.z*-133.3f);
		if(!xInvert&&yInvert&&!zInvert)
			this.transform.eulerAngles = new Vector3 (OculusEye.transform.rotation.x*133.3f, OculusEye.transform.rotation.y*-133.3f, OculusEye.transform.rotation.z*133.3f);
		if(xInvert&&!yInvert&&!zInvert)
			this.transform.eulerAngles = new Vector3 (OculusEye.transform.rotation.x*-133.3f, OculusEye.transform.rotation.y*133.3f, OculusEye.transform.rotation.z*133.3f);
		if(!xInvert&&!yInvert&&!zInvert)
			this.transform.eulerAngles = new Vector3 (OculusEye.transform.rotation.x*133.3f, OculusEye.transform.rotation.y*133.3f, OculusEye.transform.rotation.z*133.3f);
		//NOTE: While functional, the value has a difference of 1/133.333~. Unsure why. Multiplying input value by 133.3 to fix.
	}
}
