using UnityEngine;
using System.Collections;

public class FlyAway : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int speed = 0;
	}

	void OnCollosionEnter(Collision collision) {
		speed++;
		transform.position.y = speed;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

