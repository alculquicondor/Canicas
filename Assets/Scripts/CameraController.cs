using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;
	public static int gameScore;
	public float speed;

	private float radioOffset, fullOffset, sideAngle, verticalAngle,
		          startingSideAngle, startingMouseX,
	              startingVerticalAngle, startingMouseY;
	private bool movingCamera;

	void Start () {
		Vector3 offset = transform.position - player.transform.position;
		radioOffset = Mathf.Sqrt(offset.x * offset.x + offset.z * offset.z);
		fullOffset = Mathf.Sqrt (radioOffset * radioOffset + offset.y * offset.y);
		sideAngle = Mathf.PI;
		verticalAngle = Mathf.Asin(offset.y / fullOffset);
		gameScore = 0;
		movingCamera = false;
	}

	void Update () {
		if (Input.GetMouseButtonDown(1)) {
			movingCamera = true;
			startingSideAngle = sideAngle;
			startingVerticalAngle = verticalAngle;
			startingMouseX = Input.mousePosition.x;
			startingMouseY = Input.mousePosition.y;
		}
		if (movingCamera) {
			sideAngle = startingSideAngle + (Input.mousePosition.x - startingMouseX) * speed;
			verticalAngle = startingVerticalAngle - (Input.mousePosition.y - startingMouseY) * speed / 2;
		}
		if (movingCamera && Input.GetMouseButtonUp(1)) {
			movingCamera = false;
		}
	}

	void LateUpdate () {
		transform.position = player.transform.position +
			new Vector3(Mathf.Sin (sideAngle) * radioOffset,
			            Mathf.Sin (verticalAngle) * fullOffset,
			            Mathf.Cos (sideAngle) * radioOffset);
		transform.LookAt(player.transform.position);
	}
}
