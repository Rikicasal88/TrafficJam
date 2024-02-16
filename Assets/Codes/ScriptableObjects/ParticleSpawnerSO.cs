using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ParticleSpawnerSO")]
public class ParticleSpawnerSO : ScriptableObject
{
    public List<ParticleInfo> Particles = new List<ParticleInfo>();

    //Temp
    private ParticleInfo tempPoolInfo;
    public GameObject GetParticleByType(ParticleType particleType)
    {
        //Could use Linq but decided not to because Linq creates more Garbage for the GC
        for (int i = 0; i < Particles.Count; i++)
        {
            tempPoolInfo = Particles[i];
            if (tempPoolInfo.ParticleType == particleType)
            {
                return tempPoolInfo.Obj;
            }
        }
        return null;
    }
}

[Serializable]
public class ParticleInfo
{
    public GameObject Obj;
    public ParticleType ParticleType;
   
}