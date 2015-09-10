using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GoalController : MonoBehaviour {

	public Text text;
	public int gameScore;
	public GameObject points;
	public DragAndMove player;

	// Use this for initialization
	void Start () {
		gameScore = 0;
		player = (DragAndMove) FindObjectOfType(typeof(DragAndMove));
	}
	
	void LateUpdate () {
		bool finish = false;
		if (gameScore == points.transform.childCount) {
			text.text = "You win!\n\nPress enter to restart";
			finish = true;
		} else if (!player.trapped) {
			text.text = "Score: " + gameScore.ToString();
		} else {
			text.text = "You loose!\n\nPress enter to restart";
			finish = true;
		}
		if (finish && Input.GetKeyDown (KeyCode.Return)) {
			Application.LoadLevel(0);
		}
	}
}
