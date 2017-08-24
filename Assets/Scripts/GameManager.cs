using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour
{
    public bool recording;
    private ReplaySystem replaySystem;  
	
	// Update is called once per frame
	void Update ()
	{
	    recording = CrossPlatformInputManager.GetButton("Fire1");    
	}

    public void SetRecording()
    {
        recording = !recording;
    }

    public void DisableRecording()
    {
        recording = false;
    }
}
