using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogManager : MonoBehaviour
{
    private int currentSentence;
    private Dialogue currentDialogue;

    private Movement playerMovement;


    [Header("Canvas")]
    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private TextMeshProUGUI displayedSentence;
    [SerializeField]
    private TextMeshProUGUI displayedName;
    [SerializeField]
    private Image displayCharacter1;
    [SerializeField]
    private Image displayCharacter2;
    [SerializeField]
    private GameObject button;
    private float TheTimer;

    private List<string> sentences = new List<string>();
    private List<string> names = new List<string>();
    private List<Sprite> Characters1 = new List<Sprite>();
    private List<Sprite> Characters2 = new List<Sprite>();
    private List<float> Timer = new List<float>();

    void Start()
    {
        playerMovement = FindObjectOfType<Movement>();
        currentSentence = 0;
        canvas.enabled = false;
    }


    private void Update()
    {
        if(TheTimer > Time.time)
        {
            button.SetActive(false);
        }
        else
        {
            button.SetActive(true);
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        currentDialogue = dialogue;
        canvas.enabled = true;
        for (int i = 0; i < currentDialogue.characterSentences.Length; i++)
        {
            sentences.Add(currentDialogue.characterSentences[i].sentence);
            names.Add(currentDialogue.characterSentences[i].name);
            Characters1.Add(currentDialogue.characterSentences[i].characterPicture1);
            Characters2.Add(currentDialogue.characterSentences[i].characterPicture2);
            Timer.Add(currentDialogue.characterSentences[i].enableContinue);
        }
        playerMovement.currentMovementType = Movement.movementTypes.none;
        ChangeValues();
    }

    public void DisplayNextSentence()
    {
        if (currentDialogue.characterSentences.Length > currentSentence + 1 && TheTimer < Time.time)
        {
            currentSentence++;
            ChangeValues();
        }
        if(TheTimer < Time.time)
        {
            EndDialogue();
        }
    }

    private void ChangeValues()
    {
        displayedSentence.text = sentences[currentSentence];
        displayedName.text = names[currentSentence];
        displayCharacter1.sprite = Characters1[currentSentence];
        displayCharacter2.sprite = Characters2[currentSentence];
        TheTimer = Timer[currentSentence] + Time.time;
    }

    private void EndDialogue()
    {
        Debug.Log("EndConversation");
        playerMovement.currentMovementType = Movement.movementTypes.Platfromer;
        canvas.enabled = false;
        currentSentence = 0;
    }
}
