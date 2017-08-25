using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaySystem : MonoBehaviour
{
    private const int bufferFrames = 1000; //number of frames in ring buffer
    private MyKeyFrame[] keyFrames = new MyKeyFrame[bufferFrames];
    private List<MyKeyFrame> keyFramesList = new List<MyKeyFrame>();
    private Rigidbody rigidbody;
    private GameManager gameManager;
    private int startFrame;
    private int endFrame;
    private bool lastFrameRecording;
    private int playBackIndex = 0;

	// Use this for initialization
	void Start ()
	{
	    rigidbody = GetComponent<Rigidbody>();
	    gameManager = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (gameManager.recording)
	    {
            if (!lastFrameRecording)
            {
                keyFramesList.Clear();
                playBackIndex = 0;
                lastFrameRecording = true;
                startFrame = Time.frameCount;
            }

            Record();
	    }
	    else
	    {
            if (lastFrameRecording)
            {
                lastFrameRecording = false;
                endFrame = Time.frameCount;
            }

            PlayBack();
        }            
	}

    private void PlayBack()
    {
        if (playBackIndex > keyFramesList.Count-1)
            playBackIndex = 0;

        var currentFrame = keyFramesList[playBackIndex];

        rigidbody.isKinematic = true;

        //var index = /*Time.frameCount*/endFrame % bufferFrames;

        //print("Reading frame " + index);

        //var frame = keyFrames[index];

        //if (frame == null) return;

        transform.position = currentFrame.Position;
        transform.rotation = currentFrame.Rotation;
        //transform.position = frame.Position;
        //transform.rotation = frame.Rotation;
        playBackIndex++;
    }

    private void Record()
    {             
       // startFrame = Time.frameCount;
        rigidbody.isKinematic = false;
        var frame = Time.frameCount % bufferFrames;
        var time = Time.time;
        print("Writing frame " + frame);

        keyFramesList.Add(new MyKeyFrame(time, transform.position, transform.rotation));
        //keyFrames[frame] = new MyKeyFrame(time, transform.position, transform.rotation);
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