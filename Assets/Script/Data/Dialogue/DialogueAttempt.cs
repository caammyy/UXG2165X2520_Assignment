using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueAttempt : MonoBehaviour
{
    public GameController GC;
    public Image leftImage;
    public Image rightImage;

    public Image leftEmotion;
    public Image rightEmotion;

    public Image Space;
    public TextMeshProUGUI SelectInstructions;
    public Button NextSceneButton;

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
    int index = 0;
    bool isChoice;
    public int nextScene = 101001;
    bool cutsceneOver = true;
    List<Dialogue> currentCutscene;

    void Start()
    {
        
    }
    
    private void Awake()
    {
        GC = GameObject.Find("GameController").GetComponent<GameController>();
        HideBox(selectionBox);
        HideImage(leftImage);
        HideImage(rightImage);
        HideImage(leftEmotion);
        HideImage(rightEmotion);
        SelectInstructions.gameObject.SetActive(false);
        NextSceneButton.gameObject.SetActive(false);
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
        CutSceneSet();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ReadCutscene();
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
                if (d.cutsceneSetID == GC.currentCutsceneID)
                {
                    newCutscene.Add(d);
                }
            }
            
            currentCutscene = newCutscene;
            nextScene = currentCutscene[index].cutsceneRefID;
            cutsceneOver = false;
        }

        else return;
    
    }

    public void ReadCutscene()
    {
        if (isChoice)
        {
            return;
        }

        else
        {
            //if choice show choice
            if (currentCutscene[index].nextcutsceneRefID == -2)
            {
                isChoice = true;

                HideImage(Space);
                SelectInstructions.gameObject.SetActive(true);
                HideImage(rightEmotion);
                HideImage(rightImage);
                ShowImage(leftImage);
                HideBox(dialogueBox);
                ShowBox(selectionBox);

                List<string> choices = SplitStringToList(currentCutscene[index].choices);

                characterNameSelect.text = currentCutscene[index].leftSpeaker;

                select1text.text = choices[0];
                select1button.GetComponent<ButtonDestination>().destination = choices[1];

                select2text.text = choices[2];
                select2button.GetComponent<ButtonDestination>().destination = choices[3];

                //this.GetComponent<SpriteRenderer>().sprite = AssetManager.LoadSprite(Game.GetImage())
                Debug.Log("PAUSED");

                return; //ends the code so that it doesn't break :)
            }

            else
            {
                ShowImage(Space);

                DialogueText.text = currentCutscene[index].dialogue;
                nextScene = currentCutscene[index].nextcutsceneRefID;

                HideBox(selectionBox);
                ShowBox(dialogueBox);

                if (currentCutscene[index].leftEmotion != "-1")
                {
                    ShowImage(leftEmotion);
                    AssetManager.LoadSprite(currentCutscene[index].leftEmotion, (Sprite s) =>
                    {
                        leftEmotion.GetComponent<Image>().sprite = s;
                    });
                }

                Debug.Log(currentCutscene[index].leftEmotion);

                if (currentCutscene[index].rightEmotion != "-1")
                {
                    HideImage(leftEmotion);
                    ShowImage(rightEmotion);
                    AssetManager.LoadSprite(currentCutscene[index].rightEmotion, (Sprite s) =>
                    {
                        rightEmotion.GetComponent<Image>().sprite = s;
                    });
                }

                //normal dialogue
                if (currentCutscene[index].currentSpeaker == "Left")
                {
                    SelectInstructions.gameObject.SetActive(false);
                    HideImage(Space);
                    HideImage(rightEmotion);
                    HideImage(rightImage);
                    ShowImage(leftImage);
                    Testname.text = currentCutscene[index].leftSpeaker;
                    AssetManager.LoadSprite(currentCutscene[index].leftImage, (Sprite s) =>
                    {
                        leftImage.GetComponent<Image>().sprite = s;
                    });

                }

                if (currentCutscene[index].currentSpeaker == "Right")
                {
                    SelectInstructions.gameObject.SetActive(false);
                    HideImage(Space);
                    HideImage(leftEmotion);
                    HideImage(leftImage);
                    ShowImage(rightImage);
                    Testname.text = currentCutscene[index].rightSpeaker;
                    AssetManager.LoadSprite(currentCutscene[index].rightImage, (Sprite s) =>
                    {
                        rightImage.GetComponent<Image>().sprite = s;
                    });
                }

                //check if cutscene over
                if (currentCutscene[index].nextcutsceneRefID == -1)
                {
                    cutsceneOver = true;

                    GC.currentCutsceneID = currentCutsceneID + 1;
                    Invoke("GoNextLevel", 2.0f);
                }

                index++;
            }
        }
    }

    public void ReadCutsceneChoice(int destination)
    {
        if (currentCutscene[index].cutsceneRefID == destination)
        {
            DialogueText.text = currentCutscene[index].dialogue;
            nextScene = currentCutscene[index].nextcutsceneRefID;

            HideBox(selectionBox);
            ShowBox(dialogueBox);

            if (currentCutscene[index].leftEmotion != "-1")
            {
                ShowImage(leftEmotion);
                AssetManager.LoadSprite(currentCutscene[index].leftEmotion, (Sprite s) =>
                {
                    leftEmotion.GetComponent<Image>().sprite = s;
                });
            }

            Debug.Log(currentCutscene[index].leftEmotion);

            if (currentCutscene[index].rightEmotion != "-1")
            {
                HideImage(leftEmotion);
                ShowImage(rightEmotion);
                AssetManager.LoadSprite(currentCutscene[index].rightEmotion, (Sprite s) =>
                {
                    rightEmotion.GetComponent<Image>().sprite = s;
                });
            }

            //normal dialogue
            if (currentCutscene[index].currentSpeaker == "Left")
            {
                SelectInstructions.gameObject.SetActive(false);
                HideImage(Space);
                HideImage(rightEmotion);
                HideImage(rightImage);
                ShowImage(leftImage);
                Testname.text = currentCutscene[index].leftSpeaker;
                AssetManager.LoadSprite(currentCutscene[index].leftImage, (Sprite s) =>
                {
                    leftImage.GetComponent<Image>().sprite = s;
                });

            }

            if (currentCutscene[index].currentSpeaker == "Right")
            {
                SelectInstructions.gameObject.SetActive(false);
                HideImage(Space);
                HideImage(leftEmotion);
                HideImage(leftImage);
                ShowImage(rightImage);
                Testname.text = currentCutscene[index].rightSpeaker;
                AssetManager.LoadSprite(currentCutscene[index].rightImage, (Sprite s) =>
                {
                    rightImage.GetComponent<Image>().sprite = s;
                });
            }

            //check if cutscene over
            if (currentCutscene[index].nextcutsceneRefID == -1)
            {
                cutsceneOver = true;

                GC.currentCutsceneID = currentCutsceneID + 1;
                Invoke("GoNextLevel", 2.0f);
            }

            isChoice = false;
            index++;
        }

        else
        {
            index++;
            ReadCutsceneChoice(destination);
        }
    }

    public void DialogueStarter()
    {
        HideBox(selectionBox);
        HideImage(leftImage);
        HideImage(rightImage);
        HideImage(leftEmotion);
        HideImage(rightEmotion);
        SelectInstructions.gameObject.SetActive(false);
        NextSceneButton.gameObject.SetActive(false);
    }

    public void GoNextLevel()
    {
        SceneManager.LoadScene("Level_0");
    }
}
