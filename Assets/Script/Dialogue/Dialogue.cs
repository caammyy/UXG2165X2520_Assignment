using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue
{
    public int cutsceneRefID { get; }
    public int nextcutsceneRefID { get; }
    public int cutsceneSetID { get; }
    public string currentSpeaker { get; }
    public string leftSpeaker { get; }
    public string rightSpeaker { get; }
    public string leftImage { get; }
    public string rightImage { get; }
    public string dialogue { get; }
    public string choices { get; }

    public Dialogue(int cutsceneRefID, int nextcutsceneRefID, int cutsceneSetID, string currentSpeaker, string leftSpeaker, string rightSpeaker, string leftImage, string rightImage, string dialogue, string choices)
    {
        this.cutsceneRefID = cutsceneRefID;
        this.nextcutsceneRefID = nextcutsceneRefID;
        this.cutsceneSetID = cutsceneSetID;
        this.currentSpeaker = currentSpeaker;
        this.leftSpeaker = leftSpeaker;
        this.rightSpeaker = rightSpeaker;
        this.leftImage = leftImage;
        this.rightImage = rightImage;
        this.dialogue = dialogue;
        this.choices = choices;
    }
}