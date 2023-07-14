using System.Collections;
using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text characterName;
    [SerializeField] private TMP_Text dialogueMessage;
    // [SerializeField] privateDialogueObject testDialogue;
    //private DialogueObject testDialogue;
    private TypewriterEffect typewriterEffect;

    void Start()
    {
        typewriterEffect = GetComponent<TypewriterEffect>();
        //CloseDialogueBox();
        //testDialogue = Game.GetDialogueObjectList();
    }
    void Update()
    {
        StartCoroutine(DialogueAttempt());
    }
    public void ShowDialogue()
    {
        dialogueBox.SetActive(true);
        //characterName.text = "Ah Boy";
        StartCoroutine(StepThroughDialogue());
    }

    public IEnumerator DialogueAttempt()
    {
        List<Dialogue> Testdi = Game.GetDialogueList();
        foreach(Dialogue d in Testdi)
        {
            if(d.currentSpeaker == "Left")
            {
                characterName.text = d.leftSpeaker;
            }
            else
            {
                characterName.text = d.rightSpeaker;
            }
        }
        yield return new WaitForSeconds(1);
    }
    public IEnumerator StepThroughDialogue()
    {
        List<Dialogue> dialogues = Game.GetDialogueList();
        for(int i = 0; i< Game.GetDialogueList().Count; i++)
        {
            if(dialogues[i].currentSpeaker == "Left")
            {
                characterName.text = dialogues[i].leftSpeaker;
            }
            else
            {
                characterName.text = dialogues[i].rightSpeaker;
            }
            yield return null;
        }
        yield return null;
        //foreach (string dialogue in dialogueObject.Dialogue)
        //{
            //string characterName = dialogueObject.characterName;
            //haracterName.text = ;
            //yield return typewriterEffect.Run(dialogue, dialogueMessage);
            //yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        //}

        //CloseDialogueBox();
    }

    private void CloseDialogueBox()
    {
        dialogueBox.SetActive(false);
        characterName.text = string.Empty;
        dialogueMessage.text = string.Empty;
    }


    /**private void Start()
    {
        characterName.text = "Tim";
        GetComponent<TypewriterEffect>().Run("I love yugyeom.\n(not unity tho)", dialogueMessage);
    }**/
}
