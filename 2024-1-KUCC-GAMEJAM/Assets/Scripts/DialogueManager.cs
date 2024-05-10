using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public GameObject[] choiceButtons; // ������ ��ư �迭
    private int index; // ���� ǥ���� ������ �ε���
    public float typingSpeed = 0.02f; // ���ڰ� ǥ�õǴ� �ӵ�

    private IDayDialogue currentDayDialogue; // ���� ���ڿ� ���� ��ȭ ��ũ��Ʈ �������̽�
    private string[] sentences; // ���� ��ȭ ����
    private int choicePoint; // �������� ǥ���� ��ȭ�� �ε���
    private Dictionary<int, string[]> choiceSentences; // �������� ���� ��ȭ��
    private int currentDay = 1; // ���� ����

    public FadeManager fadeManager;

    void Start()
    {
        LoadDayDialogue(currentDay); // ���� ���� �� ù° �� ��ȭ �ε�
    }

    void LoadDayDialogue(int day)
    {
        string className = "Day" + day + "Dialogue";
        Component comp = gameObject.AddComponent(System.Type.GetType(className)) as Component;
        currentDayDialogue = comp as IDayDialogue;

        sentences = currentDayDialogue.GetSentences();
        choicePoint = currentDayDialogue.GetChoicePoint();
        choiceSentences = currentDayDialogue.GetChoices();

        index = 0;

        StartCoroutine(TypeSentence(sentences[index])); // ù° ������ �ٷ� ��ȭ ����
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && dialogueText.text == sentences[index])
        {
            if (index == choicePoint)
            {
                SetupChoiceButtons(true); // ������ ǥ��
            }
            else
            {
                NextSentence();
            }
        }
    }

    void SetupChoiceButtons(bool isActive)
    {
        int numberOfChoices = currentDayDialogue.GetNumberOfChoices();
        for (int i = 0; i < choiceButtons.Length; i++)
        {
            choiceButtons[i].SetActive(i < numberOfChoices && isActive);
        }
    }

    public void MakeChoice(int choiceIndex)
    {
        SetupChoiceButtons(false);
        if (choiceSentences.ContainsKey(choiceIndex))
        {
            string[] chosenDialogue = choiceSentences[choiceIndex];
            sentences = new string[] { chosenDialogue[0], chosenDialogue[1] }; // ���� ��ȭ�� ������Ʈ
            index = 0;
            StartCoroutine(TypeSentence(sentences[index]));
            currentDayDialogue.ApplyChoiceEffect(choiceIndex);  // ���� ����
        }
    }

    void NextSentence()
    {
        if (index < sentences.Length - 1)
        {
            index++;
            StartCoroutine(TypeSentence(sentences[index]));
        }
        else
        {
            dialogueText.text = ""; // ��� ��ȭ�� ǥ���ߴٸ� ���
            index = 0;
            EndOfDay(++currentDay);
        }
    }

    public void EndOfDay(int nextDay)
    {
        StartCoroutine(EndDayRoutine(nextDay));
    }

    IEnumerator EndDayRoutine(int nextDay)
    {
        yield return StartCoroutine(fadeManager.FadeIn());
        fadeManager.dayText.text = "Day " + nextDay;
        fadeManager.dayText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        fadeManager.dayText.gameObject.SetActive(false);
        yield return StartCoroutine(fadeManager.FadeOut());

        currentDay = nextDay;
        LoadDayDialogue(currentDay);
    }
}
