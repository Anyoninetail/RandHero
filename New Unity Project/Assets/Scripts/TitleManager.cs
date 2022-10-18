using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    public InputField inputField;

    public void GameStart()
    {
        GameManager.mobType = 0;
        GameManager.isIntro = true;
        
        if(inputField.text != "")
        {
            TextManager.playerName = inputField.text;
        }
        else
        {
            LoadNameMap();
            TextManager.playerName = playerNames.GetValueOrDefault(Random.Range(0, 36));
        }

        SceneLoader.Instance.LoadScene("TextScene");
    }

    Dictionary<int, string> playerNames = new Dictionary<int, string>();

    void LoadNameMap()
    {
        playerNames.Add(0, "��ġ������");
        playerNames.Add(1, "��������");
        playerNames.Add(2, "ũ���Ľ�Ÿ");
        playerNames.Add(3, "���İ�Ƽ");
        playerNames.Add(4, "���󼧱�");
        playerNames.Add(5, "Ÿ�ھ߳�");
        playerNames.Add(6, "�������");
        playerNames.Add(7, "������");
        playerNames.Add(8, "�ع�����");
        playerNames.Add(9, "������ġ");
        playerNames.Add(10, "���ġŲ");
        playerNames.Add(11, "�ߺ�����");
        playerNames.Add(12, "���¥��");
        playerNames.Add(13, "�ع����");
        playerNames.Add(14, "�������");
        playerNames.Add(15, "���ֺ����");
        playerNames.Add(16, "��⸸��");
        playerNames.Add(17, "��ä����");
        playerNames.Add(18, "Ƽ��̼�");
        playerNames.Add(19, "ī���");
        playerNames.Add(20, "������ũ");
        playerNames.Add(21, "�Ƹ޸�ī��");
        playerNames.Add(22, "��������");
        playerNames.Add(23, "��ġ����");
        playerNames.Add(24, "ġ�����");
        playerNames.Add(25, "�����ʹ�");
        playerNames.Add(26, "����ʹ�");
        playerNames.Add(27, "���߱�ġ");
        playerNames.Add(28, "��������ũ");
        playerNames.Add(29, "����Ƽ���");
        playerNames.Add(30, "�ڼ�����");
        playerNames.Add(31, "�л�ȸ��");
        playerNames.Add(32, "�������");
        playerNames.Add(33, "����Ƣ��");
        playerNames.Add(34, "��������");
        playerNames.Add(35, "����������");
    }
}
