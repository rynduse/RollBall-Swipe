using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;


	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		GetComponent<Rigidbody>().AddForce (movement * speed * Time.deltaTime);

		if (Input.touchCount > 0 && 
		    Input.GetTouch(0).phase == TouchPhase.Moved) {
			
			// Get movement of the finger since last frame
			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
			
			// Move object across XY plane
			GetComponent<Rigidbody>().AddForce (new Vector3(touchDeltaPosition.x, 0.0f, touchDeltaPosition.y)
			                    * speed * Time.deltaTime);
		}
		else if(Input.touchCount == 0)
		{
			GetComponent<Rigidbody>().velocity = Vector3.zero;
			GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
		}
	}
	
	void OnTriggerEnter(Collider other) {
		//Destroy(other.gameObject);
		// gameObject.tag = "Player";
		// gameObject.SetActive(false);
		if (other.gameObject.tag == "PickUp") {
			other.gameObject.SetActive(false);
		}
	}

}
