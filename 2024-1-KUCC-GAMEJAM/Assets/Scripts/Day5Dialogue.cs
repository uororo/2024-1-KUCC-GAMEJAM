using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Day5Dialogue : MonoBehaviour, IDayDialogue
{
    private string[] sentences = { "���� ������ ������. ������ ������ �߱����� ġ���� ������� �� ���̴�.",
        "���õ��� ���� ���� �� ����. Ű��~ �ÿ���~ ���� ���� ����.",
        "���� �������� �迡 ������ �� �� ���� ���ָ� �񱸸ۿ� ���̺״ٰ� �ƻԽ�! ���ڸ� ����� ģ���� ������ ��ƹ��ȴ�.",
        "\"����! ��¦�̿�! �̰� ����ü �������̾� ����!!!\"",
        "�����? �ȱ׷��� ����ѵ� �Ż���� ���ϰ� ��ʱ��� ���ϴٴ�, ���� �� �ڽſ��� �Ǹ��̴�. �̷����� �ƴ϶� �� �۾������!"};
    private int choicePoint = 4;
    private Dictionary<int, string[]> choiceSentences = new Dictionary<int, string[]>
    {
        { 0, new string[] { "�ڽ��� ���� ����ؼ����� å������ ����� ģ���� �ٸ� ������� �����Ѵ�.\n���� ���� ǥ���� 80 ����ߴ�.",
            "�տ� ���� ���ָ� ���� ���Ƹ԰��� ���� ��ٰ� ���� �� �μ��� �Ż�ٿ� ������ ����� ������ ��ź�ϸ� ���� û�Ѵ�." } },
        { 1, new string[] { "\"�μ��� �غ��� ���� ö���� ģ���α���? �� �༮�� ���븦 �ص� ������ ���ϰھ�.\"\n��� ������ ö���� ����ϴ� ���� ����� ������� �����ߴ�. ���� ���� ǥ���� 50 ����ߴ�.",
            "�۰� �������� �ռ����� ģ������ �Ⱥ��� ���̿� ���� ���� ���ٴڿ� ������ �μ��� ���� �ڸ��� ���ٰ� �濡 ���ư� �ῡ û�ߴ�." } }
    };
    private Dictionary<int, (bool isPlayer, int points)> choiceEffects = new Dictionary<int, (bool, int)>
    {
        { 0, (true, 80) },
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
