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
        daysRemain.text = "���ռ�\n��������\n" + dayLeft + "��";
        playerNameText.text = TextManager.playerName;
    }

    public void ShowNextDay()
    {
        if(dayLeft > 0)
        {
            currentDay.text = 16 - dayLeft-- + "����";
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
            case 10018: //��Ʈ�� ������ ��
                Encounter();
                ShowNextDay();
                break;
            //���� ����
            case 21003:
                mobType = 0; //��Ÿ�� 0 == ������
                break;
            case 22003:
                mobType = 1; //��Ÿ�� 1 == ��ũ
                break;
            case 23007:
                mobType = 2; //��Ÿ�� 2 == ���
                break;
            case 24102:
                mobType = 3; //��Ÿ�� 3 == �̹�
                break;
            case 31005:
                mobType = 4; //��Ÿ�� 4 == �̱���
                break;

            //���� �� �ൿ
            default:
                Debug.Log("���� ���� ���̽��� �߻��߽��ϴ�.");
                Encounter();
                break;
        }
    }
}
