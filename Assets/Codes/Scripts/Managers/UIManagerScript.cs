using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManagerScript : MonoBehaviour
{
    public static UIManagerScript instance;

    [SerializeField] private CanvasGroup StartPanel;
    [SerializeField] private CanvasGroup CountDownPanel;
    [SerializeField] private CanvasGroup GameOverPanel;
    [SerializeField] private TextMeshProUGUI CountDownText;
    [SerializeField] private int countDown;


    public TextMeshProUGUI Money;
    public TextMeshProUGUI Timer;
    public TextMeshProUGUI GameEndedMoney;
    public float GameOverDuration = 3;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        GameManagerScript.instance.UpdateMoneyEvent += Instance_UpdateMoneyEvent;
        GameManagerScript.instance.UpdateTimeEvent += Instance_UpdateTimeEvent;
    }

    private void Instance_UpdateTimeEvent(int time)
    {
        Timer.text = time.ToString();
    }

    private void Instance_UpdateMoneyEvent(int money)
    {
        Money.text = money.ToString();  
    }

    public IEnumerator CountDown()
    {
        CountDownPanel.alpha = 1;
        float timer = countDown;
        while (timer > 0)
        {
            yield return null;
            timer -= Time.deltaTime;
            CountDownText.text = ((int)timer + 1).ToString();
        }
        CountDownText.text = "Go!!!";
        yield return new WaitForSecondsRealtime(1);
        CountDownPanel.alpha = 0;
    }

    public void StartGame()
    {
        StartPanel.alpha = 0;
        SetInteractability(StartPanel, false);
        GameManagerScript.instance.StartGame();
    }

    public void BackToMainMenu()
    {
        StartPanel.alpha = 1;
        SetInteractability(StartPanel, true);
    }

    private void SetInteractability(CanvasGroup c, bool interactability)
    {
        c.interactable = interactability;
        c.blocksRaycasts = interactability;
    }

    public IEnumerator GameEnded()
    {
        GameEndedMoney.text = Money.text;
        GameOverPanel.alpha = 1;
        yield return new WaitForSecondsRealtime(GameOverDuration);
        GameOverPanel.alpha = 0;
        BackToMainMenu();
    }

}
