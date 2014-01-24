using UnityEngine;
using System.Collections;

public class BallBehavior : MonoBehaviour {

	float cSpeed = 50.0f;
	float sFactor = 30.0f;
	// Use this for initialization
	void Start () {
		rigidbody.AddForce (0, -400, 0);
	}
	
	// Update is called once per frame
	void Update () {

		}
	void PositionChanging()
	{
		rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, rigidbody.velocity.normalized * cSpeed, Time.deltaTime * sFactor);
	}
	void OnCollisionEnter(Collision collision)
	{
		this.audio.Play ();
	}
}
