using UnityEngine;

public class FishSpawner : MonoBehaviour {
	public GameObject[] fishTypes;
	public float minimumWaitTime;
	public float maximumWaitTime;

	float timer;

	void Awake() {
		timer = Random.Range(minimumWaitTime, maximumWaitTime);
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
