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
    public int diceCount;
    public int enemyDiceCount;
    public GameObject skipButton;
    public Image nextButtonImage;
    public Text dialog;
    public BattleManager battleManager;

    void Start()
    {
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

        battleTextMap.Add(10000, TextManager.playerName + "의 주사위 : " + diceCount);
        battleTextMap.Add(10001, battleManager.mobName + "의 주사위 : " + enemyDiceCount);

        //플레이어 우위
        battleTextMap.Add(11000, TextManager.playerName + "(이)가 " + battleManager.mobName + "에게 " + (diceCount - enemyDiceCount) + "의 피해를 입혔다.");
        //몹 우위
        battleTextMap.Add(12000, battleManager.mobName + "(이)가 " + TextManager.playerName + "에게 " + (enemyDiceCount - diceCount) + "의 피해를 입혔다.");
        //동점
        battleTextMap.Add(13000, "그 누구도 피해를 입지 않았다.");
        //승리
        battleTextMap.Add(20000, battleManager.mobName + "은(는) 쓰러졌다.");
        battleTextMap.Add(20000, TextManager.playerName + "의 승리!");
        //패배
        battleTextMap.Add(20000, TextManager.playerName + "은(는) 쓰러졌다.");
        battleTextMap.Add(20000, TextManager.playerName + "의 패배...");
    }
}
