using UnityEngine;
using System.Collections.Generic;
using LibPDBinding;
using System.Runtime.InteropServices;
using System;

public class LibPdFilterRead : MonoBehaviour
{
	private GCHandle dataHandle;
	private IntPtr dataPtr;
	
	public Transform velocityBridge;
	
	public string patch;
	private int SPatch;
	private bool islibpdready;
	public float send_freq;
	private string path;
	public bool playOnAwake = false;
	float t = 0.0f;
	
	void Awake ()
	{
		
		path = Application.dataPath + "/Resources/" + patch;
		if ( playOnAwake)loadPatch ();
	}
	
	void Update()
	{
		t = Time.deltaTime;
	}
	
	public void loadPatch ()
	{
		Debug.Log("Load patch:" + path);
		
		// we can also work in stereo or more: LibPD.OpenAudio (2, 2, 48000);
		if(!islibpdready)
		{
			LibPD.OpenAudio (1,1, 48000);
		}
		SPatch = LibPD.OpenPatch (path);
		LibPD.ComputeAudio (true);
		islibpdready = true;
		LibPD.SendFloat(SPatch + "turn", t);

		//LibPD.Print += Receive;
	}

	// delegate for [print]
	void Receive(string msg) 
	{
		Debug.Log("print:" + msg);
	}
	
	
	public void closePatch ()
	{
		//LibPD.Print -= Receive;
		LibPD.ClosePatch (SPatch);
		LibPD.Release ();
	}
	
	public void OnAudioFilterRead (float[] data, int channels)
	{	

		if(dataPtr == IntPtr.Zero)
		{
			dataHandle = GCHandle.Alloc(data,GCHandleType.Pinned);
			dataPtr = dataHandle.AddrOfPinnedObject();
		}
		
		if (LibPD.Process(32, dataPtr, dataPtr)==0) {
			LibPD.SendFloat(SPatch + "turn", t);
			LibPD.SendFloat(SPatch + "freq1", send_freq);
			LibPD.SendFloat(SPatch + "freq2", send_freq);
			
		}else Debug.Log("End");
	}
	
	void OnApplicationQuit ()
	{
		Debug.Log("On Quit");
		closePatch ();
	}
	
	public void OnDestroy()
	{
		Debug.Log("On Destroy");
		dataHandle.Free();
		dataPtr = IntPtr.Zero;
	}
	
}