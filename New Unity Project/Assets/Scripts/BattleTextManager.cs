using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleTextManager : MonoBehaviour
{
    public string originText;
    public float textSpeed;
    public bool isReading;
    public int textNum;
    public int nextTextNum;
    public GameObject skipButton;
    public Image nextButtonImage;
    public Text dialog;
    public BattleManager battleManager;

    void Start()
    {
        textNum = 10000;
        nextTextNum = -1;
        LoadTextMap();
    }

    public void StartText()
    {
        isReading = true;
        originText = battleTextMap.GetValueOrDefault(textNum);
        skipButton.SetActive(true);
        dialog.text = "";
        nextButtonImage.gameObject.SetActive(false);
        StartCoroutine("TextWork");
    }

    public void SkipText()
    {
        if (isReading)
        {
            StopCoroutine("TextWork");
            dialog.text = originText;
            nextButtonImage.gameObject.SetActive(true);
            isReading = false;
        }
        else if (battleTextMap.GetValueOrDefault(textNum + 1) != null)
        {
            originText = battleTextMap.GetValueOrDefault(++textNum);
            StartText();
        }
        else if(nextTextNum != -1)
        {
            textNum += nextTextNum;
            textNum -= textNum % 1000;
            nextTextNum = -1;
        }
        else
        {
            battleManager.Next();
        }
    }

    IEnumerator TextWork()
    {
        for (int i = 0; i <= originText.Length; i++)
        {
            yield return new WaitForSecondsRealtime(textSpeed);
            dialog.text = originText.Substring(0, i);
        }
        isReading = false;
        nextButtonImage.gameObject.SetActive(true);
        yield break;
    }
















































    Dictionary<int, string> battleTextMap;

    private void LoadTextMap()
    {
        battleTextMap = new Dictionary<int, string>();

        //인트로
        battleTextMap.Add(10000, "전투 개시!");

        battleTextMap.Add(20000, TextManager.playerName + "의 주사위 : " + battleManager.diceCount);
        battleTextMap.Add(20001, battleManager.mobName + "의 주사위 : " + battleManager.enemyDiceCount);

        //플레이어 우위
        battleTextMap.Add(21000, TextManager.playerName + "(이)가 " + battleManager.mobName + "에게 " + (battleManager.diceCount - battleManager.enemyDiceCount) + "의 피해를 입혔다.");
        //몹 우위
        battleTextMap.Add(22000, battleManager.mobName + "(이)가 " + TextManager.playerName + "에게 " + (battleManager.enemyDiceCount - battleManager.diceCount) + "의 피해를 입혔다.");
        //동점
        battleTextMap.Add(23000, "그 누구도 피해를 입지 않았다.");
        //승리
        battleTextMap.Add(30000, battleManager.mobName + "은(는) 쓰러졌다.");
        battleTextMap.Add(30001, TextManager.playerName + "의 승리!");
        //패배
        battleTextMap.Add(40000, TextManager.playerName + "은(는) 쓰러졌다.");
        battleTextMap.Add(40001, TextManager.playerName + "의 패배...");
    }
}
