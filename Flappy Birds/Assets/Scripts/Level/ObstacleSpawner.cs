using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObstacleSpawner : MonoBehaviour {

	public float timeToStart = 1f;
	public float minTime = 1f;
	public float maxTime = 1.5f;
	public float minY = 1f;
	public float maxY = 2f;
	public GameObject obstaclePrefab;

    public List<GameObject> obstacles;

	public IEnumerator StartCreation() {
		yield return new WaitForSeconds(timeToStart);
		StartCoroutine(CreateObstacle());
	}

    public void Stop()
    {
        StopAllCoroutines();
        foreach (GameObject obs in obstacles)
        {
            if (obs!=null)
                obs.GetComponent<ObstacleController>().canMove = false;
        }
    }

	IEnumerator CreateObstacle() {
        foreach(GameObject obs in obstacles)
            if (obs == null)
                obstacles.Remove(obs);

		GameObject newObstacle = Instantiate(obstaclePrefab, new Vector3(transform.position.x, Random.Range(minY, maxY), transform.position.z), Quaternion.identity) as GameObject;
		newObstacle.name = "Obstacle";
        obstacles.Add(newObstacle);

		yield return new WaitForSeconds(Random.Range(minTime, maxTime));
		StartCoroutine(CreateObstacle());
	}

}
