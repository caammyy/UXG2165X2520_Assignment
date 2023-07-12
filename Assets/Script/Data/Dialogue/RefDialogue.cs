using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RefDialogue
{
    public int cutsceneRefID;
    public int nextcutsceneRefID;
    public int cutsceneSetID;
    public string currentSpeaker;
    public string leftSpeaker;
    public string rightSpeaker;
    public string leftImage;
    public string rightImage;
    public string dialogue;
    public string choices;
}
