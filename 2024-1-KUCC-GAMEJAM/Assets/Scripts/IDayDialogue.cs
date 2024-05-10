using System.Collections.Generic;

public interface IDayDialogue
{
    void StartDialogue();
    string[] GetSentences();  // 대화 내용을 반환하는 메서드
    int GetChoicePoint();     // 선택지를 제시할 지점을 반환하는 메서드
    Dictionary<int, string[]> GetChoices(); // 선택지에 따른 대화문을 반환하는 메서드
    int GetNumberOfChoices();
    void ApplyChoiceEffect(int choiceIndex);
}
