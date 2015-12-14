using UnityEngine;
using System.Collections;

public class CrosshairCheck : MonoBehaviour {

	public bool isLookedAt;
	
	void OnTriggerStay(Collider other){
		if(other.name=="LookTarget")
			isLookedAt = true;
	}
		void OnTriggerExit(Collider other){
		if(other.name=="LookTarget")
			isLookedAt = false;
	}
}
