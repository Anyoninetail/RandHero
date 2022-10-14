using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public static string playerName = "[�÷��̾�]";
    public string originText;
    public float textSpeed;
    public bool isReading;
    public int textNum;
    public int nextTextNum;
    public GameManager gameManager;
    public GameObject skipButton;
    public Image nextButtonImage;
    public Text dialog;

    void Start()
    {
        LoadTextMap();
        textNum = 10000;
        nextTextNum = -1;
        StartText();
    }

    public void StartText()
    {
        isReading = true;
        originText = textMap.GetValueOrDefault(textNum);
        skipButton.SetActive(true);
        dialog.text = "";
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
            StartText();
        }
        else if(nextTextNum != -1)
        {
            textNum += nextTextNum;
            switch(textNum)
            { 
                case 24003:
                    nextTextNum = Random.Range(1, 3) * 100;
                    break;
                case 32002:
                    nextTextNum = Random.Range(1, 4) * 100;
                    break;
                default:
                    nextTextNum = -1;
                    break;
            }
            textNum -= textNum % 100;
            originText = textMap.GetValueOrDefault(textNum);

            StartText();
        }
        else
        {
            skipButton.SetActive(false);
            nextButtonImage.gameObject.SetActive(false);
            dialog.text = "";
            gameManager.EncounterResult();
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

    private void LoadTextMap()
    {
        textMap = new Dictionary<int, string>();

        //��Ʈ��
        textMap.Add(10000, "'" + playerName + "'.");
        textMap.Add(10001, "�״� ��Ű �ձ��� �� ������ ���ڲ��� ���̾���.");
        textMap.Add(10002, "�װ� ������ �ֻ����� ����� ���� �ູ�� �޾Ҵٴ� �ҹ��� �� ��������.");
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
        textMap.Add(10015, "�Դٰ� �� ������ ���� ���� ���ְ� �� ���̾�����.");
        textMap.Add(10016, "���� ���縦 ������ ������ �������� �������� �Ǵ� ���ֿ���.......");
        textMap.Add(10017, "'�׷� �� ���ڲ��� �ƴ϶� ��簡 �� �ų�..?'");
        textMap.Add(10018, "�׷��� ������ ����� ���� ��� '" + playerName + "'�� ������ ���۵Ǿ���.");


        //��(����) ��ī����
        textMap.Add(20000, playerName + "��(��) ��ȭ�Ӱ� ������ �ŴҰ� �־���.");
        textMap.Add(20001, "���� �����ʹ� �Ҹ��� ������ ��å�ϴ� " + playerName + "��(��) ������ ������ �޴´�.");
        textMap.Add(20002, "�� �� Ǯ�� �ʸӿ� ���� �ִ�.");
        textMap.Add(20003, playerName + "��(��) �������� Ȯ���غ���� �ߴ�.");

        //������ ��ī����
        textMap.Add(21000, playerName + "��(��) Ǯ���� ������ �а� �ʸӸ� �鿩�� ���Ҵ�.");
        textMap.Add(21001, "�װ���.....");
        textMap.Add(21002, "���ݾ� ���� �������� �־���.");
        textMap.Add(21003, playerName + "��(��) �������� ��ġ�ϱ�� �����Ծ���.");  //����

        //��ũ ��ī����
        textMap.Add(22000, playerName + "��(��) Ǯ���� ��ġ�� ������ ���ư���.");
        textMap.Add(22001, "�װ���.....");
        textMap.Add(22002, "��ũ�� �Ŵ��� �����̷� ��ϰ� �־���.");
        textMap.Add(22003, "��ϴ��� ��Ų ��ũ�� �β��������� �ο��� �ɾ�Դ�!");  //����

        //��� ��ī����
        textMap.Add(23000, playerName + "��(��) ������ Ǯ���� ��ġ�� ���Դ�.");
        textMap.Add(23001, "�װ���.....");
        textMap.Add(23002, "����� ���� ������ �İ� �־���.");
        textMap.Add(23003, playerName + "��(��) ����� ã�°� �������� �ñ��� ��ٷȴ�.");
        textMap.Add(23004, "�󸶳� ��ٷ�����...");
        textMap.Add(23005, "����� ������ �ƴ��� ���� �Ĵ� ���� �׸��ξ���.");
        textMap.Add(23006, playerName + "��(��) �Ӹ��� �����̸� �ֺ��� �ѷ����� ����� ���� �����ƴ�.");
        textMap.Add(23007, "����� �ο��� �ɾ�Դ�!");  //����

        //���� ��ī����
        textMap.Add(24000, playerName + "��(��) Ǯ�� ������ ���Ƴ��Դ�.");
        textMap.Add(24001, "�װ���.....");
        textMap.Add(24002, "Ȳ�ݺ� �������ڰ� ���� ���� �־���!!");
        textMap.Add(24003, "�ų� " + playerName + "��(��) ���� �������ڸ� �ĳ� ����Ҵ�.");
        textMap.Add(24004, "�������� �ȿ���.....");
        //���� ��ī���� - 1/���ڰ� ��� �̹�
        textMap.Add(24100, "�̻���... �־���..?");
        textMap.Add(24101, "�������ڴ� ��� �̹��̾���!");
        textMap.Add(24102, "��ü�� ��Ų�� ���� �̹��� �ο��� �ɾ�Դ�!");  //����
        //���� ��ī���� - 2/���ڿ� ������ ����
        textMap.Add(24200, "��ȭ�� �����ߴ�!!!");
        textMap.Add(24201, playerName + "��(��) �ų��� ������ �����Ҵ�.");


        //����(����) ��ī����
        textMap.Add(30000, playerName + "��(��) ��� ���� ������ �����ߴ�.");
        textMap.Add(30001, "�Ÿ��� Ȱ���ϴ� " + playerName + "��(��) ���� �߰��Ѵ�.");
        textMap.Add(30002, "�װ��� �ٷ�.....");

        //�̱��� ��ī����
        textMap.Add(31000, "������ �ֹ����� ������.");
        textMap.Add(31001, "�׳� ���������� �ϴ� �� ����� �ٰ��� ���� ���´�.");
        textMap.Add(31002, "\"Ȥ�� ���ձ��� �ƽʴϱ�?\"");
        textMap.Add(31003, "..........");
        textMap.Add(31004, "�˰��� �̱�������.");
        textMap.Add(31005, playerName + "��(��) �� ����� ������ �����ֱ�� �����Ծ���.");  //����

        //���� ��ī����
        textMap.Add(32000, "�����̾���.");
        textMap.Add(32001, "��ħ ���� �;��� " + playerName + "��(��) ���� ������ ����.");
        textMap.Add(32002, "���� ���δ� �ϳ� �о���.");
        textMap.Add(32003, "���Ḧ �ϳ� �ֹ��ϰ� ����, " + playerName + "��(��) �ֺ� ��ȭ�� �������.");
        //���� ��ī���� - 1/��� �̴�
        textMap.Add(32100, "�������� �ֹ� �θ��� ���� ��ȭ�ϰ� �־���.");
        textMap.Add(32101, "\"���� ������ ��Ÿ������?\"");
        textMap.Add(32102, "\"�¾�, ������ ���ڲ��̾��ٴ���?\"");
        textMap.Add(32103, "\"�׷� ���ְ� �ɸ� ������ ������ ���ڰڳ�.\"");
        textMap.Add(32104, "\"�׷����� ����.\"");
        textMap.Add(32105, "��� ����ִٰ� �β������� ������ �� ���ٰ� ������ " + playerName + "��(��) ���� ���Ḧ �����ϰ� Ȳ���� ������ ������.");
        //���� ��ī���� - 2/����� ����
        textMap.Add(32200, "�������� �ֹ� �Ѹ��� �ż���ź�ϰ� �־���.");
        textMap.Add(32201, "\"���� �λ�....\"");
        textMap.Add(32202, "\"����ü ���� �˰� �� �������ڸ� �İ�����..?\"");
        textMap.Add(32203, "\"�װ� ã�� ���ϸ� �� ���� �� ���� �� �����ٵ�...\"");
        textMap.Add(32204, "\"���̶� �Ⱦƾ� �ϳ�...\"");
        textMap.Add(32205, "�ҽ��� �ֹ��� �ڷ��ϰ� " + playerName + "��(��) �ٽ� �� ���� ������.");
        //���� ��ī���� - 3/���⵵ �̱�����?
        textMap.Add(32300, "�ٷ� �׶�,");
        textMap.Add(32301, "������ ���� " + playerName + "�� ���� �ɾҴ�.");
        textMap.Add(32302, "\"�λ��� ������ ���Ͻó׿� ����\"");
        textMap.Add(32303, "'��...'");
        textMap.Add(32304, "���� ����ϱ� ���� ������ ����̶� " + playerName + "��(��) �� �ڸ��� ����.");
        textMap.Add(32305, "�ڿ��� ������ ���� �ϴ� �Ҹ��� ��������� " + playerName + "��(��) �ƶ������� �ʰ� ������ ������.");

        //������ ���� ��ī����
        textMap.Add(33000, "������ �����̾���.");
        textMap.Add(33001, "���� ����ġ�� ������ �ݰ��� �󱼷� �ٰ��´�.");
        textMap.Add(33002, "\"�̾�! �ȳ��ϼ���, ����̽� �� ������ ���� �� ���ðڽ��ϱ�?\"");
        textMap.Add(33003, playerName + "��(��) ������ �ѷ����Ҵ�.");

        //�߹��� ��ī����
        textMap.Add(34000, "�Ÿ� �Ѻ��ǿ� ���� �� 3���� �տ� �ΰ� �ɾ� �־���.");
        textMap.Add(34001, playerName + "��(��) ȣ����� ���� ���ϰ� ���ϰ� �ִ��� ����Ҵ�.");
        textMap.Add(34002, "\"�����̽� �� ������... ���� ���� �ϳ� �Ͻðڽ��ϱ�?\"");
        textMap.Add(34003, "\"3���� �� �߿� ���� �ϳ� �ְ� ����ִ��� ���ߴ� �̴ϴ�.\"");
        textMap.Add(34004, "\"�����ϸ� 3�迡 3���� 1 Ȯ��, �������� �ʽ��ϱ�?\"");
        textMap.Add(34005, "'������ ��� �ĺ��� ���� �� �� ���ڲ��̾����� �˾�ç �� �ְ���...'");
        textMap.Add(34006, "'�ѹ� ��� �� ����?'");


        //��õ��(����) ��ī����
        textMap.Add(40000, playerName + "��(��) ��ҿ� ���� �Ȱ� �־���.");
        textMap.Add(40001, "�׷��� �ϴÿ��� �Ҿ��� ����� ��������.");
        textMap.Add(40002, "�ƴϳ� �ٸ���...");
        textMap.Add(40003, "�ϴÿ��� õ�չ����� ġ�� �����ߴ�!");
        textMap.Add(40004, "���̾� �� ���� ������ ������!");
        textMap.Add(40005, "��� �� ���� ���� ã�ƾ� �Ѵ�.");

        //��õ�� ��ī���� - 1/�� ������ ���ߴ�(��)
        textMap.Add(41000, "�󸶳� ��������...");
        textMap.Add(41001, playerName + "��(��) ��� ���ƴٳ����� �� ���� ���� ���� ã�� ���ߴ�.");
        textMap.Add(41002, "���� �ڿ��� �� ���ư�, " + playerName + "��(��) ���⿡ �ɸ� �� �ϴ�.");
        textMap.Add(41003, "���󰡻����� �ָӴ� �� ���� ���� ��ü�� �˾ƺ� �� ���� �Ǿ���.");
        textMap.Add(41004, playerName + "��(��) ����� �� ���� ���� �� �� ���ȴ�.");
        //��õ�� ��ī���� - 2/�� ���ߴ�(����)
        textMap.Add(42000, "������ ��ó�� �� ���� �ǹ��� �߰��� �� �־���.");
        textMap.Add(42001, playerName + "��(��) �� ��ĥ ������ �� ������ ������.");
        textMap.Add(42002, "���� �ڿ��� �� ���ư�, " + playerName + "��(��) �ٽ� �� ���� ������.");

        //���� �޼���
        textMap.Add(90000, "��ī���� ��� ������ ������ ������ϴ�.");
    }
}
