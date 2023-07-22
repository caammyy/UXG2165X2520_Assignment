using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueAttempt : MonoBehaviour
{
    public Image leftImage;
    public Image rightImage;

    public Image leftEmotion;
    public Image rightEmotion;

    public Image Space;
    public TextMeshProUGUI SelectInstructions;

    public TextMeshProUGUI Testname;
    public GameObject dialogueBox;
    public TextMeshProUGUI DialogueText;

    public TextMeshProUGUI characterNameSelect;
    public GameObject selectionBox;
    public Button select1button;
    public Button select2button;
    public TextMeshProUGUI select1text;
    public TextMeshProUGUI select2text;
    
    TypewriterEffect typewritereffect;
    //bool waitforinput = true;

    //default starting cutscene
    int currentCutsceneID = 101;
    public int nextScene = 101001;
    bool cutsceneOver = true;
    List<Dialogue> currentCutscene;


    void Start()
    {
        
    }
    
    private void Awake()
    {
        HideBox(selectionBox);
        HideImage(leftImage);
        HideImage(rightImage);
        HideImage(leftEmotion);
        HideImage(rightEmotion);
        SelectInstructions.gameObject.SetActive(false);

        string test = "What do you mean?#101004@Heaven? Am I dead?#101005";
        SplitStringToList(test);
    }

    //image
    public void HideImage(Image image)
    {
        image.gameObject.SetActive(false);
    }

    public void ShowImage(Image image)
    {
        image.gameObject.SetActive(true);
    }


    //selection box
    public void ShowBox(GameObject gameobject)
    {
        gameobject.gameObject.SetActive(true);
    }

    public void HideBox(GameObject gameobject)
    {
        gameobject.gameObject.SetActive(false);
    }
    
    //split string method
    public List<string> SplitStringToList(string strtosplit)
    {
        List<string> s = new List<string>(strtosplit.Split(new char[] { '#', '@' }));
        foreach (string item in s)
        {
            Debug.Log(item);
        }
 
        return s;
        //s[0] = text1
        //s[1] = selected cutsceneid
    }
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ReadCutscene(nextScene);
        }
    }

    public void CutSceneSet()
    {
        if (cutsceneOver == true)
        {
            List<Dialogue> dialogueList = Game.GetDialogueList();
            List<Dialogue> newCutscene = new List<Dialogue>();
            foreach (Dialogue d in dialogueList)
            {
                if (d.cutsceneSetID == currentCutsceneID)
                {
                    newCutscene.Add(d);
                }
            }

            currentCutscene = newCutscene;
            nextScene = currentCutscene[0].cutsceneRefID;
            cutsceneOver = false;
        }

        else return;
    
    }

    public void ReadCutscene(int destination)
    {
        CutSceneSet();

        if (cutsceneOver != true)
        {
            foreach (Dialogue d in currentCutscene)
            {
                ShowImage(Space);
                if (d.cutsceneRefID == destination)
                {
                    //if choice show choice
                    if (d.nextcutsceneRefID == -2)
                    {
                        HideImage(Space);
                        SelectInstructions.gameObject.SetActive(true);
                        HideImage(rightEmotion);
                        List<string> choices = SplitStringToList(d.choices);
                        HideBox(dialogueBox);
                        ShowBox(selectionBox);

                        HideImage(rightImage);
                        ShowImage(leftImage);
                        characterNameSelect.text = d.leftSpeaker;

                        select1text.text = choices[0];
                        select1button.GetComponent<ButtonDestination>().destination = choices[1];

                        select2text.text = choices[2];
                        select2button.GetComponent<ButtonDestination>().destination = choices[3];

                        //this.GetComponent<SpriteRenderer>().sprite = AssetManager.LoadSprite(Game.GetImage())

                        return; //ends the code so that it doesn't break :)
                    }

                    else
                    {
                        HideBox(selectionBox);
                        ShowBox(dialogueBox);
                        if (d.leftEmotion != "-1")
                        {
                            ShowImage(leftEmotion);
                            AssetManager.LoadSprite(d.leftEmotion, (Sprite s) =>
                            {
                                leftEmotion.GetComponent<Image>().sprite = s;
                            });
                        }
                        Debug.Log(d.leftEmotion);

                        if (d.rightEmotion != "-1")
                        {
                            HideImage(leftEmotion);
                            ShowImage(rightEmotion);
                            AssetManager.LoadSprite(d.rightEmotion, (Sprite s) =>
                            {
                                rightEmotion.GetComponent<Image>().sprite = s;
                            });
                        }
                        

                        //normal dialogue
                        if (d.currentSpeaker == "Left")
                        {
                            SelectInstructions.gameObject.SetActive(false);
                            HideImage(Space);
                            HideImage(rightEmotion);
                            HideImage(rightImage);
                            ShowImage(leftImage);
                            Testname.text = d.leftSpeaker;
                            AssetManager.LoadSprite(d.leftImage, (Sprite s) =>
                            {
                                leftImage.GetComponent<Image>().sprite = s;
                            });
                            
                        }

                        if (d.currentSpeaker == "Right")
                        {
                            SelectInstructions.gameObject.SetActive(false);
                            HideImage(Space);
                            HideImage(leftEmotion);
                            HideImage(leftImage);
                            ShowImage(rightImage);
                            Testname.text = d.rightSpeaker;
                            AssetManager.LoadSprite(d.rightImage, (Sprite s) =>
                            {
                                rightImage.GetComponent<Image>().sprite = s;
                            });
                        }

                        DialogueText.text = d.dialogue;
                        nextScene = d.nextcutsceneRefID;

                        //check if cutscene over
                        if (d.nextcutsceneRefID == -1)
                        {
                            cutsceneOver = true;
                            currentCutsceneID++;
                            CutSceneSet();
                            //go to next scene here
                        }
                    }
                   
                }
            }
        }
    }
}
