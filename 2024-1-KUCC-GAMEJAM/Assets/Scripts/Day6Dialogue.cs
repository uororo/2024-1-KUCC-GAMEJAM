using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Day6Dialogue : MonoBehaviour, IDayDialogue
{
    private string[] sentences = { "������ �� MT���� ���� ȸ��, �̴��� ����� ����� �ִ� ���̴�.",
        "����, �̿� ���ٲ��� ���������� ������?",
        "������ �Ĺ��� �絹�Կ� ��ź�� ����� ������ ���� ���������� ���� ����.",
        "�ڸ��� �ɾ� �޴����� ���İ��� ��ĵ�� ��, ���� ��� �޴��� �ֹ��� ���ƴ�.",
        "��, ���� ���� ��⸦ ����?"};
    private int choicePoint = 4;
    private Dictionary<int, string[]> choiceSentences = new Dictionary<int, string[]>
    {
        { 0, new string[] { "���� ���� ������ �𸣴µ��� ���� ����� ���谡 ���� ���� �����Ѵ�. ������ ���� �۷��ٰ� �����ϰ� �ִ�.\n���� ���� ǥ���� 40 �϶��ߴ�.",
            "����, ���� �� �󸶳� �߳��ٰ�. �� ��� �پ�? �μ��� �� �ٽ� ��ħ�ϰ� ��� ���� ���ϴٰ� ���� û�ߴ�." } },
        { 1, new string[] { "�� ������I�� ������ �ų��� ������ ���� ������ ��� ���� �����Ⱑ ���Ҵ�. ���� ���� �ҹ��� ������.\n���� ���� ������ 50 ����ߴ�.",
            "�Ϸ����� ���� ����� �Ϳ��� �ǰ� �� ������ �μ��� �����ϴ� ���������� �͸� ��ȭ�ϴٰ� ������ �ῡ �����." } },
        { 2, new string[] { "�� �����ڷθ� ��� �޴� ���谡 �����Ͽ� ������ �긮�� �����Ѵ�. ���谡 �� ����鿡�� ���� �ҹ��� �۶߸���.\n���� ���� ǥ���� 70 ����ߴ�.",
        "�ѵ��ϰ� �λ������ �ݾ��� ������ ���� ���迡�� Ŀ�Ǳ��� ���԰� �λ��� ���Ҹ��� �ϴٰ� �濡 ���ƿͼ� �ٵ��� �δٰ� �ῡ �����."} }
    };
    private Dictionary<int, (bool isPlayer, int points)> choiceEffects = new Dictionary<int, (bool, int)>
    {
        { 0, (true, -40) },
        { 1, (true, 50) },
        { 2, (true, 70) }
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
