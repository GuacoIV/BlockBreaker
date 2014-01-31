using UnityEngine;
using System.Collections;

public class BallBehavior : MonoBehaviour {

	public float cSpeed = 1f;
	public float sFactor = 30.0f;
	public float angledForce = 100;
	public int ballsRemaining = 2;
	bool newBall = false;

	// Use this for initialization
	void Start () {
		rigidbody.AddForce (0, -600, 0);
	}
	void OnGUI()
	{
		if (newBall) {
			newBall = false;
			waitASecond();
				}
	}
	IEnumerator waitASecond()
	{
				yield return new WaitForSeconds (2);
		}
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Backspace))  {
						rigidbody.AddForce(200, 200, 0);
				}
		var blocks = GameObject.FindGameObjectsWithTag ("Cube");
		if (blocks.Length == 0) {
						Debug.Log ("YOU WIN");
			Application.Quit();
				}
		if (rigidbody.position.y < GameObject.FindGameObjectWithTag ("Player").transform.position.y - 5 && rigidbody.gameObject.tag != "Extra Ball") {
						if (ballsRemaining > 0) {
								ballsRemaining--;

								GameObject.FindGameObjectWithTag ("GUI").guiText.text = "Balls left: " + ballsRemaining;
								this.rigidbody.position = new Vector3 (0, 10, 0);
								newBall = true;
								this.rigidbody.velocity = new Vector3 (0, 0, 0);
								rigidbody.AddForce (0, -600, 0);
						} else {
								Debug.Log ("Game over");
								Application.Quit ();

						}
				} else if (rigidbody.position.y < GameObject.FindGameObjectWithTag ("Player").transform.position.y - 5 && rigidbody.gameObject.tag == "Extra Ball")
						Destroy (rigidbody.gameObject);

	}

	void OnCollisionEnter(Collision collision)
	{
		this.audio.Play ();
		rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, rigidbody.velocity * 1.04f, Time.deltaTime * sFactor);
		if (rigidbody.velocity.x > 17)
						rigidbody.velocity = new Vector3(17f, rigidbody.velocity.y, 0);
		if (rigidbody.velocity.y > 17)
						rigidbody.velocity = new Vector3(rigidbody.velocity.x, 17f, 0);
		
		if (collision.gameObject.name == "Paddle") 
		{

				Debug.Log ("Paddle hit");
				Vector3 paddlePos = collision.gameObject.transform.position;
				Vector3 ballPos = this.rigidbody.position;
				if (ballPos.x < paddlePos.x - .5)
				{
					this.rigidbody.AddForce (-angledForce, 0, 0);
				}
				else if (ballPos.x > paddlePos.x + .5)
				{
					this.rigidbody.AddForce(angledForce, 0, 0);
				}
		}
		if (collision.gameObject.name == "Left Wall") {
			this.rigidbody.AddForce(100, 0, 0);
				}
		if (collision.gameObject.name == "Right Wall") {
						this.rigidbody.AddForce (-100, 0, 0);
				}
			if (collision.gameObject.name == "Top Wall") {
				this.rigidbody.AddForce(0, -100, 0);
		}
	}
}
