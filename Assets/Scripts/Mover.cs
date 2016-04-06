using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

    public float speed;

	
	private Vector3 direction;
	private Vector3 target;
	private float collisionAngle;

//	void Start () {
//
//        Rigidbody rigidbody = GetComponent<Rigidbody>();
//
//	    cursorInWorldPos = Camera.main.ScreenToWorldPoint( Input.mousePosition );
//		Debug.Log (cursorInWorldPos.x + "," + cursorInWorldPos.y + "," + cursorInWorldPos.z);
//
//		transform.LookAt (cursorInWorldPos);
//
//		Vector3 direction = cursorInWorldPos - transform.position;
//		//direction.Normalize();
//
//
//
////
////		float angle = Mathf.Atan2(direction.x,direction.z) * Mathf.Rad2Deg;
////
////		Debug.Log ("angle : " + angle);
////
////		transform.Rotate (Vector3.up, angle);
//
//
//
//
//	}
//
//	void Update(){
//
//		transform.Translate(transform.forward * speed * Time.deltaTime);
//	}
//	

	void Start(){
		target = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		target = new Vector3 (target.x, transform.position.y, target.z);

		direction = target - transform.position;
		direction.Normalize ();

		float angle = Mathf.Atan2(direction.x,direction.z) * Mathf.Rad2Deg;

		transform.Rotate (Vector3.up, angle);

//		Rigidbody rigidbody = GetComponent<Rigidbody>();
//		rigidbody.velocity = direction * speed;

	}

	void Update () {

		//transform.Translate (direction * Time.deltaTime);

		//transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
		transform.position += direction * (speed * Time.deltaTime);
	}    


	void OnTriggerEnter(Collider other){

		Rigidbody rigidbody = GetComponent<Rigidbody>();

		Debug.Log ("col angle : " + collisionAngle);
		Vector3 vel = rigidbody.velocity;

		if (other.tag == "North Wall") {



			direction = Vector3.Reflect (direction, Vector3.forward);


		
		} else if (other.tag == "South Wall") {

			direction = Vector3.Reflect (direction, Vector3.forward);

		}

		else if (other.tag == "East Wall") {

			direction = Vector3.Reflect (direction, Vector3.right);
		
		}
		else if (other.tag == "West Wall") {
			direction = Vector3.Reflect (direction, Vector3.right);
		
		}

		
		
	}
	
}
