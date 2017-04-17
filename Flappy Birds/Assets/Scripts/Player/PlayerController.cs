using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public static PlayerController instance;

	public float jumpForce = 100f;
	public float gravity = 0.4f;
	public AudioClip onTapAudio;
	public AudioClip onDeathAudio;

    private bool dead = false;
	private Rigidbody2D rb;
	private AudioSource audioSource;

	void Awake() {
		instance = this;
		dead = false;

        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        audioSource = GetComponent<AudioSource>();
    }
    
	public void StartGame() {
		rb.gravityScale = gravity;
	}

	void Update() {
		if (Input.GetButtonDown("Fire1") && !dead && GameManager.instance.running) {
			OnTap();
		}
	}

	void FixedUpdate () {
		if(rb.velocity.y >= 0) {
			float angle = Mathf.Lerp (0, 90, (rb.velocity.y / 2f) );
			transform.rotation = Quaternion.Euler(0, 0, angle);
		}
		else
		{
			float angle = Mathf.Lerp (0, -90, (-rb.velocity.y / 2f) );
			transform.rotation = Quaternion.Euler(0, 0, angle);
		}
	}
	
	public void OnTap() {
		rb.velocity = Vector2.zero;
		rb.AddForce(Vector2.up * jumpForce);
		audioSource.clip = onTapAudio;
		audioSource.Play ();
	}

	void OnCollisionEnter2D(Collision2D collision2D) {
		if (collision2D.gameObject.tag == "Obstacle" && !dead) {
			OnHit();
		}

	}

	void OnHit() {
		dead = true;
		audioSource.clip = onDeathAudio;
		audioSource.Play ();
		GameManager.instance.OnGameOver();
	}

}
