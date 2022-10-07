using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text daysRemain;
    public Text currentDay;
    public int dayLeft;
    public GameObject nextDay;

    void Start()
    {
        LoadEncounterMap();
        dayLeft = 15;
        daysRemain.text = "���ռ�\n��������\n" + dayLeft + "��";
    }

    public void ShowNextDay()
    {
        currentDay.text = (16 - dayLeft) + "����";
        nextDay.SetActive(true);
    }

    public void Encounter()
    { 

    }







































































    Dictionary<int, string> encounterMap;

    void LoadEncounterMap()
    {
        encounterMap = new Dictionary<int, string>();

        encounterMap.Add(0, "Slime");  //������
        encounterMap.Add(1, "Ork");  //��ũ
        encounterMap.Add(2, "Goblin");  //���
        encounterMap.Add(3, "Skeleton");  //���̷���
        encounterMap.Add(4, "Cultist");  //�̱���(������ �������)
        //������� ���� ��ī����

        encounterMap.Add(5, "Tavern");  //������(ü�� ȸ��)
        encounterMap.Add(6, "Store");  //����(�� ���)
        encounterMap.Add(7, "Treasure");  //����(�� ȹ��)
        encounterMap.Add(8, "BadWeather");  //��õ��(���� Ȯ���� ü�� ����/�� �н�)
        encounterMap.Add(9, "Casino");  //������(���� Ȯ���� �� �뷮 ȹ��/ü�� ����)
    }
}
