using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/LevelsHandlerSO")]
public class LevelsHandlerSO : ScriptableObject
{
    public List<LevelInfo> Levels = new List<LevelInfo>();
}


[Serializable]
public class LevelInfo
{
    public List<ObjType> ObjTypes = new List<ObjType>();
    public List<ObjType> MoneyTypes = new List<ObjType>();
    public Vector2 SpeedMultiplierRange;
    public Vector2 MoneySpawningTimeOffsetRange;
    public Vector2 SpawningTimeOffsetRange;


    public float GetSpeed()
    {
        return UnityEngine.Random.Range(SpeedMultiplierRange.x, SpeedMultiplierRange.y);
    }

    public float GetSpawningTime()
    {
        return UnityEngine.Random.Range(SpawningTimeOffsetRange.x, SpawningTimeOffsetRange.y);
    }

    public float GetMoneySpawningTime()
    {
        return UnityEngine.Random.Range(MoneySpawningTimeOffsetRange.x, MoneySpawningTimeOffsetRange.y);
    }

    public ObjType GetObj()
    {
        return ObjTypes[UnityEngine.Random.Range(0, ObjTypes.Count)];
    }

    public ObjType GetMoneyObjType()
    {
        return MoneyTypes[UnityEngine.Random.Range(0, MoneyTypes.Count)];
    }
}
