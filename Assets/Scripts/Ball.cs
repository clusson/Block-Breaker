using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	private Paddle paddle;
	private bool hasStarded = false;
	private Vector3 paddleToBallVector;
	private AudioSource audioSource;
	private Rigidbody2D rigidbody2D;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		audioSource = GetComponent<AudioSource>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasStarded) {
			// Lock the ball relative to the paddle
			this.transform.position = paddle.transform.position + paddleToBallVector;

			// Wait for a mouse press to launch.
			if (Input.GetMouseButton(0)) {
				hasStarded = true;
				this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
			}
		}
	}

	void OnCollisionEnter2D (Collision2D collision)
	{
		Vector2 tweak = new Vector2 (Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));

		if (hasStarded) {
			audioSource.Play();
			this.GetComponent<Rigidbody2D>().velocity += tweak;
		}
	}
}
