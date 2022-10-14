using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int mobType;
    public static int dayEncounterLeft = 3;
    public static int dayLeft = 15;
    public Text daysRemain;
    public Text currentDay;
    public Text playerNameText;
    public GameObject nextDay;
    public TextManager textManager;

    void Start()
    {
        daysRemain.text = "마왕성\n도착까지\n" + dayLeft + "일";
        playerNameText.text = TextManager.playerName;
    }

    public void ShowNextDay()
    {
        if(dayLeft > 0)
        {
            currentDay.text = 16 - dayLeft-- + "일차";
            nextDay.SetActive(true);
        }
    }

    public void Encounter()
    {
        if(dayEncounterLeft == 0)
        {
            ShowNextDay();
        }
        else
        {
            switch (Random.Range(0, 10))
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    textManager.textNum = 20000;
                    textManager.nextTextNum = Random.Range(1, 5) * 1000;
                    break;

                case 4:
                case 5:
                case 6:
                case 7:
                    textManager.textNum = 30000;
                    textManager.nextTextNum = Random.Range(1, 5) * 1000;
                    break;

                case 8:
                case 9:
                    textManager.textNum = 40000;
                    textManager.nextTextNum = Random.Range(1, 3) * 1000;
                    break;

                default:
                    textManager.textNum = 90000;
                    break;
            }

            textManager.StartText();
            dayEncounterLeft--;
        }
    }

    public void EncounterResult()
    {
        switch(textManager.textNum)
        {
            case 10018: //인트로 끝났을 때
                Encounter();
                ShowNextDay();
                break;
            //전투 개시
            case 21003:
                mobType = 0; //몹타입 0 == 슬라임
                break;
            case 22003:
                mobType = 1; //몹타입 1 == 오크
                break;
            case 23007:
                mobType = 2; //몹타입 2 == 고블린
                break;
            case 24102:
                mobType = 3; //몹타입 3 == 미믹
                break;
            case 31005:
                mobType = 4; //몹타입 4 == 이교도
                break;

            //전투 외 행동
            default:
                Debug.Log("예상 외의 케이스가 발생했습니다.");
                Encounter();
                break;
        }
    }
}
