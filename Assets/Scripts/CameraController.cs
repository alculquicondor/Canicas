using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;
	public float speed;

	private float radioOffset, heightOffset, angle;

	void Start () {
		Vector3 offset = transform.position - player.transform.position;
		radioOffset = Mathf.Sqrt(offset.x * offset.x + offset.z * offset.z);
		heightOffset = offset.y;
		angle = Mathf.PI;
	}

	void FixedUpdate() {
		angle += Input.GetAxis ("Horizontal") * speed;
	}
	
	void LateUpdate () {
		transform.position = player.transform.position +
			new Vector3(Mathf.Sin (angle) * radioOffset,
			            heightOffset,
			            Mathf.Cos (angle) * radioOffset);
		transform.LookAt(player.transform.position);
	}
}
