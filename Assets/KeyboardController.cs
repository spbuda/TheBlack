using UnityEngine;
using System.Collections;

public class KeyboardController : MonoBehaviour {
	public float speed = 10.0F;
	public float thrust = 1.2F;
	public float rotationSpeed = 10.0F;

	private Rigidbody2D rb2d;
	void Start() {
		rb2d = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal") * speed;
		float moveVertical = Input.GetAxis ("Vertical") * speed * thrust;

		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		rb2d.AddForce (movement);
	}
}
