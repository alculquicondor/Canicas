using UnityEngine;
using System.Collections;

public class ChangeCameras : MonoBehaviour {

	public Camera topCam;
	public float radius;
	private bool inside;
	// Use this for initialization
	void Start () {
		inside = false;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		float dist = Vector3.Distance (new Vector3 (0, 0, 0), transform.position);
		if ((!inside) && (dist < radius)) {
			inside = true;
			topCam.rect = new Rect(0.0f, 0.0f, 1.0f, 1f);
		} else if( inside && dist >= radius){
			inside = false;
			topCam.rect = new Rect(0f, 0f, 0.25f, 0.4f);
;
		}
	}
}
