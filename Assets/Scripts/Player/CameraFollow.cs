using UnityEngine;

public class CameraFollow : MonoBehaviour {
	const float cameraZ = -10.0f;

    public Transform target;
	// 1.0f makes the camera instantly jump to the target.
	// 0.5f makes the camera move half the distance towards the target every frame.
	// 0.0f makes the camera stand still.
	public float movementAntiDamping = 0.5f;

	void Awake() {
		var newPosition    = target.position;
		newPosition.z      = cameraZ;
		transform.position = newPosition;
	}

	void FixedUpdate() {
		// Compute the difference between the camera position and the target
		var delta = new Vector3(
			target.position.x - transform.position.x,
			target.position.y - transform.position.y,
			0.0f
		);

		// Do some smoothening
		delta *= movementAntiDamping;

		// Apply the thing
		var newPosition = transform.position;
		newPosition += delta;
		newPosition.z = cameraZ;
		transform.position = newPosition;
	}
}
