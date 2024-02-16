using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class GameManagerScript : MonoBehaviour
{


    public delegate void UpdateMoney(int money);
    public event UpdateMoney UpdateMoneyEvent;
    public delegate void UpdateTime(int time);
    public event UpdateTime UpdateTimeEvent;

    public static GameManagerScript instance;
    public static float Timer = 0;
    public static bool GameOn = false;
    public static float ArenaRadius = 11;
    public static int CrashPay = 10000;


    PlayerCarScript player;


    public int MatchDuration = 30;
    public bool Drifting = false;
    public int CurrentLevel = 0;
    [SerializeField] private int money;
    [SerializeField] private Transform indicator;
   
    public int Money
    {
        get
        {
            return money;
        }
        set 
        {
            money = value;
            UpdateMoneyEvent?.Invoke(money);
        }
    }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        InputManagerScript.instance.UpdateTargetPositionEvent += Instance_UpdateTargetPositionEvent;
        indicator.position = new Vector3(1000, 1000, 1000);
    }

    private void Instance_UpdateTargetPositionEvent(Vector3 pos)
    {
        indicator.position = pos;
    }

    public void StartGame()
    {
        StartCoroutine(Match_Co());
    }

    IEnumerator StartGame_Co()
    {
        player = PoolManagerScript.instance.GetObjectFromPool(ObjType.Player).GetComponent<PlayerCarScript>();
        player.transform.position = Vector3.zero;
        player.transform.eulerAngles = Vector3.zero;
        ObjectInfo info = PoolManagerScript.instance.GetObjectInfo(ObjType.Player);
        player.RotatioSpeed = info.GetRotationSpeed();
        player.MaxSpeed = info.MaxSpeed;
        player.MaxRotationSpeed = info.MaxRotationSpeed;
        player.Drivability = info.Drivability;
        player.NewInput = false;
        //player.gameObject.SetActive(true);

        yield return UIManagerScript.instance.CountDown();

        player.StartPlayerMovement();
    }


    IEnumerator Match_Co()
    {
        yield return StartGame_Co();

        Timer = 0;
        GameOn = true;

        StartCoroutine(ItemsManagerScript.instance.MatchHandler_Co());
        StartCoroutine(WaveManagerScript.instance.WaveHandler_Co());
        AudioManagerScript.instance.StartPlayer();
        while (Timer < MatchDuration)
        {
            yield return null;
            Timer += Time.deltaTime;
            UpdateTimeEvent?.Invoke((int)(MatchDuration - Timer));
        }
        GameOn = false;
        PoolManagerScript.instance.ResetAllObj();
        AudioManagerScript.instance.StopPlayer();
        indicator.position = new Vector3(1000, 1000, 1000);
        yield return UIManagerScript.instance.GameEnded();
        Money = 0;
    }
}
