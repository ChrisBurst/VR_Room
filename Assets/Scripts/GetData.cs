using UnityEngine;
using System.Collections;
using System.IO;

public class GetData: MonoBehaviour {

	string[] list;
	string inputLine;
	public GameObject error;

	// Use this for initialization
	void Start () {
		Debug.Log ("Looking for file");
		if (File.Exists ("input.csv")) {
			Debug.Log("Found File");
			using (StreamReader Reader = File.OpenText("input.csv")) {
				inputLine = Reader.ReadLine ();
			}
			GameObject.Find ("SimController").GetComponent<BeginTest> ().list = inputLine.Split ("," [0]);
		} else {
			Debug.LogError("input.csv not found");
			error.SetActive(true);
		}
	}
}
