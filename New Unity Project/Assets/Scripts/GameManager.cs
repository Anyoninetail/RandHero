using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text daysRemain;
    public int dayLeft;

    void Start()
    {
        dayLeft = 15;
        daysRemain.text = "���ռ� ��������\n" + dayLeft + "��";
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
