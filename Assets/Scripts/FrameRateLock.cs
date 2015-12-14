using UnityEngine;
using System.Collections;

public class FrameRateLock : MonoBehaviour {

	public int frameRate=1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Application.targetFrameRate = frameRate;	
		//transform.Rotate (new Vector3 (0f, 10f * Time.deltaTime, 0f));
	}
}
