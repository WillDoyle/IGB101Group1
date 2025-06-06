using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public Text pickupText;
    public AudioSource[] audioSources;
    public float audioProximity = 5.0f;

    public int currentPickups = 0;
    public int maxPickups = 5;
    public bool levelComplete = false;

    public void RemoveAudioSource(AudioSource audioToRemove)
    {
        System.Collections.Generic.List<AudioSource> audioList = new System.Collections.Generic.List<AudioSource>(audioSources);
        audioList.Remove(audioToRemove);
        audioSources = audioList.ToArray();
    }


    private void UpdateGUI()
    {
        pickupText.text = "Acorns Collected: " + currentPickups + "/" + maxPickups;
    }

    private void PlayAudioSamples()
    {
        for (int i = 0; i < audioSources.Length; i++)
        {
            if(Vector3.Distance(player.transform.position, audioSources[i].transform.position) <= audioProximity)
            {
                if (!audioSources[i].isPlaying)
                {
                    audioSources[i].Play();
                }
            }
        }
    }

    private void LevelCompleteCheck()
    {
        if (currentPickups >= maxPickups)
        {
            levelComplete = true;
        }
        else
        {
            levelComplete = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        LevelCompleteCheck();
        UpdateGUI();
        PlayAudioSamples();
    }
}
