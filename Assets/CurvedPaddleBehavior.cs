using UnityEngine;
using System.Collections;

public class CurvedPaddleBehavior : MonoBehaviour {

	int paddleSpeed = 10;
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetButton("LEFT"))
			transform.Translate(new Vector3(-paddleSpeed,0,0) * Time.deltaTime);
		
		else if (Input.GetButton ("RIGHT"))
			transform.Translate (new Vector3 (paddleSpeed, 0, 0) * Time.deltaTime);
		
		if (transform.position.x > 20)
			transform.position = new Vector3 (20, -10, 0);
		
		if (transform.position.x < -20)
			transform.position = new Vector3 (-20, -10, 0);
	}
}
