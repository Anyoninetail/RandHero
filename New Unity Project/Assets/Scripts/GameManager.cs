using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int dayEncounterLeft;
    public int dayLeft;
    public Text daysRemain;
    public Text currentDay;
    public Text playerName;
    public GameObject nextDay;
    public TextManager textManager;

    void Start()
    {
        dayLeft = 15;
        dayEncounterLeft = 3;
        daysRemain.text = "¸¶¿Õ¼º\nµµÂø±îÁö\n" + dayLeft + "ÀÏ";
        playerName.text = textManager.playerName;
    }

    public void ShowNextDay()
    {
        currentDay.text = 16 - --dayLeft + "ÀÏÂ÷";
        nextDay.SetActive(true);
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
}
