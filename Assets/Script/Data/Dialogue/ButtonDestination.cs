using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDestination : MonoBehaviour
{
    //script to store destination info
    public DialogueAttempt reader;
    public string destination;

    private void Awake()
    {
        reader = FindObjectOfType<DialogueAttempt>();
        Debug.Log(reader);
    }

    public void readCutsceneChoice()
    {
        int.TryParse(destination, out int result);
        reader.ReadCutscene(result);
    }

}
