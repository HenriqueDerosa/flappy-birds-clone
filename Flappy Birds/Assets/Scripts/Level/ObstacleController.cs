using UnityEngine;
using System.Collections;

public class ObstacleController : MonoBehaviour {

    [HideInInspector] public bool canMove = true;
	public float speed = 1f;
	
	void FixedUpdate () {
        if (canMove)
		    transform.Translate(Vector3.left * speed);

		if (transform.position.x <= -2f) {
			Destroy(gameObject);
		}

	}

}
