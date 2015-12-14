using UnityEngine;
using System.Collections;

public class BasicForce : MonoBehaviour {

	Ray ray;
	RaycastHit hit;
	public float forceMultiplier;
	//public float forceAddition;
	public float targetHeight;
	public float baseSpeed;
	public float speed=0;
	public float AccelerationModifier=1;
	bool isActive=false;
	public bool GO;
	public float AirDrag=.1f;
	public float LandDrag=1;
	float joystickValue;
	float weightShiftValue;
	public GameObject Vehicle;
	public Transform LeftTilt;
	public Transform RightTilt;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//Floating
		if (isActive) {
			if (Physics.Raycast (transform.position, Vector3.down, out hit, 100)) {
				this.GetComponent<Rigidbody>().AddForce (Vector3.up * ((forceMultiplier / (hit.distance / 2))));
			}
			if (hit.distance < targetHeight * 2)
				this.GetComponent<Rigidbody>().drag = LandDrag;
			else
				this.GetComponent<Rigidbody>().drag = AirDrag;
		}

		//Propulsion
		if (Input.GetButton("Accel")) {
			//Debug.Log ("Accelerating");
			isActive=true;
			if(GO){
				speed= speed+(AccelerationModifier*Time.deltaTime);
				if (speed > baseSpeed)
					speed = baseSpeed;
			}
		} else {
			//Debug.Log ("Decelerating");
			speed = speed - (Time.deltaTime*AccelerationModifier);
			if (speed <0)
				speed = 0;
		}
		if (GO) {
			if (Input.GetButton("Brake")) {
				speed = speed - (Time.deltaTime * AccelerationModifier);
				if (speed < 0)
					speed = 0;
			}
			this.transform.Translate (0f, 0f, speed * Time.deltaTime);

			//Turn
			joystickValue=Input.GetAxisRaw("Horizontal");
			this.transform.Rotate (0f, joystickValue, 0f);

			//ShiftWeight
			weightShiftValue = Input.GetAxisRaw("ShiftWeight");
			//Debug.Log(weightShiftValue*.5f+.5f);
			this.transform.Translate (weightShiftValue*.25f, 0f, 0f);
			Vehicle.transform.rotation = Quaternion.Slerp(LeftTilt.rotation,RightTilt.rotation,weightShiftValue*.5f+.5f);
		}
	}

	public void GOGOGO(){
		GO = true;
		if (Input.GetButton ("Accel"))
			speed = 25;
	}
}
