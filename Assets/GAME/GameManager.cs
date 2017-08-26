using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour
{
    public bool recording;
    private float initialFixedDeltaTime;
    private ReplaySystem replaySystem;
    private bool isPaused;    

    void Start()
    {
        initialFixedDeltaTime = Time.fixedDeltaTime;
        //unlock level 2
        PlayerPrefsManager.UnlockLevel(1);
        Debug.Log(PlayerPrefsManager.IsLevelUnlocked(1));
        Debug.Log(PlayerPrefsManager.IsLevelUnlocked(2));
    }

    // Update is called once per frame
    void Update()
    {
        recording = CrossPlatformInputManager.GetButton("Fire1");


        if (Input.GetKeyDown(KeyCode.P) && isPaused)
        {
            isPaused = false;
            ResumeGame();
        }
        else if (Input.GetKeyDown(KeyCode.P) && !isPaused)
        {
            isPaused = true;
            PauseGame();
        }

        print("Update");

    }

    void PauseGame()
    {
        Time.timeScale = 0;
        Time.fixedDeltaTime = 0;
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
        Time.fixedDeltaTime = initialFixedDeltaTime;
    }

    public void SetRecording()
    {
        recording = !recording;
    }

    public void DisableRecording()
    {
        recording = false;
    }

    //todo: this is supposed to handle pausing when player navigates away from game
    //todo: worry about this later 
    //void OnApplicationPause(bool pauseStatus)
    //{
    //    isPaused = pauseStatus;
    //    if (!pausedLastFrame && pauseStatus)
    //        PauseGame();
    //}
}
