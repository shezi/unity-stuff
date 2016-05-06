using UnityEngine;
using System.Collections;
using System;

public class jukebox : MonoBehaviour {
    public AudioSource mpPlayer = null;
    public AudioClip[] playList;
    public playModeEnum playMode = playModeEnum._playlist;
    public enum playModeEnum
    {
        _playlist,
        _random
    };
    public float timeBreak = 1f;

    private int currentTrack = -1;
    private float nextPlayTime = 0f;

	// Use this for initialization
	void Start () {
        // if no audiosource is assigned, try to get one
        if (mpPlayer == null)
        {
            mpPlayer = GetComponent<AudioSource>();
        }
        if (mpPlayer == null)
        {
            throw new Exception("no AudioSource, add one to this GameObject or directly to mpPlayer.");
        }

        mpPlayer.loop = false;
        StartCoroutine(waitForTrackToEnd());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private IEnumerator waitForTrackToEnd()
    {
        while (true)
        {
            while (mpPlayer.isPlaying)
            {
                yield return new WaitForSeconds(0.01f);
            }

            playNextTrack();
            yield return new WaitForSeconds(0.01f);
        }
    }


    /// <summary>
    /// starts the next track
    /// </summary>
    /// <param name="obeyBreak">default: true, when false the next track will play instantly</param>
    /// <returns>when the next track was started, it returns true</returns>
    public bool playNextTrack(bool obeyBreak = true)
    {
        if (obeyBreak && !canPlay())
        {
            return false;
        }

        if (playMode == playModeEnum._random)
        {
            currentTrack = UnityEngine.Random.Range(0, playList.Length);
        }
        else
        {
            currentTrack++;
            if (currentTrack >= playList.Length)
            {
                currentTrack = 0;
            }
        }

        nextPlayTime = 0;
        mpPlayer.clip = playList[currentTrack];
        mpPlayer.Play();
        return true;
    }

    public bool canPlay()
    {
        if (timeBreak == 0)
        {
            return true;
        }

        if (nextPlayTime == 0)
        {
            nextPlayTime = Time.time + timeBreak;
            return false;
        }
        else if (Time.time < nextPlayTime)
        {
            return false;
        }

        return true;
    }
}
