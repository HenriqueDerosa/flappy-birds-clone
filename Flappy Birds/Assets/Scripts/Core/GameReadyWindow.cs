using UnityEngine;
using System.Collections;

public class GameReadyWindow : MonoBehaviour {

	public GameObject content;

	void Awake() {
		Show ();
	}
	
	void Update () {

		if (Input.GetButtonDown("Fire1") && !GameManager.instance.running) {
			Hide();
			GameManager.instance.StartNewGame();
		}
	
	}

	public void Show() {
		content.SetActive(true);
	}
	
	public void Hide() {
		content.SetActive(false);
	}


}
