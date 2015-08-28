using UnityEngine;
using System.Collections;

public class FlyAway : MonoBehaviour {
 
	public int beespeed = 0;
	public Vector3 bee;
 
	// Use this for initialization
	void Start () {
		beespeed = 0;
		bee = this.gameObject.transform.position;
	}

	void OnCollosionEnter(Collision collision) {




	}
	
	// Update is called once per frame
	void Update () {
		bee.y = bee.y + beespeed;
		this.gameObject.transform.position = bee;
		beespeed++;
	}
}

