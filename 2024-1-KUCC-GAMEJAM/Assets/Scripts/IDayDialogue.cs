using System.Collections.Generic;

public interface IDayDialogue
{
    void StartDialogue();
    string[] GetSentences();  // ��ȭ ������ ��ȯ�ϴ� �޼���
    int GetChoicePoint();     // �������� ������ ������ ��ȯ�ϴ� �޼���
    Dictionary<int, string[]> GetChoices(); // �������� ���� ��ȭ���� ��ȯ�ϴ� �޼���
    int GetNumberOfChoices();
    void ApplyChoiceEffect(int choiceIndex);
}
