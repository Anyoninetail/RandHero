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
        daysRemain.text = "���ռ�\n��������\n" + dayLeft + "��";
        playerNameText.text = TextManager.playerName;
        moneyText.text = "������ �� : " + money + "���";
        hpBar.fillAmount = hp / 25.0f;
    }

    public void ShowNextDay()
    {
        if(dayLeft > 0)
        {
            currentDay.text = 16 - dayLeft-- + "����";
            daysRemain.text = "���ռ�\n��������\n" + dayLeft + "��";
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
            case 10018: //��Ʈ�� ������ ��
                ShowNextDay();
                break;
            //���� ����
            case 21003:
                mobType = 0; //��Ÿ�� 0 == ������
                SceneLoader.Instance.LoadScene("BattleScene");
                break;
            case 22003:
                mobType = 1; //��Ÿ�� 1 == ��ũ
                SceneLoader.Instance.LoadScene("BattleScene");
                break;
            case 23007:
                mobType = 2; //��Ÿ�� 2 == ���
                SceneLoader.Instance.LoadScene("BattleScene");
                break;
            case 24102:
                mobType = 3; //��Ÿ�� 3 == �̹�
                SceneLoader.Instance.LoadScene("BattleScene");
                break;
            case 31005:
                mobType = 4; //��Ÿ�� 4 == �̱���
                SceneLoader.Instance.LoadScene("BattleScene");
                break;

            //���� �� �ൿ
            //�������ڿ� ��ȭ�� ����?!
            case 24101:
                money += 15;
                break;
            //����(�̱��� ������� ���� hp 5 ����, ���� ���� �� 3 ����) 
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
            //����(���� �������̽� ����)
            case 33003:
                shop.SetActive(true);
                break;
            //�߹���(�߹��� �������̽� ����)
            case 34006:
                break;
            //��õ��(�� ������ �������� hp 3 , �� 5 ����)
            case 41004:
                hp -= 3;
                money -= 5;
                Encounter();
                break;
            //���� ��
            case 50001:
            case 51001:
                Encounter();
                break;
            default:
                Debug.Log("���� ���� ���̽��� �߻��߽��ϴ�.");
                Encounter();
                break;
        }
        if(money < 0)
        {
            money = 0;
        }
        moneyText.text = "������ �� : " + money + "���";
        hpBar.fillAmount = hp / 25.0f;
    }

    public void BattleResult()
    {
        if(BattleManager.isWin)
        {
            money += 5;
            moneyText.text = "������ �� : " + money + "���";
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
            moneyText.text = "������ �� : " + money + "���";
        }
    }

    public void CloseShop()
    {
        shop.SetActive(false);
        Encounter();
    }
}
