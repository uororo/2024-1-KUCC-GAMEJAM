using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Day1Dialogue : MonoBehaviour, IDayDialogue
{
    private string[] sentences = { "�αٰŸ��� �������� ����뿡 ������ �� �ڽ�.",
        "�׷� ������ �Ѱ��� ��ΰŸ��� �־���.",
        "�װ� �ٷ� ���밡 ���� ���ϸ� �ܴ��� �����϶�� ������ �����.",
        "�ᱹ ���� ����� ����Ǳ� ���� �ĺ��� ����� �ߴ�",
        "�׷��� ���ž��� ��鼭 ��԰� �ִٰ� ���� ��ǥ�ϱ��� ������ ���Ҵٴ� ����� ��� �˰Եƴ�.",
        "�����? �������� ȥ����� ������.",
        "�ᱹ ���� ���� �����ϵ��� ������ ���ϱ�� ����ߴ�.",
        "���� �츮 ���� ���� 1�� ��ģ�Ʒ� ������ ������̴�.",
        "����� �ϰ�����, �����ϵ��� ������ ��ƺ���?",
        "��� �����ϴ� ������, ģ�� ������ �������� ���� �ɾ�Դ�.",
        "������: \"�� �̳༮��. ���� �ֵ��̶� ���� ����� �ߴµ� �ʵ� �÷�?\"",
        "\"�� �׷�.\" ���� ����� �ܸ��� ���� ������ ���ƴ�.",
        "���ڿ� �����ϰ� ��ð��� ��������, ���ڱ� ���ڸ� ����� ģ���� ������ ���� �ɾ�´�.",
        "\"�� ���� �ĺ��� �����ٸ�? �׷� ������������ �ؾ��ϴ°� �Ƴ�?\"",
        "��? �׷���? �β������� �׷��� ������ �ؾ߰���..?",
        "���� �������� �Ͼ�� FM�� �����ߴ�.",
        "\"�ȳ�, �ȳ�, �ȳ��Ͻʴϱ�!!! �������! ÷������! ����İ�! ���� �İ�����...\""
        };
    private int choicePoint = 16;
    private Dictionary<int, string[]> choiceSentences = new Dictionary<int, string[]>
    {
        { 0, new string[] { "�����: \"��.. �׷� �� �μ������� �Ϳ��� ������\"\n���� ���� ǥ���� 20��ŭ �ö���! ����",
            "�ӻ��� �������� ���� ���� ���ڸ��� �������ϰ� ����濡�ͼ� ���� ���." } },
        { 1, new string[] { "�����: \"���� ��ǥ�� ���ߴµ� ��������? ���Ⱦ�\"\n���� ���� ǥ���� 10��ŭ ��������.",
            "���� �̵鿡�� �̿��� ���� ���� ���� ����濡 ���ƿ� ������ ������ ���ø� �ῡ �����." } },
        { 2, new string[] { "�����: \"�츮�� ���־��� ������ε�? �� �ʹ� ����°� �ƴϾ�?\"\n���̹��� ǥ���� 30��ŭ �ö���.",
            "������ ���ǿ� �����ϰ� �� ���� ���� �濡 ���ƿ� ������ ��ġ�� ���� û�ߴ�." }}
    };
    private Dictionary<int, (bool isPlayer, int points)> choiceEffects = new Dictionary<int, (bool, int)>
    {
        { 0, (true, 20) },
        { 1, (true, -10) },
        { 2, (false, 30) }
    };

    public void StartDialogue()
    {

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
