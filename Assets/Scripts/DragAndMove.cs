using UnityEngine;
using System.Collections;

public class DragAndMove : MonoBehaviour {

	public float radius;
	public bool trapped;

	private RaycastHit rayHitStart;
	private RaycastHit rayHitEnd;
	private Rigidbody rb;

	public float speed;

	void Start () {
		rb = GetComponent<Rigidbody>();
		trapped = false;
	}

	void OnMouseDown(){
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Physics.Raycast (ray.origin, ray.direction, out rayHitStart);
		rb.useGravity = false;
	}
	void OnMouseDrag(){
		transform.position = new Vector3 (
			transform.position.x,
			transform.position.y + 0.01f,
			transform.position.z);
	}

	void OnMouseUp(){
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		bool hit = Physics.Raycast (ray.origin, ray.direction, out rayHitEnd);
		rb.useGravity = true;
		if (hit) {
			Vector3 movement = new Vector3(
				rayHitStart.point.x - rayHitEnd.point.x,
				0,
				rayHitStart.point.z - rayHitEnd.point.z);
			
			rb.AddForce(movement * speed);

		}
	}

	void LateUpdate () {
		if (Vector3.Magnitude(transform.position) < radius &&
		    Vector3.Magnitude(rb.velocity) < 1f) {
			trapped = true;
		}
	}
}
