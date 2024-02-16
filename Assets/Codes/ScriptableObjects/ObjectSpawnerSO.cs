using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ObjectSpawnerSO")]
public class ObjectSpawnerSO : ScriptableObject
{
    public List<ObjectInfo> Objects = new List<ObjectInfo>();


    //Temp
    private ObjectInfo tempPoolInfo;
    public GameObject GetObjectByType(ObjType objType)
    {
        //Could use Linq but decided not to because Linq creates more Garbage for the GC
        for (int i = 0; i < Objects.Count; i++)
        {
            tempPoolInfo = Objects[i];
            if (tempPoolInfo.ObjType == objType)
            {
                return tempPoolInfo.Obj;
            }
        }

        return null;
    }

    public ObjectInfo GetInfoByType(ObjType objType)
    {
        //Could use Linq but decided not to because Linq creates more Garbage for the GC
        for (int i = 0; i < Objects.Count; i++)
        {
            tempPoolInfo = Objects[i];
            if (tempPoolInfo.ObjType == objType)
            {
                return tempPoolInfo;
            }
        }
        return null;
    }
}

[Serializable]
public class ObjectInfo
{
    public GameObject Obj;
    public ObjType ObjType;
    public float Drivability;
    public Vector2 RotationSpeedRange;

    public float MaxSpeed;
    public float MaxRotationSpeed;

    public int MoneyValue;
    public float ItemLifeDureation;

    public float GetRotationSpeed()
    {
        return UnityEngine.Random.Range(RotationSpeedRange.x, RotationSpeedRange.y);
    }
}