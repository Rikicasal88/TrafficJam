using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/AudioHandlerSO")]
public class AudioHandlerSO : ScriptableObject
{
    public List<AudioInfo> Clips = new List<AudioInfo>();

    //Temp
    private AudioInfo tempPoolInfo;
    public AudioClip GetAudioByType(AudioClipType audioType)
    {
        //Could use Linq but decided not to because Linq creates more Garbage for the GC
        for (int i = 0; i < Clips.Count; i++)
        {
            tempPoolInfo = Clips[i];
            if (tempPoolInfo.ParticleType == audioType)
            {
                return tempPoolInfo.Clip;
            }
        }
        return null;
    }
}

[Serializable]
public class AudioInfo
{
    public AudioClip Clip;
    public AudioClipType ParticleType;
   
}