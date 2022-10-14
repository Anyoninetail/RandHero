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

        //��Ʈ��
        battleTextMap.Add(10000, "���� ����!");

        battleTextMap.Add(20000, TextManager.playerName + "�� �ֻ��� : " + battleManager.diceCount);
        battleTextMap.Add(20001, battleManager.mobName + "�� �ֻ��� : " + battleManager.enemyDiceCount);

        //�÷��̾� ����
        battleTextMap.Add(21000, TextManager.playerName + "(��)�� " + battleManager.mobName + "���� " + (battleManager.diceCount - battleManager.enemyDiceCount) + "�� ���ظ� ������.");
        //�� ����
        battleTextMap.Add(22000, battleManager.mobName + "(��)�� " + TextManager.playerName + "���� " + (battleManager.enemyDiceCount - battleManager.diceCount) + "�� ���ظ� ������.");
        //����
        battleTextMap.Add(23000, "�� ������ ���ظ� ���� �ʾҴ�.");
        //�¸�
        battleTextMap.Add(30000, battleManager.mobName + "��(��) ��������.");
        battleTextMap.Add(30001, TextManager.playerName + "�� �¸�!");
        //�й�
        battleTextMap.Add(40000, TextManager.playerName + "��(��) ��������.");
        battleTextMap.Add(40001, TextManager.playerName + "�� �й�...");
    }
}
