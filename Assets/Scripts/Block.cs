using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision)
	{
		Debug.Log("Destroying");
		this.audio.Play();
		renderer.enabled = false;
		collider.enabled = false;
		Destroy(gameObject, this.audio.time+1);
	}
}
