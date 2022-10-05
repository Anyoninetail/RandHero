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

    void Start()
    {
        loadTextMap();
        textNum = 10000;
        originText = textMap.GetValueOrDefault(textNum);
        Invoke("StartText", 1.5f);
    }

    public void StartText()
    {
        dialog.text = "";
        isReading = true;
        StartCoroutine("TextWork");
    }

    public void SkipText()
    {
        if(!isReading && textMap.GetValueOrDefault(textNum + 1) != null)
        {
            originText = textMap.GetValueOrDefault(++textNum);
            isReading = true;
            StartText();
        }
        else if(isReading)
        {
            StopCoroutine("TextWork");
            dialog.text = originText;
            isReading = false;
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

        textMap.Add(10000, "�������� ���󿡴� ������� �� �ƴ� ������ ���ڻ� ����.N�� �־���...");
        textMap.Add(10001, "����.N�� ���� �Ҿ���� �ֻ����� ������ ��� �������� �����ϰ� �־���...");
        textMap.Add(10002, "�׷��� ��� ��!");
        textMap.Add(10003, "����.N�� ���࿡ �г��� ���� ����.N�� �޿� ���� ���ߴ�.");
        textMap.Add(10004, "\"���� �ֻ����� �׷� ���� ���̴ٴ�...\"");
        textMap.Add(10005, "\"�װ� �� �ֻ����� ������ ������ ����ģ�ٸ� �� �ֻ����� �������� �ʿ��� �ְڴ�.\"");
        textMap.Add(10006, "\"���� �׷��� ���ϸ�....\"");
        textMap.Add(10007, "\"���� ����� �Բ� �ֻ����� ȸ���� ���ڴ�!!\"");
        textMap.Add(10008, "�׷��� ����.N�� ���� �ֻ����� �Բ� ������ ������ �Ǵµ�.....");
    }
}
