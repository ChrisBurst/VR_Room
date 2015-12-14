using UnityEngine;
using System.Collections;

public class CenterVision : MonoBehaviour {

	public void Center(){
		this.transform.LookAt (GameObject.Find ("CenterTarget").transform.position);
	}
}
