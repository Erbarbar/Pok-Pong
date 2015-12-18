using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ball_script : MonoBehaviour {

	public GameObject ball;
	public Rigidbody2D rb2d;
	private int score1, score2;
	private float vMax;
	public Text sc1, sc2;
	public float vtop;
	// Use this for initialization
	void Start () {
		rb2d.AddForce (Vector2.right * 10, ForceMode2D.Impulse);
		rb2d.AddTorque (10f);
		score1 = 0;
		score2 = 0;
		vMax = 18;
		vtop = 0;
	}

	void FixedUpdate(){
		if (Mathf.Abs (rb2d.velocity.x) > vtop)
			vtop = Mathf.Abs (rb2d.velocity.x);
		if (Mathf.Abs (rb2d.velocity.y) > vtop)
			vtop = Mathf.Abs (rb2d.velocity.y);
		if (Mathf.Abs( rb2d.velocity.x) >= vMax)
			rb2d.velocity = new Vector2 (vMax, rb2d.velocity.y);
		if (Mathf.Abs( rb2d.velocity.y) >= vMax)
			rb2d.velocity = new Vector2 (rb2d.velocity.x, vMax);
	}

	void Update(){
		sc1.text = "P1: " + score1;
		sc2.text = "P2: " + score2;
		if (Input.GetKeyDown("space")){
			score1 = 0;
			score2 = 0;
			ball.transform.position = new Vector2(0f,0f);
			rb2d.velocity = new Vector2(0f,0f);
			rb2d.angularVelocity = 0f;
			rb2d.AddForce (Vector2.right * 10, ForceMode2D.Impulse);
			rb2d.AddTorque (10f);

		}
	}

	void OnCollisionEnter2D(Collision2D other){

		if (other.gameObject.tag == "right") {
			score1 ++;
		}
		if (other.gameObject.tag == "left") {
			score2 ++;
		}
	}
}
