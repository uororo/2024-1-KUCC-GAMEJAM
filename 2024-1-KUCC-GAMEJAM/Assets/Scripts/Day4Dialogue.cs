using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Day4Dialogue : MonoBehaviour, IDayDialogue
{
    private string[] sentences = { "�ѵ��� ���� ��Ʈ������ �ֹ��� �� �������� ��ǥ���� �ٰ��Դ�.",
        "�ӻ��ϰ� ��ǥ�� ��ģ �� �ѵ��� ǥ������ �ִ� �������� �������� �ð��� ã�ƿԴ�.",
        "�׷���, ������ �����Բ��� �ϽŴ�. ����ü ����� �Ͻô°���? �������� ������ ���� �亯�� ���� �ؾ��� �� ���� �ȿ´�.",
        "����: \"�ڳ״� ������ ������ ������ �� �������� ��ǥ�� �Ϸ� �°հ�?\"",
        "�������� �󱼿��� �Ǹ��� ����´�.",
        "���⼭ ���� ����� ���̸� ��, ������� �ٸ��� ��������?" };
    private int choicePoint = 5;
    private Dictionary<int, string[]> choiceSentences = new Dictionary<int, string[]>
    {
        { 0, new string[] { "���ڱ� ���� ��½ �� ������� ���� ���ڿ� �����Ͽ� �������ϰ� ���� ��Ƴ��� �����Ѵ�. ����Ʈ�� ����� ������� ������� �����Ѵ�.\n���̹��� ǥ���� 80 �ö󰬴�.",
            "�̷� ����, ����µ��� ������� �𸣰ڳ�. ������ ơ",
        "���� ��ȸ�� ���̹����� ���ѱ� ���� �濡 ���ƿ� ������ �� �����Ŀ� ���� ������Ű�� �о�ٰ� ���� û�ߴ�."} },
        { 1, new string[] { "������: \"�ڳ״� ����ü ���� �Ҹ� �ϴ°հ�?\"\n��� ��Ҹ��� �������, ����ִ� ����� �����ϰ� ������ �۽��̴� ������� ���ܳ���. ���� ���� ǥ���� 50��ŭ �ö󰬴�.",
            "���� ����. �ʹ� �ȶ��� ������ �� ���س��� �亯�� �����Ե� ���� ���Ͻô±�. �μ��� �ѵ��ϰ� �����ϸ� �濡 ���ƿ� �ῡ �����." } }
    };
    private Dictionary<int, (bool isPlayer, int points)> choiceEffects = new Dictionary<int, (bool, int)>
    {
        { 0, (false, 80) },
        { 1, (true, 50) } 
    };

    public void StartDialogue()
    {
        // ��ȭ ���� ������ DialogueManager�� ó��
    }

    public string[] GetSentences()
    {
        return sentences;
    }

    public int GetChoicePoint()
    {
        return choicePoint;
    }

    public int GetNumberOfChoices()
    {
        return choiceSentences.Count;
    }

    public Dictionary<int, string[]> GetChoices()
    {
        return choiceSentences;
    }

    // �������� ���� ���� ���� �޼ҵ�
    public void ApplyChoiceEffect(int choiceIndex)
    {
        if (choiceEffects.ContainsKey(choiceIndex))
        {
            var effect = choiceEffects[choiceIndex];
            GameManager.Instance.AdjustScore(effect.isPlayer, effect.points);
        }
    }
}
