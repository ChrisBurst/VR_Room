using UnityEngine;
using System.Collections;

public class RoomMaterial : MonoBehaviour {

	public Material[] MList;
	public GameObject Room;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PaintRoom(int num){
		foreach(Transform child in Room.transform) {
			child.GetComponent<Renderer> ().material = MList [num];			
		}
	}

}
