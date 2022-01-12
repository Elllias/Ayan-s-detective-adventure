using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class DialogueManager : MonoBehaviour
{
    public Text Text;
    public Text NpcName;
    public Button FirstChoiseButton;
    public Button SecondChoiseButton;
    public Button ThirdChoiseButton;
    public GameObject UncommonWindow;
    public TextAsset TA;
    public Image Background;
    private int curNode;
    private Dialogue dialogue;
    private SoundManager soundManager;
    private BackgroundManager backgroundManager;

    private bool dialogEnded = false;

    private void Start()
    {
        dialogue = Dialogue.Load(TA);
        soundManager = gameObject.GetComponent<SoundManager>();
        backgroundManager = gameObject.GetComponent<BackgroundManager>();

        FirstChoiseButton.onClick.AddListener(() => AnswerClicked(0));
        SecondChoiseButton.onClick.AddListener(() => AnswerClicked(1));
        ThirdChoiseButton.onClick.AddListener(() => AnswerClicked(2));

        AnswerClicked(-1);
    }

    private void Update()
    {
        if(dialogEnded == true)
        {
            SceneManager.LoadScene(0);
        }
    }

    private void AnswerClicked(int curBut)
    {
        if (curBut == -1)
            curNode = 0;
        else
        {
            if (dialogue.nodes[curNode].answers[curBut].end == "true")
                dialogEnded = true;
            if (dialogue.nodes[curNode].answers[curBut].emotion == "bad")
                CL.CurrentRelations -= 10;
            if (dialogue.nodes[curNode].answers[curBut].emotion == "good")
                CL.CurrentRelations += 10;
            curNode = dialogue.nodes[curNode].answers[curBut].nextNode;
        }

        if (dialogue.nodes[curNode].ucw == "true")
        {
            UncommonWindow.SetActive(true);
        }

        if (dialogue.nodes[curNode].background != null)
            backgroundManager.ChangeBackground(dialogue.nodes[curNode].background);

        if (dialogue.nodes[curNode].sound != null)
        {
            soundManager.PlaySound(dialogue.nodes[curNode].sound);
        }

        NpcName.text = dialogue.nodes[curNode].npcname;
        Text.text = dialogue.nodes[curNode].npctext;
        FirstChoiseButton.GetComponentInChildren<Text>().text = dialogue.nodes[curNode].answers[0].text;

        if(dialogue.nodes[curNode].answers.Length >= 2)
            TurnOnButton(SecondChoiseButton, 1);
        else
            TurnOffButton(SecondChoiseButton);

        if (dialogue.nodes[curNode].answers.Length == 3)
            TurnOnButton(ThirdChoiseButton, 2);
        else
            TurnOffButton(ThirdChoiseButton);
    }

    private void TurnOnButton(Button button, int answerNumber)
    {
        button.enabled = true;
        button.GetComponentInChildren<Image>().gameObject.SetActive(true);
        button.GetComponentInChildren<Text>().text = dialogue.nodes[curNode].answers[answerNumber].text;
    }

    private void TurnOffButton(Button button)
    {
        button.enabled = false;
        button.GetComponentInChildren<Text>().text = "";
        button.GetComponentInChildren<Image>().gameObject.SetActive(false);
    }
}
