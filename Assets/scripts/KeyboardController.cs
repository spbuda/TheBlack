using UnityEngine;
using System.Collections;

public class KeyboardController : MonoBehaviour {
	public float speed = 10.0F;
	public float thrust = 1.2F;
	public float rotationSpeed = 10.0F;

	private Rigidbody body;
	void Start() {
		body = GetComponent<Rigidbody> ();
	}

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal") * speed;
		float moveVertical = Input.GetAxis ("Vertical") * speed * thrust;

		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		body.AddForce(movement);
	}
}

