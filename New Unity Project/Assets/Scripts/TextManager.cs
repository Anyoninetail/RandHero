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
    public Image nextButtonImage;
    public string playerName;

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
        nextButtonImage.gameObject.SetActive(false);
        StartCoroutine("TextWork");
    }

    public void SkipText()
    {
        if(isReading)
        {
            StopCoroutine("TextWork");
            dialog.text = originText;
            nextButtonImage.gameObject.SetActive(true);
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
            nextButtonImage.gameObject.SetActive(false);
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
        nextButtonImage.gameObject.SetActive(true);
        yield break;
    }












































































































    Dictionary<int, string> textMap;

    void loadTextMap()
    {
        textMap = new Dictionary<int, string>();

        //��Ʈ��
        textMap.Add(10000, playerName + ".");
        textMap.Add(10001, "�״� ��Ű �ձ��� �� ������ ���ڲ��� ���̾���.");
        textMap.Add(10002, "���� ����Ư�� '�ֻ��� ����'�� �ձ� ������ �����̶� �ҹ��� �� ��������.");
        textMap.Add(10003, "������ �׷� �׿��Ե� �̱� �� ���°� �־�����...");
        textMap.Add(10004, "�װ� �ٷ� ��⿴��.......");
        textMap.Add(10005, "���� ��� ����� ���� �״� �����ϴ� �� ������..");
        textMap.Add(10006, "���� �޿� �θ���� ���� �̷��� ���ߴ� :");
        textMap.Add(10007, "\"" + playerName + ", �� ���⼭ ������ ����� �ƴϴ�!\"");
        textMap.Add(10008, "\"�� ���������� ��� �ʴ� ����� �Ǹ� Ÿ���ܴ�.\"");
        textMap.Add(10009, "\"�̷����� �����̳� �Ұ� �ƴ϶���!\"");
        textMap.Add(10010, "�� ���� ���� " + playerName + "��(��) ���� �ʾҴ�.");
        textMap.Add(10011, "���հ��� ������ ���� �� ���� �� ����ΰ�..");
        textMap.Add(10012, "������ �״� �� �˰� �Ǿ���.");
        textMap.Add(10013, "�޿��� �θ���� ���� �� " + playerName + "��(��) �ְ��� ���ڲ��� �ڸ��� ������ �Ǵµ�,");
        textMap.Add(10014, "���̾��Ե� �ְ��� ���ڲ��� �ǰ� �� ������ �ʾ� ������ ��Ÿ���ٴ� �ҽ��� ����� ���̴�.");
        textMap.Add(10015, "�Դٰ� �� ������ �ο��� �ƴ� �������� ��θ� ������Ű�� �ִٰ� �Ѵ�...");
        textMap.Add(10016, "�� ������ �������� ���� ����� �ڽŹۿ� ���ٴ� ���� ������ " + playerName + "��(��) ���踦 ���ϱ� ���� ���迡 ������ �Ǵµ�...");

        
        //��(����) ��ī����
        textMap.Add(11000, playerName + "��(��) ��ȭ�Ӱ� ������ �ŴҰ� �־���.");
        textMap.Add(11001, "���� �����ʹ� �Ҹ��� ������ ��å�ϴ� " + playerName + "��(��) ������ ������ �޴´�.");
        textMap.Add(11002, "�� �� Ǯ�� �ʸӿ� ���� �ִ�.");
        textMap.Add(11003, playerName + "��(��) �������� Ȯ���غ���� �ߴ�.");

        //������ ��ī����
        textMap.Add(11100, playerName + "��(��) Ǯ���� ������ �а� �ʸӸ� �鿩�� ���Ҵ�.");
        textMap.Add(11101, "�װ���.....");
        textMap.Add(11102, "���ݾ� ���� �������� �־���.");
        textMap.Add(11103, playerName + "��(��) �������� ��ġ�ϱ� ���� �ο��� �ɾ���!");

        //��ũ ��ī����
        textMap.Add(11200, playerName + "��(��) Ǯ���� ��ġ�� ������ ���ư���.");
        textMap.Add(11201, "�װ���.....");
        textMap.Add(11202, "��ũ�� �����̷� ��ϰ� �־���.");
        textMap.Add(11203, playerName + "��(��) ��ũ ȥ�� ��ϴ°� �������� �ο��� �ɾ���!");

        //��� ��ī����
        textMap.Add(11300, playerName + "��(��) ������ Ǯ���� ��ġ�� ���Դ�.");
        textMap.Add(11301, "�װ���.....");
        textMap.Add(11302, "����� ���� ������ �İ� �־���.");
        textMap.Add(11303, playerName + "��(��) ����� ã�°� �������� �ñ��� ��ٷȴ�.");
        textMap.Add(11304, "�󸶳� ��ٷ�����...");
        textMap.Add(11305, "����� ������ �ƴ��� ���� �Ĵ� ���� �׸��ξ���.");
        textMap.Add(11306, playerName + "��(��) �Ӹ��� �����̸� �ֺ��� �ѷ����� ����� ���� �����ƴ�.");
        textMap.Add(11304, "����� �ο��� �ɾ�Դ�!");

        //���� ��ī����
        textMap.Add(11400, playerName + "��(��) Ǯ�� ������ ���Ƴ��Դ�.");
        textMap.Add(11401, "�װ���.....");
        textMap.Add(11402, "Ȳ�ݺ� �������ڰ� �־���!!");
        textMap.Add(11403, "�ų� " + playerName + "��(��) �������ڸ� ����Ҵ�.");
        textMap.Add(11404, "�������� �ȿ���.....");
        //���ڰ� ��� �̹�
        textMap.Add(11410, "�̻���.. �־���.");
        textMap.Add(11411, "�������ڴ� ��� �̹��̾���!");
        textMap.Add(11412, "���� ������ ���� �̹��� �ο��� �ɾ�Դ�!");
        //���ڿ� ������ ����
        textMap.Add(11420, "��ȭ�� �����ߴ�!!");
        textMap.Add(11421, playerName + "��(��) �ų��� ������ �����Ҵ�.");

        
        //����(����) ��ī����

    }
}
