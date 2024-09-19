using UnityEngine;

public class BigFish : MonoBehaviour {
	public float startingHealth = 100.0f;

	[Space(10)]
	public Vector2 startPosition;
	public Vector2 endPosition;

	float health;

	void Awake() {
		health = startingHealth;
	}

    void FixedUpdate() {
		// Put the big fish between the ending position and the starting position
		var new_position = Vector2.Lerp(endPosition, startPosition, health / startingHealth);
		transform.position = new Vector3(new_position.x, new_position.y, 0.0f);
    }

	void OnDrawGizmos() {
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere(startPosition, 1.0f);
		Gizmos.DrawWireSphere(endPosition,   1.0f);

		Gizmos.DrawRay(startPosition, endPosition);
	}
}
