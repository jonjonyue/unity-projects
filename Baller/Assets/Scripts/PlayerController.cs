using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {


	public float speed;
	public Text countText;
	public Text winText;
	public string horizontalCtrl = "Horizontal_P2";
	public string verticalCtrl = "Vertical_P2";
	public string jumpCtrl = "Jump_P1";
	private Rigidbody rb;

	bool isGrounded;
	Vector3 direction;
	Vector3 directiontwo;
	Vector3 jump;

	private int count;

	void Start() 
	{
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
		winText.text = "";
	}

	void FixedUpdate ()
	{
		if (checkGrounded()) {
			jump.y = Input.GetAxis (jumpCtrl);
		}
		direction.x = Input.GetAxis (horizontalCtrl);
		direction.z = Input.GetAxis (verticalCtrl);

		rb.AddForce (direction * speed);
		rb.AddForce (jump, ForceMode.VelocityChange);
	}
		
	bool checkGrounded ()
	{
		Vector3 dir = new Vector3 (0, 0, -1);
		RaycastHit hit;
		if (Physics.Raycast(transform.position, dir, out hit, 1f)) {
			isGrounded = true;
		} else {
			isGrounded = false;
		}
		return isGrounded;
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Pickup")) 
		{
			other.gameObject.SetActive (false);
			count++;
			SetCountText ();
		}
	}

	void SetCountText ()
	{
		if (this.gameObject.tag == "Player_1") {
			countText.text = "Player 1: " + count.ToString ();
			if (count >= 11 && winText.text == "") {
				winText.text = "Player One Wins!";
			} 
		} else {
			countText.text = "Player 2: " + count.ToString ();
			if (count >= 11 && winText.text == "") {
				winText.text = "Player Two Wins!";
			}
		}
	}
}