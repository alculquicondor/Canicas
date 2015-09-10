using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;
	public static int gameScore;
	public float speed;

	private float radioOffset, heightOffset, angle,
		          startingAngle, startingMouseX;
	private bool movingCamera;

	void Start () {
		Vector3 offset = transform.position - player.transform.position;
		radioOffset = Mathf.Sqrt(offset.x * offset.x + offset.z * offset.z);
		heightOffset = offset.y;
		angle = Mathf.PI;
		gameScore = 0;
		movingCamera = false;
	}

	void Update () {
		if (Input.GetMouseButtonDown(1)) {
			movingCamera = true;
			startingAngle = angle;
			startingMouseX = Input.mousePosition.x;
		}
		if (movingCamera) {
			angle = startingAngle + (Input.mousePosition.x - startingMouseX) * speed;
		}
		if (movingCamera && Input.GetMouseButtonUp(1)) {
			movingCamera = false;
		}
	}

	void LateUpdate () {
		transform.position = player.transform.position +
			new Vector3(Mathf.Sin (angle) * radioOffset,
			            heightOffset,
			            Mathf.Cos (angle) * radioOffset);
		transform.LookAt(player.transform.position);
	}
}
