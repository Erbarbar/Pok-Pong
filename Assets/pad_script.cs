using UnityEngine;
using System.Collections;

public class pad_script : MonoBehaviour {

	public GameObject pad;
	private float posDif;
	private float posAct;
	private float posMax, posMin;
	public float speed;
	// Use this for initialization
	void Start () {
		posAct =  0f;
		posMax =  5f;
		posMin = -5f;
		speed = 0.25f;
	}
	
	// Update is called once per frame
	void Update () {
		if (pad.gameObject.name == "pad1")
			posDif = Input.GetAxisRaw ("Custom1");
		if (pad.gameObject.name == "pad2")
			posDif = Input.GetAxisRaw ("Custom2");
		posAct += posDif * speed;

		if (posAct >= posMax)
			posAct = posMax;
		if (posAct <= posMin)
			posAct = posMin;

		pad.transform.position = new Vector2(pad.transform.position.x, posAct);
	}
}
