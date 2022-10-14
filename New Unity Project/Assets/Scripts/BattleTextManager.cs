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

        battleTextMap.Add(10000, TextManager.playerName + "�� �ֻ��� : " + diceCount);
        battleTextMap.Add(10001, battleManager.mobName + "�� �ֻ��� : " + enemyDiceCount);

        //�÷��̾� ����
        battleTextMap.Add(11000, TextManager.playerName + "(��)�� " + battleManager.mobName + "���� " + (diceCount - enemyDiceCount) + "�� ���ظ� ������.");
        //�� ����
        battleTextMap.Add(12000, battleManager.mobName + "(��)�� " + TextManager.playerName + "���� " + (enemyDiceCount - diceCount) + "�� ���ظ� ������.");
        //����
        battleTextMap.Add(13000, "�� ������ ���ظ� ���� �ʾҴ�.");
        //�¸�
        battleTextMap.Add(20000, battleManager.mobName + "��(��) ��������.");
        battleTextMap.Add(20000, TextManager.playerName + "�� �¸�!");
        //�й�
        battleTextMap.Add(20000, TextManager.playerName + "��(��) ��������.");
        battleTextMap.Add(20000, TextManager.playerName + "�� �й�...");
    }
}
