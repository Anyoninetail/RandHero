using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleTextManager : MonoBehaviour
{
    public string originText;
    public float textSpeed;
    public bool isReading;
    public bool isNotInTheMap;
    public int textNum;
    public GameObject skipButton;
    public Image nextButtonImage;
    public Text dialog;
    public BattleManager battleManager;

    void Start()
    {
        LoadTextMap();
        isNotInTheMap = false;
        textNum = 10000;
        StartText(true);
    }

    public void StartText(bool FetchOrigin)
    {
        isReading = true;
        if(FetchOrigin)
        {
            originText = battleTextMap.GetValueOrDefault(textNum);
        }
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
            StartText(true);
        }
        else if(isNotInTheMap)
        {
            switch(textNum)
            {
                case 0:
                    originText = BattleManager.mobName + "의 주사위 : " + battleManager.enemyDiceCount;
                    if (battleManager.diceCount > battleManager.enemyDiceCount)
                    {
                        textNum = 1;
                    }
                    else if (battleManager.diceCount == battleManager.enemyDiceCount)
                    {
                        textNum = 2;
                    }
                    else
                    {
                        textNum = 3;
                    }
                    break;
                case 1:
                    originText = TextManager.playerName + "(이)가 " + BattleManager.mobName + "에게 " + (battleManager.diceCount - battleManager.enemyDiceCount) + "의 피해를 입혔다.";
                    battleManager.HealthReduse();
                    isNotInTheMap = false;
                    break;
                case 2:
                    originText = "그 누구도 피해를 입지 않았다.";
                    isNotInTheMap = false;
                    break;
                case 3:
                    originText = BattleManager.mobName + "(이)가 " + TextManager.playerName + "에게 " + (battleManager.enemyDiceCount - battleManager.diceCount) + "의 피해를 입혔다.";
                    battleManager.HealthReduse();
                    isNotInTheMap = false;
                    break;
            }
            StartText(false);
        }
        else
        {
            if (textNum == 20002 || textNum == 30002)
            {
                SceneLoader.Instance.LoadScene("TextScene");
            }
            battleManager.Next();
        }
    }

    public void HitResult()
    {
        isNotInTheMap = true;
        textNum = 0;
        originText = TextManager.playerName + "의 주사위 : " + battleManager.diceCount;
        StartText(false);
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
        //승리
        battleTextMap.Add(20000, BattleManager.mobName + "은(는) 쓰러졌다.");
        battleTextMap.Add(20001, TextManager.playerName + "의 승리!");
        battleTextMap.Add(20002, "전투 종료!");
        //패배
        battleTextMap.Add(30000, TextManager.playerName + "은(는) 쓰러졌다.");
        battleTextMap.Add(30001, TextManager.playerName + "의 패배...");
        battleTextMap.Add(30002, "전투 종료...");
    }
}
