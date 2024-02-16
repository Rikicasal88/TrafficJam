using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManagerScript : MonoBehaviour
{
    public static PoolManagerScript instance;

    public ObjectSpawnerSO ObjectsSO;
    private List<PoolInfoClass> pool = new List<PoolInfoClass>();


    public ParticleSpawnerSO ParticlesSO;
    private List<ParticleInfoClass> particlesPoolool = new List<ParticleInfoClass>();
    
    //Temp
    private PoolInfoClass tempPoolInfo;
    private ParticleInfoClass tempParticleInfo;

    private void Awake()
    {
        instance = this;
    }

    public GameObject GetObjectFromPool(ObjType objType)
    {
        //Could use Linq but decided not to because Linq creates more Garbage for the GC
        for (int i = 0; i < pool.Count; i++)
        {
            tempPoolInfo = pool[i];
            if (tempPoolInfo.ObjType == objType && !tempPoolInfo.Obj.gameObject.activeInHierarchy)
            {
                tempPoolInfo.Obj.SetActive(true);
                return tempPoolInfo.Obj;
            }
        }

        tempPoolInfo = new PoolInfoClass(Instantiate(ObjectsSO.GetObjectByType(objType)), objType);
        pool.Add(tempPoolInfo);
        return tempPoolInfo.Obj;
    }

    public ObjectInfo GetObjectInfo(ObjType objType)
    {
        return ObjectsSO.GetInfoByType(objType);
    }

    public void ResetAllObj()
    {
        foreach (PoolInfoClass item in pool)
        {
            item.Obj.SetActive(false);
        }
    }

    public GameObject GetParticlesFromPool(ParticleType particleType)
    {
        //Could use Linq but decided not to because Linq creates more Garbage for the GC
        for (int i = 0; i < particlesPoolool.Count; i++)
        {
            tempParticleInfo = particlesPoolool[i];
            if (tempParticleInfo.ParticleType == particleType && !tempParticleInfo.Obj.gameObject.activeInHierarchy)
            {
                tempParticleInfo.Obj.SetActive(true);
                return tempParticleInfo.Obj;
            }
        }

        tempParticleInfo = new ParticleInfoClass(Instantiate(ParticlesSO.GetParticleByType(particleType)), particleType);
        particlesPoolool.Add(tempParticleInfo);
        return tempParticleInfo.Obj;
    }

}


public class PoolInfoClass
{
    public GameObject Obj;
    public ObjType ObjType;

    public PoolInfoClass(GameObject obj, ObjType objType)
    {
        Obj = obj;
        ObjType = objType;
    }
}

public class ParticleInfoClass
{
    public GameObject Obj;
    public ParticleType ParticleType;

    public ParticleInfoClass(GameObject obj, ParticleType particleType)
    {
        Obj = obj;
        ParticleType = particleType;
    }
}
