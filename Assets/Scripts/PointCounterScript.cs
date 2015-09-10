using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PointCounterScript : MonoBehaviour {

	public float pointRadius;

	private GoalController goal;
	private bool counted;

	// Use this for initialization
	void Start () {
		counted = false;
		goal = (GoalController) FindObjectOfType(typeof(GoalController));
	}
	
	// Update is called once per frame
	void LateUpdate () {
		float dist = Vector3.Distance (new Vector3 (0, 0, 0), transform.position);
		if(!counted){
			if(dist > pointRadius){
				goal.gameScore += 1;
				counted = true;
			}
		} 
	}
}
