using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueAttempt : MonoBehaviour
{
    //GameObject dialoguebox;
    public TextMeshProUGUI Testname;
    public TextMeshProUGUI DialogueText;
    TypewriterEffect typewritereffect;
    bool waitforinput = true;
    void Start()
    {
        
    }

    void Update()
    {
        StartCoroutine(DialogueAttempts());
        if(waitforinput && Input.GetKeyDown(KeyCode.K))
        {
            waitforinput = false;
        }
    }
    public IEnumerator DialogueAttempts()
    {
        List<Dialogue> Testdi = Game.GetDialogueList();
        for (int t = 0; t < Game.GetDialogueList().Count; t++)
        {
            waitforinput = true;
            
            while (waitforinput)
            {
                yield return null;
            }
            DialogueText.text = Testdi[t].dialogue;
            if (Testdi[t].currentSpeaker == "Left")
            {
                Testname.text = Testdi[t].leftSpeaker;
            }
            if (Testdi[t].currentSpeaker == "Right")
            {
                Testname.text = Testdi[t].rightSpeaker;
            }
            yield return null;
            if (Testdi[t].nextcutsceneRefID == -2)
            {
                Testname.text = Testdi[t].choices;
            }

            Debug.Log("Test");
        }
        yield return null;
    }
}
