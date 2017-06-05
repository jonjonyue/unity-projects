using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public int speed;
	public Text countText;

	private int count;
	private Rigidbody2D rb;
	Vector2 dir;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		count = 0;
		countText.text = "Count: " + count.ToString ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		dir.x = Input.GetAxis ("Horizontal");
		dir.y = Input.GetAxis ("Vertical");

		rb.AddForce (dir * speed);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("PickUp")) {
			other.gameObject.SetActive (false);
			count++;
			countText.text = "Count: " + count;
		}
	}
}
