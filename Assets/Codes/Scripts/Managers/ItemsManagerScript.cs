using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsManagerScript : MonoBehaviour
{
    public static ItemsManagerScript instance;

    public int CurrentLevel = 0;
    [SerializeField] private LevelsHandlerSO Levels;

    private GameObject tempObj;
    private ObjectInfo tempPoolInfo;
    private ItemScript tempItem;

  

    private void Awake()
    {
        instance = this;
    }

    public IEnumerator MatchHandler_Co()
    {
        float lastMoneySpawnedOffset = 0;

        while (GameManagerScript.GameOn)
        {
            yield return null;
            if (GameManagerScript.Timer - lastMoneySpawnedOffset > Levels.Levels[CurrentLevel].GetMoneySpawningTime())
            {
                Spawn(Levels.Levels[CurrentLevel].GetMoneyObjType());
                lastMoneySpawnedOffset = GameManagerScript.Timer;
            }
        }
    }

    private void Spawn(ObjType objType)
    {
        tempObj = PoolManagerScript.instance.GetObjectFromPool(objType);
        tempPoolInfo = PoolManagerScript.instance.GetObjectInfo(objType);
        tempItem = tempObj.GetComponent<ItemScript>();
        tempItem.MoneyValue = tempPoolInfo.MoneyValue;
        tempItem.Duration = tempPoolInfo.ItemLifeDureation;
        Vector2 randPos = Random.insideUnitCircle * GameManagerScript.ArenaRadius;
        tempItem.transform.position = new Vector3(randPos.x, 0, randPos.y);
        tempItem.transform.LookAt(Vector3.zero);
        //tempItem.gameObject.SetActive(true);
    }
}
