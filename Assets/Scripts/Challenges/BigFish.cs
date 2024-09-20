using UnityEngine;
using UnityEngine.Assertions;

public class BigFish : MonoBehaviour {
	public float maxHealth = 100.0f;
	public float startingHealth = 50.0f;
	public float healingSpeed = 0.1f;

	[Space(10)]
	public Vector2 maxHPPosition;
	public Vector2 minHPPosition;

	float health;
	PlayerController player;

	void Awake() {
		health = startingHealth;
		transform.position = new Vector3(maxHPPosition.x, maxHPPosition.y, 0.0f);

		// We divide by maxHealth later.
		Assert.AreNotEqual(maxHealth, 0.0f);

		PlayerController[] players = Object.FindObjectsByType<PlayerController>(FindObjectsSortMode.None);
		if (players.Length < 1) {
			Debug.LogError("Found no player! Please create one.");
			Application.Quit();
		}

		player = players[0];
	}

    void FixedUpdate() {
		health += healingSpeed;
		health = Mathf.Clamp(health, 0.0f, maxHealth);

		// Put the big fish between the max health position and the min health position
		var new_position = Vector2.Lerp(minHPPosition, maxHPPosition, health / maxHealth);
		transform.position = new Vector3(new_position.x, new_position.y, 0.0f);

		if (health >= maxHealth) {
			//player.GameOver();
			print("GAME OVER!!!!!!");
			Application.Quit();
		} else if (health <= 0.0f) {
			//player.YouWon();
			print("YOU WON! :))))");
			Application.Quit();
		}
    }

	void OnDrawGizmos() {
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere(maxHPPosition, 0.25f);
		Gizmos.DrawWireSphere(minHPPosition, 0.25f);
		Gizmos.DrawLine(maxHPPosition, minHPPosition);
	}
}
