using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

//Ashley and Cammy
public class DialogueAttempt : MonoBehaviour
{
    public GameController GC;
    public Image leftImage;
    public Image rightImage;

    public Image leftEmotion;
    public Image rightEmotion;

    public TextMeshProUGUI SelectInstructions;
    public Button nextButton;

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
    //int currentCutsceneID = 101;
    int currentCutsceneID;
    public int index = 1;
    public bool isChoice;
    public int nextScene = 101001;
    bool cutsceneOver = true;
    List<Dialogue> currentCutscene;

    private string lastScene;

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
        return s;
        //s[0] = text1
        //s[1] = selected cutsceneid
    }
   
    void Update()
    {
    }

    public void CutSceneSet()
    {
        if (cutsceneOver == true)
        {
            List<Scene> sList = Game.GetSceneList();
            if (PlayerPrefs.HasKey("LastScene"))
            {
                for (int i = 0; i < sList.Count; i++)
                {
                    if (sList[i].sceneName == PlayerPrefs.GetString("LastScene"))
                    {
                        if ((i + 1) != sList.Count)
                        {
                            currentCutsceneID = sList[i + 1].cutsceneSetID;
                            PlayerPrefs.DeleteKey("LastScene");
                        }
                        else
                        {
                            currentCutsceneID = sList[0].cutsceneSetID;
                        }
                    }
                }
            }
            else
            {
                currentCutsceneID = sList[0].cutsceneSetID;
            }
            Debug.Log(currentCutsceneID);
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
            nextScene = currentCutscene[index].cutsceneRefID;
            cutsceneOver = false;
        }

        else return;
    
    }

    public void ReadCutscene()
    {
        CutSceneSet();
        //if choice show choice
        if (index < currentCutscene.Count)
        {
            if (currentCutscene[index].nextcutsceneRefID == -2)
            {
                //isChoice = true;
                if (currentCutscene[index].leftEmotion != "-1")
                {
                    AssetManager.LoadSprite(currentCutscene[index].leftEmotion, (Sprite s) =>
                    {
                        leftEmotion.GetComponent<Image>().sprite = s;
                    });
                }
                if (currentCutscene[index].leftImage != "-1")
                {
                    AssetManager.LoadSprite(currentCutscene[index].leftImage, (Sprite s) =>
                    {
                        leftImage.GetComponent<Image>().sprite = s;
                    });
                }
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

                return; //ends the code so that it doesn't break :)
            }
            else
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
                    HideImage(leftEmotion);
                    HideImage(leftImage);
                    ShowImage(rightImage);
                    Testname.text = currentCutscene[index].rightSpeaker;
                    AssetManager.LoadSprite(currentCutscene[index].rightImage, (Sprite s) =>
                    {
                        rightImage.GetComponent<Image>().sprite = s;
                    });
                }
                index++;
            }
            if (nextScene == -1)
            {
                cutsceneOver = true;
                nextButton.enabled = false;
                currentCutsceneID = currentCutsceneID + 1;
                Invoke("GoNextLevel", 2.0f);
            }
        }
        
    }

    public void ReadCutsceneChoice(int destination)
    {
        CutSceneSet();

        if (index < currentCutscene.Count)
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
                if (nextScene == -1)
                {
                    cutsceneOver = true;
                    nextButton.enabled = false;

                    currentCutsceneID = currentCutsceneID + 1;
                    Invoke("GoNextLevel", 2.0f);
                }
                while (currentCutscene[index].cutsceneRefID != nextScene)
                {
                    index++;
                }
            }

            else
            {
                index++;
                ReadCutsceneChoice(destination);
            }
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
        ReadCutscene();
    }

    public void GoNextLevel()
    {
        Debug.Log("teleporting");
        if (currentCutsceneID == 102)
        {
            SceneManager.LoadScene("CharacterSelect");
        }
        else if (currentCutsceneID == 103)
        {
            SceneManager.LoadScene("endScreen");
        }
    }
}
