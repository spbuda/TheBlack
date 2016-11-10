using UnityEngine;
using System.Collections;

public class ShotMover : MonoBehaviour {
    public float speed;
    private Rigidbody rb;

    void Start() //runs this code the frame the object enters the game
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }
}