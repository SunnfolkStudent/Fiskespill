using UnityEngine;

public class FishSpawner : MonoBehaviour {
	public float minimumWaitTime;
	public float maximumWaitTime;

	[Space(5)]
	public Vector2 spawnerAreaBottomLeftCorner;
	public Vector2 spawnerAreaTopRightCorner;

	[Space(5)]
	public GameObject[] fishTypes;

	float timer;

	void Awake() {
		timer = Random.Range(minimumWaitTime, maximumWaitTime);

		if (fishTypes.Length == 0) {
			Debug.LogError("No fish types added in fish spawner! Make sure the fish type list is not empty!");
			Object.Destroy(this);
		}
	}

	void Update() {
		if (timer > 0.0f) {
			timer -= Time.deltaTime;
		} else {
			timer = Random.Range(minimumWaitTime, maximumWaitTime);

			Vector3 fishPosition = transform.position;

			fishPosition.x += Random.Range(spawnerAreaBottomLeftCorner.x, spawnerAreaTopRightCorner.x);
			fishPosition.y += Random.Range(spawnerAreaBottomLeftCorner.y, spawnerAreaTopRightCorner.y);

			// TODO: Check if the new fish position is colliding with anything.

			Instantiate(fishTypes[Random.Range(0, fishTypes.Length - 1)],
			            fishPosition, Quaternion.identity);
		}
	}
}
