using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int mobType;
    public static int dayEncounterLeft;
    public static int dayLeft;
    public static bool isIntro = true;
    public static int money;
    public static int hp;
    public Text daysRemain;
    public Text currentDay;
    public Text playerNameText;
    public Text moneyText;
    public Image hpBar;
    public GameObject nextDay;
    public GameObject shop;
    public TextManager textManager;

    void Start()
    {
        if(isIntro)
        {
            money = 5;
            hp = 25;
            dayEncounterLeft = 3;
            dayLeft = 15;
            isIntro = false;
        }
        daysRemain.text = "마왕성\n도착까지\n" + dayLeft + "일";
        playerNameText.text = TextManager.playerName;
        moneyText.text = "보유한 돈 : " + money + "골드";
        hpBar.fillAmount = hp / 25.0f;
    }

    public void ShowNextDay()
    {
        if(dayLeft > 0)
        {
            currentDay.text = 16 - dayLeft-- + "일차";
            daysRemain.text = "마왕성\n도착까지\n" + dayLeft + "일";
            nextDay.SetActive(true);
            dayEncounterLeft = 3;
            StartCoroutine("Wait");
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(3f);
        nextDay.SetActive(false);
        Encounter();
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
                ShowNextDay();
                break;
            //전투 개시
            case 21003:
                mobType = 0; //몹타입 0 == 슬라임
                SceneLoader.Instance.LoadScene("BattleScene");
                break;
            case 22003:
                mobType = 1; //몹타입 1 == 오크
                SceneLoader.Instance.LoadScene("BattleScene");
                break;
            case 23007:
                mobType = 2; //몹타입 2 == 고블린
                SceneLoader.Instance.LoadScene("BattleScene");
                break;
            case 24102:
                mobType = 3; //몹타입 3 == 미믹
                SceneLoader.Instance.LoadScene("BattleScene");
                break;
            case 31005:
                mobType = 4; //몹타입 4 == 이교도
                SceneLoader.Instance.LoadScene("BattleScene");
                break;

            //전투 외 행동
            //보물상자에 금화가 가득?!
            case 24101:
                money += 15;
                break;
            //주점(이교도 만난경우 제외 hp 5 증가, 무슨 경우든 돈 3 감소) 
            case 32105:
            case 32205:
                hp += 5;
                money -= 3;
                Encounter();
                break;
            case 32305:
                money -= 3;
                Encounter();
                break;
            //상인(상점 인터페이스 열기)
            case 33003:
                shop.SetActive(true);
                break;
            //야바위(야바위 인터페이스 열기)
            case 34006:
                break;
            //악천후(비를 피하지 못했을때 hp 3 , 돈 5 감소)
            case 41004:
                hp -= 3;
                money -= 5;
                Encounter();
                break;
            //전투 후
            case 50001:
            case 51001:
                Encounter();
                break;
            default:
                Debug.Log("예상 외의 케이스가 발생했습니다.");
                Encounter();
                break;
        }
        if(money < 0)
        {
            money = 0;
        }
        moneyText.text = "보유한 돈 : " + money + "골드";
        hpBar.fillAmount = hp / 25.0f;
    }

    public void BattleResult()
    {
        if(BattleManager.isWin)
        {
            money += 5;
            moneyText.text = "보유한 돈 : " + money + "골드";
        }
        else
        {
            hp -= 5;
            hpBar.fillAmount = hp / 25.0f;
        }
    }

    public void BuyPotion()
    {
        if (money >= 5)
        {
            money -= 5;
            if(hp + 5 > 25)
            {
                hp = 25;
            }
            else
            {
                hp += 5;
            }
            hpBar.fillAmount = hp / 25.0f;
            moneyText.text = "보유한 돈 : " + money + "골드";
        }
    }

    public void CloseShop()
    {
        shop.SetActive(false);
        Encounter();
    }
}
