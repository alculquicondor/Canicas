using UnityEngine;
using System.Collections;

public class DragAndMove : MonoBehaviour {

	private RaycastHit rayHitStart;
	private RaycastHit rayHitEnd;
	private Rigidbody rb;

	public float speed;

	void Start () {
		rb = GetComponent<Rigidbody>();
	}

	void OnMouseDown(){
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		bool hit = Physics.Raycast (ray.origin, ray.direction, out rayHitStart);
		if (hit) {
			Debug.Log("START:");
			Debug.Log(rayHitStart.point);
		}
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

			Debug.Log("End:");
			Debug.Log(rayHitEnd.point);
			Debug.Log("Movement:");
			Debug.Log(movement);

			
			rb.AddForce(movement * speed);

		}
	}
	void Update () {

	}
}
