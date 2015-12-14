using UnityEngine;
using System.Collections;

public class IsBeingLookedAt : MonoBehaviour {

	public bool isLookedAt;

	void OnTriggerStay(){
		isLookedAt = true;
	}
	void OnTriggerExit(){
		isLookedAt = false;
	}
}
