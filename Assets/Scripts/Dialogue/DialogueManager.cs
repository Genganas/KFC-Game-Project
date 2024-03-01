using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    Queue<DialogueSection> dialogueQueue = new Queue<DialogueSection>();
    [SerializeField] private TMP_Text characterNameText;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private Image characterImage1;
    [SerializeField] private Image characterImage2;

    private Characters currentCharacter; // Variable to store the current character
    private Color character1HighlightColor = new Color(255f / 255f, 255f / 255f, 255f / 255f, 255f);
    private Color character2FadeColor = new Color(101f / 255f, 87f / 255f, 87f / 255f, 0.5f); // Adjust colors

    [SerializeField] private Button beginRaceButton;
    public TMP_Text btnText;

    public void StartDialogue(Characters character)
    {
        currentCharacter = character;
        dialogueQueue.Clear();
        foreach (var section in character.dialogueToLoadIntoQueue)
        {
            dialogueQueue.Enqueue(section);
        }
        ShowNextDialogue();
    }

    private Coroutine typingCoroutine;

    public void ShowNextDialogue()
    {
        if (dialogueQueue.Count > 0)
        {
            DialogueSection section = dialogueQueue.Dequeue();
            characterNameText.text = section.name;

            // Clear any previous typing coroutine.
            if (typingCoroutine != null)
            {
                StopCoroutine(typingCoroutine);
            }

            // Start a new coroutine to display the dialogue letter-by-letter.
            typingCoroutine = StartCoroutine(TypeDialogue(section.dialogue));

            // Set character sprites and colors based on the 'isplayercharacter' flag.
            if (section.isplayercharacter)
            {
                characterImage1.sprite = section.characterimg;
               // characterImage2.sprite = null;

                // Highlight the current character.
                characterImage1.color = character1HighlightColor;
                characterImage2.color = character2FadeColor;
            }
            else
            {
               // characterImage1.sprite = null;
                characterImage2.sprite = section.characterimg;

                // Highlight the current character.
                characterImage2.color = character1HighlightColor;
                characterImage1.color = character2FadeColor;
            }
        }
        else
        {
                 btnText.text = "Start the Game";
        }
    
    }

    private IEnumerator TypeDialogue(string dialogue)
    {
        dialogueText.text = "";
        foreach (char letter in dialogue)
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.03f); // Adjust the delay 
        }
    }
}
