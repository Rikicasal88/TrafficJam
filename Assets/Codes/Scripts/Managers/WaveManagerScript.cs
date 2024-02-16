using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManagerScript : MonoBehaviour
{

    public static WaveManagerScript instance;

    public int CurrentLevel = 0;
    [SerializeField] private LevelsHandlerSO Levels;


    private GameObject tempObj;
    private ObjectInfo tempPoolInfo;
    private BaseCarScript tempBaseCar;

    private void Awake()
    {
        instance = this;
    }


    public IEnumerator WaveHandler_Co()
    {
        float lastSpawnedOffset = 0;

        while (GameManagerScript.GameOn)
        {
            yield return null;
            if (GameManagerScript.Timer - lastSpawnedOffset > Levels.Levels[CurrentLevel].GetSpawningTime())
            {
                Spawn(Levels.Levels[CurrentLevel].GetObj());
                lastSpawnedOffset = GameManagerScript.Timer;
            }
        }
    }

    private void Spawn(ObjType objType)
    {
        tempObj = PoolManagerScript.instance.GetObjectFromPool(objType);
        tempPoolInfo = PoolManagerScript.instance.GetObjectInfo(objType);
        tempBaseCar = tempObj.GetComponent<BaseCarScript>();
        tempBaseCar.MaxSpeed = tempPoolInfo.MaxSpeed;
        tempBaseCar.Speed = Levels.Levels[CurrentLevel].GetSpeed();
        Vector2 randPos = Random.insideUnitCircle.normalized * (GameManagerScript.ArenaRadius + 1.5f);
        tempBaseCar.transform.position = new Vector3(randPos.x, 0, randPos.y);
        tempBaseCar.transform.LookAt(Vector3.zero);
        //tempBaseCar.gameObject.SetActive(true);
    }
}
