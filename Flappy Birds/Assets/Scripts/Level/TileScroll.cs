using UnityEngine;
using System.Collections;

public class TileScroll : MonoBehaviour {

    [HideInInspector] public bool canMove = true;
	public float speed = 2f;

	private MeshRenderer meshRenderer;
	
	void Start () {
		meshRenderer = GetComponent<MeshRenderer>();
		meshRenderer.material.mainTextureOffset = new Vector2(0f, 0f);
	}

	void FixedUpdate () {
        if (canMove)
		    meshRenderer.material.mainTextureOffset = new Vector2(Time.time * speed, 0f);
	}
}
