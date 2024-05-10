using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Day3Dialogue : MonoBehaviour, IDayDialogue
{
    private string[] sentences = { "������ ��̾��� ���� ���� 5������ ������ �濡 ���ƿԴ�.",
        "��. ����� �װڳ�. ������ ���� �濡�� �ȳ�������.",
        "��.. �Ұ͵� ���µ� �� ���濡 ���̳� �÷�����? ����� �ø���?" };
    private int choicePoint = 2;
    private Dictionary<int, string[]> choiceSentences = new Dictionary<int, string[]>
    {
        { 0, new string[] { "��? ���, �����̴� ���� �����ϱ�� ���� Ȧ����ũ�� �Ѹ��� �����ߴ�.\n������ ������ �� �����̿� ���� �������� �νɿ� ������ ������� ���ܳ���. ���̹��� ǥ���� 30��ŭ ����ߴ�.",
            "��ģ�� �ƴϾ�? ����. �ִ��� �ڽ��̶� ���� ���Ƶ�����? �׷��� ���� �޾����ϱ� ������ �־����.",
        "����� �ϸ鼭�� ���Ұ� ���� �μ��� ������������ ���� �����ϸ鼭 �Ϸ縦 ������ ���� û�ߴ�."} },
        { 1, new string[] { "�ƹ��� ���屸�� ��ģ��. ��ȥ�� ���ڱ� ����� �ϴ� �̻��� ����� �ƴ�.\n���� ���� ǥ���� 30��ŭ ��������.",
            "������ ���� ������ ��ħ�� �����̰� �� �μ��� ������ ���� û�ߴ�." } },
        { 2, new string[] { "�����: \"�μ���, ���� �̰� ���� �ȴٰ� �����ϴ�? �����Բ� �˼������� �ʾ�?\"���̹��� �����̰� ���������� ���� ��������.\n�������� ���� ���� ����� ������� �Ǹ��ߴ�. ���� ���� ǥ���� 20��ŭ ��������.",
        "����, ���� �󸶳� �߳��ٰ�. ������鼭 �μ��� ���� �������� �Ϸ����� ��ü�� �ϴٰ� �ῡ �����."} }
    };
    private Dictionary<int, (bool isPlayer, int points)> choiceEffects = new Dictionary<int, (bool, int)>
    {
        { 0, (false, 30) },
        { 1, (true, -30) },
        { 2, (true, -20) }
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
