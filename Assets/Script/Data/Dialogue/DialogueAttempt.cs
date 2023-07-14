using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueAttempt : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI charactername;
    public bool waitforInput = true;
    List<Dialogue> testdi;
    void Start()
    {
        testdi = Game.GetDialogueList();
        Debug.Log(testdi.Count);
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(DialogueAttempts());
    }
    public IEnumerator DialogueAttempts()
    {
        foreach(Dialogue d in testdi)
        {
            charactername.text = d.dialogue;
            Debug.Log(d.dialogue);
        }
        yield return null;
    }
}
