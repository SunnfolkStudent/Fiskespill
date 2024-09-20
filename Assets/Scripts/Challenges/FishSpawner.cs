using UnityEngine;

public class FishSpawner : MonoBehaviour {
	public float minimumWaitTime;
	public float maximumWaitTime;
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

			Instantiate(fishTypes[Random.Range(0, fishTypes.Length - 1)],
			            transform.position, Quaternion.identity);
		}
	}
}
