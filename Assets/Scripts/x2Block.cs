using UnityEngine;
using System.Collections;

public class x2Block : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision collision)
	{
		Debug.Log ("Powerup");
		this.audio.Play ();
		renderer.enabled = false;
		collider.enabled = false;
		Destroy (gameObject, this.audio.time + 1);

		Collider cloneBall;
		cloneBall = (Collider) Instantiate (collision.gameObject);
		cloneBall.tag = "Extra Ball";
		cloneBall.rigidbody.position = new Vector3 (0, 10, 0);
		cloneBall.rigidbody.velocity = new Vector3(0, 0, 0);
		cloneBall.rigidbody.AddForce(0, -600, 0);
	}
}
