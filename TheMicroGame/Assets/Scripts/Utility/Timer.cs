using UnityEngine;
using System.Collections;

/// <summary>
/// I needed to include this script because my scripts relied on this timer.
/// It Sould be self explanatory
/// </summary>

public abstract class BaseTimer {
	
	protected float currentTime;
	protected bool isRunning;
	
	protected bool enabled;
	public virtual bool Enabled
	{
		get {return enabled; }
		set {enabled = value; }
	}
	
	public abstract void Update();
	
	public abstract  float CurrentTime
	{
		get;
		set;
	}
	
	public abstract float ElapsedTime
	{
		get;
		set;
	}
	
	public abstract bool IsRunning {
		get;
	}
	
	public abstract void Start();
	public abstract void Stop();
	public abstract void Pause();
	public abstract void Continue();
	public abstract void Reset();
}

public class Timer : BaseTimer
{
	public override float CurrentTime {
		get {
			return currentTime;
		}
		set {
			currentTime = value;
		}
	}
	
	public override float ElapsedTime
	{
		get { return CurrentTime; }
		set { CurrentTime = value; }
	}
	
	public override bool Enabled {
		get {
			return enabled;
		}
		set {
			enabled = value;
		}
	}
	
	public float ElapsedMinutes
	{
		get { return ( ElapsedTime / 60f); }
	}
	
	public float ElapsedMilliseconds
	{
		get {return ( ElapsedTime / 100f ); }
	}
	
	public float ElapsedHour
	{
		get { return ( ElapsedMinutes / 60 ); }
	}
	
	public override bool IsRunning {
		get {
			return isRunning;
		}
	}
	
	public override void Update ()
	{
		if (isRunning)
		{
			currentTime += Time.deltaTime;
		}
	}
	
	public override void Start ()
	{
		if (!isRunning)
			isRunning = true;
	}
	
	public override void Stop ()
	{
		isRunning = false;
		currentTime = 0f;
	}
	
	public override void Pause ()
	{
		isRunning = false;
	}
	
	public override void Continue ()
	{
		isRunning = true;
	}
	
	public override void Reset ()
	{
		currentTime = 0f;
	}
	
	public override string ToString()
	{
		return "" + (int)ElapsedMinutes + ":"
			+ (int)(ElapsedTime - ((int)ElapsedMinutes * 60));
	}
	
}

public interface ExpiringTimers
{
	bool HasExpired
	{
		get;
	}
	
	float Position
	{
		get;
		set;
	}
}

public class CountdownTimer : BaseTimer, ExpiringTimers
{
	private float initialTime;
	private bool _hasExpired;
	
	public CountdownTimer(float initialTime)
	{
		this.initialTime = initialTime;
		this.currentTime = initialTime;
	}
	
	public override bool Enabled {
		get {
			return enabled;
		}
		set {
			enabled = value;
		}
	}
	
	public override float CurrentTime {
		get {
			return currentTime; 
		}
		set {
			currentTime = value;
		}
	}
	
	public override float ElapsedTime {
		get {
			return initialTime - currentTime;
		}
		set {
			currentTime = initialTime - value; 
		}
	}
	
	public float StartingTime
	{
		get {return initialTime; }
		set {initialTime = value;}
	}
	
	public override bool IsRunning {
		get {
			return isRunning;
		}
	}
	
	public bool HasExpired
	{
		get {return _hasExpired; }
		
		//		get 
		//		{ 
		//			if (!isRunning && CurrentTime <= 0f)
		//			{
		//				return true;
		//			}
		//
		//			return false;
		//		}
	}
	
	public float Position
	{
		get {return Mathf.Clamp(1f - ( currentTime / initialTime ), 0f, 1f ); }
		set { currentTime = (1 - value) * initialTime; }
	}
	
	public float TimeLeft
	{
		get { return CurrentTime; }
	}
	
	public override void Update ()
	{
		if (isRunning)
		{
			currentTime -= Time.deltaTime;
			
			if (currentTime <= 0)
			{
				isRunning = false;
				_hasExpired = true;
			}
		}
	}
	
	public override void Start ()
	{
		if (!isRunning)
			isRunning = true;
	}
	
	public override void Stop ()
	{
		isRunning = false;
		currentTime = initialTime;
	}
	
	public override void Pause ()
	{
		isRunning = false;
	}
	
	public override void Continue ()
	{
		isRunning = true;
	}
	
	public override void Reset ()
	{
		currentTime = initialTime;
		_hasExpired = false;
	}
}
