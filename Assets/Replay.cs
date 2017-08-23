using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Replay : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}


public class MyKeyFrame
{
    public float FrameTime { get; set; }
    public Vector3 Position { get; set; }
    public Quaternion Rotation { get; set; }

    public MyKeyFrame(float time, Vector3 position, Quaternion rotation)
    {
        FrameTime = time;
        Position = position;
        Rotation = rotation;
    }
}