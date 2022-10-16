using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.ProjectWindowCallback;
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
    public Text randomGameButtonText;
    public Image hpBar;
    public Image coin;
    public Image encounterImage;
    public Sprite[] coinImages;
    public Sprite[] encounterImages;
    public GameObject nextDay;
    public GameObject shop;
    public GameObject randomGame;
    public GameObject closeRandomGame;
    public GameObject selectPanel;
    public Button randomGameButton;
    public Button coinFront;
    public Button coinBack;
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
        if(dayLeft <= 0)
        {
            BossEncounter();
        }
        else
        {
            Encounter();
        }
    }

    public void Encounter()
    {
        if(hp == 0)
        {
            GameOver();
            return;
        }
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
            if(dayEncounterLeft == 3)
            {
                textManager.StartText();
            }
            else
            {
                textManager.StartText(true);
            }
            dayEncounterLeft--;
        }
    }

    public void ChangeEncounterImage()
    {
        switch(textManager.textNum)
        {
            //��
            case 20000:
            case 40000:
                encounterImage.sprite = encounterImages[0];
                break;
            //����
            case 30000:
                encounterImage.sprite = encounterImages[1];
                break;
            //��õ��
            case 40003:
                encounterImage.sprite = encounterImages[2];
                break;
            //��Ʈ��
            case 10000:
                encounterImage.sprite = encounterImages[3];
                break;
            //���ռ�
            case 60000:
                encounterImage.sprite = encounterImages[4];
                break;
            default:
                break;
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
            case 62004:
                mobType = 5; //��Ÿ�� 5 == ����
                SceneLoader.Instance.LoadScene("BattleScene");
                break;

            //���� �� �ൿ
            //�������ڿ� ��ȭ�� ����?!
            case 24201:
                money += 15;
                Encounter();
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
            //��������(�������� �������̽� ����)
            case 34006:
                randomGame.SetActive(true);
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
            //�ƹ� ��ȭ�� ����
            case 42002:
            case 67993:
                Debug.Log("ü�°� ���� ��ȭ�� �����ϴ�.");
                Encounter();
                break;
            //����
            case 61014:
            case 70011:
                SceneLoader.Instance.LoadScene("Title");
                break;
            //����
            default:
                Debug.Log("���� ���� ���̽��� �߻��߽��ϴ�.");
                Encounter();
                break;
        }
        if(money < 0)
        {
            money = 0;
        }
        if(hp < 0)
        {
            hp = 0;
            hpBar.fillAmount = 0;
        }
        else
        {
            hpBar.fillAmount = hp / 25.0f;
        }
        moneyText.text = "������ �� : " + money + "���";
    }

    public void BattleResult()
    {
        if(BattleManager.isWin && mobType == 5)
        {
            GameClear();
        } 
        else if(BattleManager.isWin)
        {
            money += 5;
            moneyText.text = "������ �� : " + money + "���";
        }
        else if(mobType != 5)
        {
            hp -= 5;
            hpBar.fillAmount = hp / 25.0f;
        }
        else
        {
            hp = 0;
            hpBar.fillAmount = 0;
            GameOver();
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

    public void StartRandomGame()
    {
        if (money >= 3)
        {
            closeRandomGame.SetActive(false);
            randomGameButton.interactable = false;
            randomGameButtonText.text = "��� ������ ��󺸼���";
            coinFront.enabled = true;
            coinBack.enabled = true;
        }
    }

    public void SelectFront()
    {
        RandomGameResult(true);
    }

    public void SelectBack()
    {
        RandomGameResult(false);
    }

    public void RandomGameResult(bool isFrontSelected)
    {
        selectPanel.SetActive(false);
        coin.gameObject.SetActive(true);
        if (Random.Range(0, 2) == 1)
        {
            StartCoroutine(FlipCoin(2160, isFrontSelected));
        }
        else
        {
            StartCoroutine(FlipCoin(2160 - 180, isFrontSelected));
        }
        
    }
    
    public void StopCoin(bool isFront, bool isFrontSelected)
    {
        if(isFront == isFrontSelected)
        {
            money += 3;
            moneyText.text = "������ �� : " + money + "���";
        }
        else
        {
            money -= 3;
            moneyText.text = "������ �� : " + money + "���";
        }
        StartCoroutine("ResetRandomGame");
    }

    IEnumerator FlipCoin(int degree, bool isFrontSelected)
    {
        for(int i = 0; i < 240; i++)
        {
            coin.transform.Rotate(Vector3.right * (degree / 240));
            yield return new WaitForSeconds(0.01f);
            if(coin.transform.rotation.x < 180)
            {
                coin.sprite = coinImages[1];
            }
            else
            {
                coin.sprite = coinImages[0];
            }
        }
        if(degree == 2160)
        {
            StopCoin(false, isFrontSelected);
        }
        else
        {
            StopCoin(true, isFrontSelected);
        }
    }

    IEnumerator ResetRandomGame()
    {
        yield return new WaitForSecondsRealtime(2.0f);
        coinFront.enabled = false;
        coinBack.enabled = false;
        coin.gameObject.SetActive(false);
        selectPanel.SetActive(true);
        randomGameButtonText.text = "�����ϱ�(3��� �ʿ�)";
        randomGameButton.interactable = true;
        closeRandomGame.SetActive(true);
    }

    public void CloseRandomGame()
    {
        randomGame.SetActive(false);
        Encounter();
    }

    public void GameClear()
    {
        textManager.textNum = 70000;
        textManager.nextTextNum = -1;
        textManager.StartText();
    }

    public void GameOver()
    {
        textManager.textNum = 80000;
        textManager.nextTextNum = -1;
        textManager.StartText();
    }

    public void BossEncounter()
    {
        textManager.textNum = 60000;
        textManager.nextTextNum = Random.Range(1, 3) * 1000;
        textManager.StartText();
    }
}
