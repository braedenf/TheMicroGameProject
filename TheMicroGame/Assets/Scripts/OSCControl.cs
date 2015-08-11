using UnityEngine;
using System.Collections;
using LibPDBinding;
using System;
using System.Runtime.InteropServices;

public class OSCControl : MonoBehaviour 
{
	private GCHandle dataHandle;
	private IntPtr dataPtr;
	public string patch;
	private int patchName;
	
	private bool islibpdready;
	private string path;
	public bool playOnAwake = false;
	float t = 0.0f;
	
	public bool patchIsStereo = false;
	
	private float freq = 500;
	
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
		if(!islibpdready)
		{
			if (!patchIsStereo)	LibPD.OpenAudio (1,1, 48000);
			else LibPD.OpenAudio(2,2,48000);
		}
		
		patchName = LibPD.OpenPatch (path);
		LibPD.ComputeAudio (true);
		islibpdready = true;
	}
	
	public void OnAudioFilterRead (float[] data, int channels)
	{	

		if(dataPtr == IntPtr.Zero)
		{
			dataHandle = GCHandle.Alloc(data,GCHandleType.Pinned);
			dataPtr = dataHandle.AddrOfPinnedObject();
		}
		
		if (LibPD.Process(32, dataPtr, dataPtr)==0) {
			//LibPD.SendFloat(SPatch + "turn", t);
			LibPD.SendFloat(patchName + "freq1", freq);
			LibPD.SendFloat(patchName + "freq2", freq);
			
		}else Debug.Log("End");
	}
	
	void OnGUI()
	{
		freq = GUI.VerticalSlider(new Rect(Screen.width/2 - 50 , Screen.height/2 - 150, 100, 300),freq,1000, 400);
		GUI.Box(new Rect(Screen.width/2-30, Screen.height/2 - 30, 80, 30), ""+freq+" hz");
	}
	
	// delegate for [print]
	void Receive(string msg) 
	{
		Debug.Log("print:" + msg);
	}
	
	
	public void closePatch ()
	{
		//LibPD.Print -= Receive;
		LibPD.ClosePatch (patchName);
		LibPD.Release ();
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
