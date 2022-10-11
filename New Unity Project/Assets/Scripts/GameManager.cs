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






































































    Dictionary<int, string> locationMap;
    Dictionary<int, string> encounterMap;

    void LoadLocationMap()
    {
        locationMap = new Dictionary<int, string>();

        locationMap.Add(0, "Slime");  //������
        locationMap.Add(1, "Ork");  //��ũ
        locationMap.Add(2, "Goblin");  //���
        locationMap.Add(3, "Skeleton");  //���̷���
        locationMap.Add(4, "Cultist");  //�̱���(������ �������)
        //������� ���� ��ī����

        locationMap.Add(5, "Tavern");  //������(ü�� ȸ��)
        locationMap.Add(6, "Store");  //����(�� ���)
        locationMap.Add(7, "Treasure");  //����(�� ȹ��)
        locationMap.Add(8, "BadWeather");  //��õ��(���� Ȯ���� ü�� ����/�� �н�)
        locationMap.Add(9, "Casino");  //������(���� Ȯ���� �� �뷮 ȹ��/ü�� ����)
    } 

    void LoadEncounterMap()
    {
        encounterMap = new Dictionary<int, string>();

        encounterMap.Add(0, "����� ���� �������� �߰��ߴ�");
        encounterMap.Add(1, "��ũ�� ��Ÿ�� �ձ��� ���θ��Ҵ�");
        encounterMap.Add(2, "����� ���� �Ĵ� ����� ���� �����ƴ�");
        encounterMap.Add(3, "����ó�� �а��� �ִ� �̹��� �߰��ߴ�");
        encounterMap.Add(4, "�������� �̱����� ������");
        //������� ���� ��ī����

        encounterMap.Add(5, "�������� �������� �߰��ߴ�");
        encounterMap.Add(6, "�������� ���λ��� ������");
        encounterMap.Add(7, "��Ǯ �ӿ��� Ȳ�ݺ� �������ڸ� ã�Ҵ�");
        encounterMap.Add(8, "õ�� ������ ġ�� �����ߴ�");
        encounterMap.Add(9, "������ ��񿡼� ���������� �ȳ��޾Ҵ�");
    }
}
