using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Day2Dialogue : MonoBehaviour, IDayDialogue
{
    private string[] sentences = { "���õ� ��@���ϰ� �Ϸ����� ������� ���� ���� ����濡 ���ư� �غ����̾���.",
        "���ڱ� ������ ���� ����� ����⿡ �ڸ� ���ƺ��Ҵ�.",
        "�����ϴ� ������ �̱�ĥ�̾���.",
        "\"�̱�ĥ: ��, �μ���. ��� �׸� ���ϱ淡 ������ ���� �߰����� ���θ���. �׷��� ���� ���� �����ð������� ���� ��?\"",
        "��.. ������ ��������, ���� ������ �İ� �ڰ������. �����?" };
    private int choicePoint = 4;
    private Dictionary<int, string[]> choiceSentences = new Dictionary<int, string[]>
    {
        { 0, new string[] { "�̱�ĥ: \"��, ���� �ʹۿ� ����! �� ���� ���� ģ������!\"\n������� ������ �������� �ʴ� ������� ���� ���� �λ��� ������ �Ǿ���. ���� ���� ǥ���� 40 �ö󰬴�. ��ȣ",
            "�ҿܵǴ� ģ�� ���� ���õ� �ų��� ������� ���� ����濡 �ͼ� ���� ������." } },
        { 1, new string[] { "�����: \"�׷�~ �μ��� ���� �ǰ��Ѱ���~ ���� ù�������� �ȴٰ�? ��� �ѹ� ������ ���� ��������?\"\n������� ���� ���߿��� ���� �����̿� �����ְ� ��Ҵ�. ���̹��� ǥ���� 60��ŭ �ö󰬴�.",
            "ģ������ �����̸� �����ϴ� ����� ����� ���� �μ��� �����ɿ� ���� ������ٰ� ���� �����." } }
    };
    private Dictionary<int, (bool isPlayer, int points)> choiceEffects = new Dictionary<int, (bool, int)>
    {
        { 0, (true, 40) },
        { 1, (false, 60) }
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
