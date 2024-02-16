using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    public static AudioManagerScript instance;

    [SerializeField] private AudioHandlerSO Clips;
    

    [SerializeField] private AudioSource music;

    [SerializeField] private AudioSource player;

    [SerializeField] private AudioSource oneShot;
    private void Awake()
    {
        instance = this;
    }

    public void StartPlayer()
    {
        player.Play();
    }

    public void StopPlayer()
    {
        player.Stop();
    }

    public void PlayOneShot(AudioClipType clip)
    {
        oneShot.PlayOneShot(Clips.GetAudioByType(clip));
    }

}
