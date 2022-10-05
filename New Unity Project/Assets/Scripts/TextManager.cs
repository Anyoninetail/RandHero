using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public string originText;
    public Text dialog;
    public float textSpeed;
    public bool isReading;
    public int textNum;
    public GameObject skipButton;

    void Start()
    {
        loadTextMap();
        textNum = 10000;
        originText = textMap.GetValueOrDefault(textNum);
        StartText();
    }

    public void StartText()
    {
        skipButton.SetActive(true);
        dialog.text = "";
        isReading = true;
        StartCoroutine("TextWork");
    }

    public void SkipText()
    {
        if(isReading)
        {
            StopCoroutine("TextWork");
            dialog.text = originText;
            isReading = false;
            
        }
        else if(textMap.GetValueOrDefault(textNum + 1) != null)
        {
            originText = textMap.GetValueOrDefault(++textNum);
            isReading = true;
            StartText();
        }
        else
        {
            skipButton.SetActive(false);
            dialog.text = "";
        }
    }

    IEnumerator TextWork()
    {
        for(int i = 0; i <= originText.Length; i++)
        {
            yield return new WaitForSecondsRealtime(textSpeed);
            dialog.text = originText.Substring(0, i);
        }
        isReading = false;
        yield break;
    }












































































































    Dictionary<int, string> textMap;

    void loadTextMap()
    {
        textMap = new Dictionary<int, string>();

        textMap.Add(10000, "(�÷��̾�).");
        textMap.Add(10001, "�״� ��Ű �ձ��� �� ������ ���ڲ��� ���̾���.");
        textMap.Add(10002, "���� ����Ư�� '�ֻ��� ����'�� �ձ� ������ �����̶� �ҹ��� �� ��������.");
        textMap.Add(10003, "������ �׷� �׿��Ե� �̱� �� ���°� �־�����...");
        textMap.Add(10004, "�װ� �ٷ� ��⿴��.......");
        textMap.Add(10005, "���� ��� ����� ���� �״� �����ϴ� �� ������..");
        textMap.Add(10006, "���� �޿� �θ���� ���� �̷��� ���ߴ� :");
        textMap.Add(10007, "\"(�÷��̾�), �� ���⼭ ������ ����� �ƴϴ�!\"");
        textMap.Add(10008, "\"�� ���������� ��� �ʴ� ����� �Ǹ� Ÿ���ܴ�.\"");
        textMap.Add(10009, "\"�̷����� �����̳� �Ұ� �ƴ϶���!\"");
        textMap.Add(10010, "�� ���� ���� (�÷��̾�)�� ���� �ʾҴ�.");
        textMap.Add(10011, "���հ��� ������ ���� �� ���� �� ����ΰ�..");
        textMap.Add(10012, "������ �״� �� �˰� �Ǿ���.");
        textMap.Add(10013, "�޿��� �θ���� ���� �� (�÷��̾�)�� �ְ��� ���ڲ��� �ڸ��� ������ �Ǵµ�,");
        textMap.Add(10014, "���̾��Ե� �ְ��� ���ڲ��� �ǰ� �� ������ �ʾ� ������ ��Ÿ���ٴ� �ҽ��� ����� ���̴�.");
        textMap.Add(10015, "�Դٰ� �� ������ �ο��� �ƴ� �������� ��θ� ������Ű�� �ִٰ� �Ѵ�...");
        textMap.Add(10016, "�� ������ �������� ���� ����� �ڽŹۿ� ���ٴ� ���� ������ (�÷��̾�)�� ���踦 ���ϱ� ���� ���迡 ������ �Ǵµ�...");
    }
}
