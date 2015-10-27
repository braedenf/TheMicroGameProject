using UnityEngine;
using System.Collections;

public class FmodController : MonoBehaviour {

	public GameObject entranceSound;
	public GameObject player;

	private FMOD.Studio.EventInstance entry;
	private FMOD.Studio.ParameterInstance entranceDist;


	// Use this for initialization
	void Start () {
		entry = FMOD_StudioSystem.instance.GetEvent ("event:/Music/entry");
		entry.start ();
		entry.getParameter("entranceDist", out entranceDist);
	}
	
	// Update is called once per frame
	void Update () {
		float distance = Vector3.Distance(entranceSound.transform.position, player.transform.position);

		if(entry.getParameter("entranceDist", out entranceDist) != FMOD.RESULT.OK) {
			Debug.LogError("entranceDist parameter not found on entry event");
			return;
		}

		//Debug.Log ("distance: " + distance);

		entranceDist.setValue (distance);


	}
}
