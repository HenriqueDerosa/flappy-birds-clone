using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {

	public bool caught = false;

	private AudioSource audioSource;

	void Awake () {
		caught = false;
		audioSource = GetComponent<AudioSource>();
	}

	void OnTriggerEnter2D(Collider2D collider2D) {
		if (collider2D.CompareTag("Player") && !caught) {
			caught = true;
			GameManager.instance.AddScore(1);
			audioSource.Play ();
		}
	}



}
