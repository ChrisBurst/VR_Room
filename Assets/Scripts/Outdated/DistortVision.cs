using UnityEngine;
using System.Collections;

public class DistortVision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			this.transform.Rotate (0, 10, 0);
			//this.transform.Translate (5, 0, 0);
		}
	}
}
