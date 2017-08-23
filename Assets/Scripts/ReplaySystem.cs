using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaySystem : MonoBehaviour
{
    private const int bufferFrames = 100; //number of frames in ring buffer
    private MyKeyFrame[] keyFrames = new MyKeyFrame[bufferFrames];
    private Rigidbody rigidbody;

	// Use this for initialization
	void Start ()
	{
	    rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    Record();
	}

    private void PlayBack()
    {
        rigidbody.isKinematic = true;

        var frame = Time.frameCount % bufferFrames;

        print("Reading frame " + frame);
        transform.position = keyFrames[frame].Position;
        transform.rotation = keyFrames[frame].Rotation;
    }

    private void Record()
    {
        rigidbody.isKinematic = false;
        var frame = Time.frameCount % bufferFrames;
        var time = Time.time;
        print("Writing frame " + frame);

        keyFrames[frame] = new MyKeyFrame(time, transform.position, transform.rotation);
    }
}

/// <summary>
/// A structure for storing time, rotation, and position
/// </summary>
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