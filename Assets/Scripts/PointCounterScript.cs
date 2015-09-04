using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PointCounterScript : MonoBehaviour {

	public Text scoreText;
	private bool counted;
	public static int gameScore;
	public float pointRadius;

	// Use this for initialization
	void Start () {
		counted = false;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		float dist = Vector3.Distance (new Vector3 (0, 0, 0), transform.position);
		if(!counted){
			Debug.Log (dist);
			if(dist > pointRadius){
				gameScore = gameScore + 1;
				UpdateScore();
				counted = true;
			}
		} 
	}
	void UpdateScore(){
		scoreText.text = "Score: " + gameScore.ToString ();
	}
}
