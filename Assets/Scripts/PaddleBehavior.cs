using UnityEngine;
using System.Collections;

public class PaddleBehavior : MonoBehaviour {

	public int paddleSpeed = 2;
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButton("LEFT"))
		    transform.Translate(new Vector3(-paddleSpeed,0,0) * Time.deltaTime * 0.2f);

		else if (Input.GetButton ("RIGHT"))
						transform.Translate (new Vector3 (paddleSpeed, 0, 0) * Time.deltaTime * 0.2f);

		if (transform.position.x > 27.5)
						transform.position = new Vector3 (27.5f, -10, 0);

		if (transform.position.x < -27.5)
			transform.position = new Vector3 (-27.5f, -10, 0);
	}
}
