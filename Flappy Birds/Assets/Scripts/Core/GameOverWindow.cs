using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverWindow : MonoBehaviour {

	public GameObject content;
	public Text textScore;
	public Text textBest;

	private AudioSource audioSource;

	void Awake() {
		audioSource = GetComponent<AudioSource>();
		Hide();
	}

	public void Show() {
		audioSource.Play ();
		content.SetActive(true);
	}

	public void Hide() {
		content.SetActive(false);
	}

	public void UpdateContent() {
		textScore.text = GameManager.instance.score.ToString("000");
		textBest.text = PlayerPrefs.GetInt("bestScore").ToString ("000");
	}

	public void OnButtonReplayClick() {
		StartCoroutine(GameManager.instance.Replay());
		audioSource.Play ();
		Hide();
	}

}
