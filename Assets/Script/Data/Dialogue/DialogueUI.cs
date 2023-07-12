using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text characterName;
    [SerializeField] private TMP_Text dialogueMessage;
    [SerializeField] private DialogueObject testDialogue;

    private TypewriterEffect typewriterEffect;

    private void Start()
    {
        typewriterEffect = GetComponent<TypewriterEffect>();
        CloseDialogueBox();
        ShowDialogue(testDialogue);
    }

    public void ShowDialogue(DialogueObject dialogueObject)
    {
        dialogueBox.SetActive(true);
        //characterName.text = "Ah Boy";
        StartCoroutine(StepThroughDialogue(dialogueObject));
    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {

        foreach (string dialogue in dialogueObject.Dialogue)
        {
            //string characterName = dialogueObject.characterName;
            //haracterName.text = ;
            yield return typewriterEffect.Run(dialogue, dialogueMessage);
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }

        CloseDialogueBox();
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
