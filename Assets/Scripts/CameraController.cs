using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;
	public static int gameScore;

	public float radioOffset, heightOffset, angle;

	void Start () {
		Vector3 offset = transform.position - player.transform.position;
		radioOffset = Mathf.Sqrt(offset.x * offset.x + offset.z * offset.z);
		heightOffset = offset.y;
		angle = Mathf.PI;
		gameScore = 0;
	}

	void FixedUpdate() {
		angle += Input.GetAxis ("Horizontal") * 7e-3f;
	}
	
	void LateUpdate () {
		transform.position = player.transform.position +
			new Vector3(Mathf.Sin (angle) * radioOffset,
			            heightOffset,
			            Mathf.Cos (angle) * radioOffset);
		transform.LookAt(player.transform.position);
	}
}
