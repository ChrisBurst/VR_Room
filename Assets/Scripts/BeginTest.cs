using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;

//Main code for VR_Room
public class BeginTest : MonoBehaviour {
	
	float timer=0;
	float subTimer=0;
	public GameObject Blindfold;
	public GameObject Findable;
	public GameObject NoteLookForward;
	public GameObject MiddleOculus;
	public GameObject CameraRig;
	public GameObject crosshair;
	public GameObject crosshairVisual;
	public GameObject North, South, East, West, Floor, Ceiling;
	public GameObject OffsetScreen;
	public GameObject OffsetCamera;
	GameObject World;
	string state = "preview";
	float x, y, z;
	public int ResetVersion;
	public string[] list;
	int arrayPos=0;
	int counter;
	bool dataLoaded;
	public Material[] MList;
	int newFileNum=1;
	
	// Use this for initialization
	void Start () {

		//Check if file exists and rename
		while(File.Exists ("output ("+newFileNum+").csv")){
			newFileNum++;
		}
		using(StreamWriter writer = File.CreateText("output ("+newFileNum+").csv")){
			writer.WriteLine("Time,XRotation,YRotation,ZRotation,XPosition,YPosition,ZPosition");
		}

		//Outdated code
		NoteLookForward.SetActive (false); 
		Blindfold.SetActive (false); 
		//Findable.SetActive (false); //Should be visible all times
		World = GameObject.Find ("World");
		crosshair.GetComponent<Renderer>().enabled=false;
		//Debug.Log ("In Preview State");
	}
	
	// Update is called once per frame
	void Update () {

		//Record Oculus Position
		x=MiddleOculus.transform.rotation.x;//-World.transform.rotation.x;
		y=MiddleOculus.transform.rotation.y;//-World.transform.rotation.y;
		z=MiddleOculus.transform.rotation.z;//-World.transform.rotation.z;
		using (StreamWriter writer = File.AppendText("output ("+newFileNum+").csv")) {
			StringBuilder sb = new StringBuilder ();
			sb.Append (timer + "," + x + "," + y+ "," + z+","+MiddleOculus.transform.position.x+","+MiddleOculus.transform.position.y+","+MiddleOculus.transform.position.z);
			writer.WriteLine (sb.ToString ());
		}

		//Load new scene
		if(!dataLoaded){
			Debug.Log(arrayPos);
			//Get data for this section

			//Position Camera
			CameraRig.transform.position = new Vector3(float.Parse (list[arrayPos]),float.Parse (list[arrayPos+1]),float.Parse (list[arrayPos+2]));
			CameraRig.transform.eulerAngles = new Vector3 (float.Parse (list[arrayPos+3]),float.Parse (list[arrayPos+4]),float.Parse (list[arrayPos+5]));

			//Position Findable
			Findable.transform.position = new Vector3(float.Parse (list[arrayPos+6]),float.Parse (list[arrayPos+7]),float.Parse (list[arrayPos+8]));
			Findable.transform.eulerAngles = new Vector3 (float.Parse (list[arrayPos+9]),float.Parse (list[arrayPos+10]),float.Parse (list[arrayPos+11]));

			//Paint the room
			Floor.GetComponent<Renderer> ().material = MList [int.Parse (list[arrayPos+12])];
			Ceiling.GetComponent<Renderer> ().material = MList [int.Parse (list[arrayPos+13])];
			North.GetComponentInChildren<Renderer> ().material = MList [int.Parse (list[arrayPos+14])];
			South.GetComponentInChildren<Renderer> ().material = MList [int.Parse (list[arrayPos+14])];
			East.GetComponentInChildren<Renderer> ().material = MList [int.Parse (list[arrayPos+14])];
			West.GetComponentInChildren<Renderer> ().material = MList [int.Parse (list[arrayPos+14])];

			//Rotation of wall hinges. NS rotate along X, EW rotate along Z.
			North.transform.eulerAngles = new Vector3(float.Parse (list[arrayPos+15]),0,0);
			South.transform.eulerAngles = new Vector3(-float.Parse (list[arrayPos+15]),0,0);
			East.transform.eulerAngles = new Vector3(0,0,-float.Parse (list[arrayPos+15]));
			West.transform.eulerAngles = new Vector3(0,0,float.Parse (list[arrayPos+15]));

			//If the room becomes a flat plane (wall angle = 90) the ceiling should vanish
			if(float.Parse (list[arrayPos+15])==90)
				Ceiling.SetActive(false);
			else
				Ceiling.SetActive(true);

			//Is Offset Camera Active?
			if(bool.Parse(list[arrayPos+16])){
				OffsetScreen.SetActive(true);
			}else
				OffsetScreen.SetActive(false);

			//Position Offset Camera
			OffsetCamera.transform.parent.transform.position = new Vector3(float.Parse (list[arrayPos+17]),float.Parse (list[arrayPos+18]),float.Parse (list[arrayPos+19]));
			OffsetCamera.transform.parent.transform.eulerAngles = new Vector3 (float.Parse (list[arrayPos+20]),float.Parse (list[arrayPos+21]),float.Parse (list[arrayPos+22]));
			//Cannot directly alter angles of oculus-controlled camera so the parent is rotated.

			//SetInversions
			OffsetCamera.GetComponent<InvertedRotation>().xInvert = bool.Parse(list[arrayPos+23]);
			OffsetCamera.GetComponent<InvertedRotation>().yInvert = bool.Parse(list[arrayPos+24]);
			OffsetCamera.GetComponent<InvertedRotation>().zInvert = bool.Parse(list[arrayPos+25]);

			arrayPos+=26;
			dataLoaded=true;
		}
			
		/*if(ResetVersion==1){
			crosshairVisual.GetComponent<Renderer>().enabled=true;
			if(crosshair.GetComponent<CrosshairCheck>().isLookedAt){
				state="search";
				subTimer=0;
				crosshairVisual.GetComponent<Renderer>().enabled=false;
				Debug.Log("Entering Search Mode");
			}
		}else{
			Blindfold.SetActive (true);
			NoteLookForward.SetActive(true);
			if (Input.anyKeyDown){
				state = "search";
				//OVRDevice.ResetOrientation(0); //Failed
				World.transform.rotation = MiddleOculus.transform.rotation;
				subTimer=0;
			}
		}*/

		timer += Time.deltaTime;
		subTimer += Time.deltaTime;
		
		//if(Input.GetKey(KeyCode.Escape)) //This code moved elsewhere
		//	Application.Quit();
		if (Input.GetKeyDown (KeyCode.Space)){
			dataLoaded = false;
			using (StreamWriter writer = File.AppendText("output ("+newFileNum+").csv")) {
				writer.WriteLine("Building new room if data available");
			}
		}
	}
}
