using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	public int score = 0;
	public int bestScore = 0;
	public Text textScore;
    public ObstacleSpawner obstacleSpawner;
	public bool running = false;

	void Awake() {
		instance = this;
    }

	public void StartNewGame() {
		// Variaveis.
		score = 0;
		bestScore = PlayerPrefs.GetInt("bestScore");
		running = true;

        PlayerController.instance.StartGame();
		StartCoroutine(obstacleSpawner.StartCreation());
	}

	public void OnGameOver() {
        obstacleSpawner.Stop();

        foreach (TileScroll ts in FindObjectsOfType<TileScroll>())
            ts.canMove = false;

		StartCoroutine(ShowGameOver ());
	}

	IEnumerator ShowGameOver() {
		yield return new WaitForSeconds(2f);
		bestScore = PlayerPrefs.GetInt("bestScore");
		if (score > bestScore) {
			bestScore = score;
			PlayerPrefs.SetInt("bestScore", score);
		}
		textScore.gameObject.SetActive(false);
		GameObject gameOverWindow = GameObject.FindGameObjectWithTag("GameOverWindow");
		gameOverWindow.GetComponent<GameOverWindow>().Show();
		gameOverWindow.GetComponent<GameOverWindow>().UpdateContent();
	}

	public IEnumerator Replay() {
		yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Game");
	}
	
	public void AddScore(int amount) {
		score += amount;
		textScore.text = score.ToString();
	}

}
