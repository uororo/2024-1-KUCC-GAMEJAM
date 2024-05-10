using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI; // UI ��ư�� ����ϱ� ���� �߰�

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public string[] sentences;
    public GameObject[] choiceButtons; // ������ ��ư �迭
    private int index;
    public float typingSpeed = 0.02f;

    private int choicePoint = 3; // �������� ǥ���� ��ȭ�� �ε���, ���� ��� 4��° ��ȭ �� ������ ǥ��
    private Dictionary<int, string[]> choiceSentences; // �������� ���� ��ȭ��

    private void Start()
    {
        index = 0;
        InitializeChoices();
        StartDialogue();
        SetupChoiceButtons(false); // ���� �� ��� ������ ��ư�� ��Ȱ��ȭ
    }

    void InitializeChoices()
    {
        choiceSentences = new Dictionary<int, string[]>();
        choiceSentences.Add(0, new string[] { "1��° ������ �׽�Ʈ", "1�� ������ ���� ��ȭ�� �׽�Ʈ" });
        choiceSentences.Add(1, new string[] { "2��° ������ �׽�Ʈ", "2�� ������ ���� ��ȭ�� �׽�Ʈ" });
        choiceSentences.Add(2, new string[] { "3��° ������ �׽�Ʈ", "3�� ������ ���� ��ȭ�� �׽�Ʈ" });
    }

    void StartDialogue()
    {
        StartCoroutine(TypeSentence(sentences[index]));
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
        foreach (GameObject button in choiceButtons)
        {
            button.SetActive(isActive);
        }
    }

    public void MakeChoice(int choiceIndex)
    {
        SetupChoiceButtons(false);
        if (choiceSentences.ContainsKey(choiceIndex))
        {
            sentences = choiceSentences[choiceIndex]; // ���ÿ� ���� ���ο� ��ȭ�� �迭�� �ε�
            index = 0; // ���ο� ��ȭ���� ����
            StartDialogue();
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
        }
    }
}
