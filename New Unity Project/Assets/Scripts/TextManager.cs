using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public static string playerName;
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
        if(GameManager.isIntro)
        {
            LoadTextMap();
            textNum = 10000;
            nextTextNum = -1;
        }
        else
        {
            LoadTextMap();

            if (BattleManager.isWin)
            {
                textNum = 50000;
            }
            else
            {
                textNum = 51000;
            }
            nextTextNum = -1;
            gameManager.BattleResult();
        }
        StartText();
    }

    public void StartText()
    {
        gameManager.ChangeEncounterImage();
        isReading = true;
        originText = textMap.GetValueOrDefault(textNum);
        skipButton.SetActive(true);
        dialog.text = "";
        nextButtonImage.gameObject.SetActive(false);
        StartCoroutine("TextWork");
    }

    public void StartText(bool isNotFirst)
    {
        gameManager.ChangeEncounterImage();
        isReading = true;
        originText = textMap.GetValueOrDefault(0);
        textNum--;
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
        else if(GameManager.money < 3 && textNum == 32000)
        {
            textNum = 67991;
            nextTextNum = -1;
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

        //��ī���� �߰�����
        textMap.Add(0, "������ ���� ��...");

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
        textMap.Add(24002, "����� �������ڰ� ���� ���� �־���!!");
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
        textMap.Add(31004, "�� ��� �̱�������.");
        textMap.Add(31005, playerName + "��(��) �� ����� ������ �����ֱ�� �����Ծ���.");  //����

        //���� ��ī����
        textMap.Add(32000, "�����̾���.");
        //���� ����
        textMap.Add(32001, "��ħ ���� �;��� " + playerName + "��(��) ���� ������ ����.");
        textMap.Add(32002, "���� ���δ� �ϳ� �о���.");
        textMap.Add(32003, "���Ḧ �ϳ� �ֹ��ϰ� ����, " + playerName + "��(��) �ֺ� ��ȭ�� �������.");
        //���̾���... ���� ����ħ
        textMap.Add(67991, "��ħ ���� �;��� " + playerName + "��(��) ���� ������ ����������...");
        textMap.Add(67992, "���Ḧ �� ���� ������� �ʾҴ�.");
        textMap.Add(67993, "�ƽ����� �̹��� �׳� ��������� �ߴ�.");
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
        textMap.Add(33002, "\"�̾�~! �ݰ����ϴ� ����. ���� �� �����Ͻðھ��?\"");
        textMap.Add(33003, playerName + "��(��) ������ ����� �ߴ�.");

        //�������� ��ī����
        textMap.Add(34000, "������ �ֹ��̾���.");
        textMap.Add(34001, playerName + "��(��) �߰��� �ֹ��� �ٰ��� ���� �ɾ���.");
        textMap.Add(34002, "\"�����̽� �� ������... ���� ��մ� ���� �ϳ� �Ͻðڽ��ϱ�?\"");
        textMap.Add(34003, "\"���� ������ ������, ������ �ո����� �޸����� �����ô� �̴ϴ�.\"");
        textMap.Add(34004, "\"���� �����ø� 3��带 �帮��, �� �����ø� 3��带 �޾ư��ڽ��ϴ�.\"");
        textMap.Add(34005, "'��ħ �ɽ��ߴµ� �ߵƳ�'");
        textMap.Add(34006, "'�ѹ� �غ���?'");


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
        textMap.Add(41003, "���󰡻����� �̸����� ���ƴٴϴ� ���� ���� �Ҿ���� �� �ϴ�.");
        textMap.Add(41004, playerName + "��(��) �ƽ����� �ٽ� ���� ���� ����� �ߴ�.");
        //��õ�� ��ī���� - 2/�� ���ߴ�(����)
        textMap.Add(42000, "������ ��ó�� �� ���� �ǹ��� �߰��� �� �־���.");
        textMap.Add(42001, playerName + "��(��) �� ��ĥ ������ �� ������ ������.");
        textMap.Add(42002, "���� �ڿ��� �� ���ư�, " + playerName + "��(��) �ٽ� �� ���� ������.");


        //���� �¸���
        textMap.Add(50000, playerName + "��(��) �������� �¸��ߴ�.");
        textMap.Add(50001, playerName + "��(��) ����ǰ�� ì�� �ٽ� �� ���� ������.");
        //���� �й��
        textMap.Add(51000, playerName + "��(��) �������� �й��ߴ�.");
        textMap.Add(51001, playerName + "��(��) ����â�̰� �� ������ �ܿ� �����ƴ�.");


        //���� ��ī����
        textMap.Add(60000, playerName + "��(��) ��ħ�� ���ռ��� �����ߴ�.");
        textMap.Add(60001, playerName + "��(��) �����Ǳ��� ���� �濡�� �ƹ� ����ü�� ������.");
        textMap.Add(60002, playerName + "��(��) ������ ���� �����Ѵ�.");
        textMap.Add(60003, playerName + "��(��) �����ǿ� �����߰�, �װ���...");
        //���� ��ī���� - 1/�ƹ��� ������.(���� ���� 1)
        textMap.Add(61000, "�ƹ���...������.....");
        textMap.Add(61001, "���� ���� �Ͼ������ �𸣰����� �����ǿ� ���� �� ���� ���� ������ �ʾҴ�.");
        textMap.Add(61002, playerName + "��(��) ���� �� �� ���̶�� ���� ������.");
        textMap.Add(61003, playerName + "��(��) ���⿡ ���ƿ��� ���� ��簡 ������ �����ƴٴ� �ҹ��� ���� �־���.");
        textMap.Add(61004, "���� ����� " + playerName + "��(��) ������ �������� ���ߴ�.");
        textMap.Add(61005, "���� ������ �׳� �Ҹ��� ���ϱ�?");
        textMap.Add(61006, ".....�ƴϸ� �ٸ� ����̰� �ִ� ���ϱ�?");
        textMap.Add(61007, "�װ� ���ո� �� �Ϳ���.");
        textMap.Add(61008, "'�׷����� ���� ������ ��ȭ�� ã�ƿ����� ������ ���̴�'");
        textMap.Add(61009, playerName + "��(��) ���� ���ư� ����� �Ѵ�.");
        textMap.Add(61010, "�ƹ� �ϵ� �������̴�.");
        textMap.Add(61011, ".....");
        textMap.Add(61012, "�Ƹ���.");
        textMap.Add(61013, "-���� ���� 1[�̰� ���� �����ϰ�.....]-");
        textMap.Add(61014, "-���� ���ٸ� �ٸ� ������ �� �� �������� �𸨴ϴ�.-");
        //���� ��ī���� - 2/������!(�¸��� ���� ���� 2, �й�� ���� ����)
        textMap.Add(62000, playerName + "�� �ֵ��� ������ �־���.");
        textMap.Add(62001, playerName + "��(��) �װ� �ҹ��� �����̶�� ���� �˾�ë��.");
        textMap.Add(62002, "� �� " + playerName + "��(��) ����� ������ ���� �ϴ� ���� ������� ��� ������ �װ�,");
        textMap.Add(62003, "����, ���⿡ �������� �־���.");
        textMap.Add(62004, "��� ����� ������ " + playerName + "��(��) �г븦 �̱��� ���ϰ� ���� ���տ��� �ο��� �ɾ���.");

        //���� ���� 2
        textMap.Add(70000, playerName + "��(��).....");
        textMap.Add(70001, "�ᱹ ������ óġ�ߴ�.");
        textMap.Add(70002, "������ ���� ��������");
        textMap.Add(70003, "������ �׾��ٴ� ����� ���İ��� ����������.");
        textMap.Add(70004, "�� ����� ��ȭ�� ã�ƿԴ�.");
        textMap.Add(70005, "��� " + playerName + "��(��) ������ �ڽ��� �ֵ��� �����̾��ٴ� ����� �������Ե� ������ �ʾҴ�.");
        textMap.Add(70006, "�ʳ� " + playerName + "��(��) ������ ����ģ ���� ���ǰ�,");
        textMap.Add(70007, "�� ������ ���հ� ��簡 �����̾��ٴ� ���� �� ���̴�.");
        textMap.Add(70008, "-���� ���� 2[�������ε� ���� �����ϳ�]-");
        textMap.Add(70009, "-���ϵ帳�ϴ�. �� ������ �������� ���̳׿�.-");
        textMap.Add(70010, "-���� �����ص� ��¿ �� �����ϴ�.-");
        textMap.Add(70011, "-���� ������ ���� ���� ���̴ϱ��.-");

        //���� ����
        textMap.Add(80000, playerName + "��(��).....");
        textMap.Add(80001, "�賭�� ������ �ߵ��� ���ߴ�.");
        textMap.Add(80002, playerName + "�� ���� ��������");
        textMap.Add(80003, "���" + playerName + "��(��) �׾��ٴ� ����� ���İ��� ����������.");
        textMap.Add(80004, "�� ���� ��򰡿��� ������ ���� ���� ���̴�.");
        textMap.Add(80005, "�׷��� ��� " + playerName + "�� ������ ���� �����ߴ�.");
        textMap.Add(80006, "-[���� ����]-");
        textMap.Add(80007, "-�̹��� ���� �������̳� ���ϴ�.-");


        //���� �޼���
        textMap.Add(90000, "��ī���� ��� ������ ������ ������ϴ�.");
    }
}
