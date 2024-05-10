using System.Collections.Generic;
using UnityEngine;

public class Day5Dialogue : MonoBehaviour, IDayDialogue
{
    private string[] sentences = { "�ټ�° �� ��ȭ�� �׽�Ʈ",
        "�̾ ������ ��ȭ �׽�Ʈ", "������ ����:" };
    private int choicePoint = 2;
    private Dictionary<int, string[]> choiceSentences = new Dictionary<int, string[]>
    {
        { 0, new string[] { "1�� �������� ������ϴ�.", "Resulting dialogue" } },
        { 1, new string[] { "2�� �������� ������ϴ�.", "Resulting dialogue" } }
    };
    private Dictionary<int, (bool isPlayer, int points)> choiceEffects = new Dictionary<int, (bool, int)>
    {
        { 0, (true, 10) },  // 1�� �������� �÷��̾�� +10 ����
        { 1, (false, -5) }  // 2�� �������� ���濡�� -5 ����
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
