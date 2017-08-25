using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour
{
    public bool recording;
    private ReplaySystem replaySystem;

    void Start()
    {
        //unlock level 2
        PlayerPrefsManager.UnlockLevel(1);
        Debug.Log(PlayerPrefsManager.IsLevelUnlocked(1));
        Debug.Log(PlayerPrefsManager.IsLevelUnlocked(2));
    }

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
