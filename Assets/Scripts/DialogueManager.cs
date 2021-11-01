using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

using static Dialogue;

public class DialogueManager : MonoBehaviour
{
    public GameObject Window;
    public TextMeshProUGUI Text;
    public Button FirstChoiseButton;
    public Button SecondChoiseButton;
    public Button ThirdChoiseButton;
    public TextAsset TA;
    private bool dialogEnded = false;

    [SerializeField]
    public int curNode = 0;
    public int butClicked;
    Node[] nodes;
    Dialogue dialogue;
    private void Start()
    {
        SecondChoiseButton.enabled = false;
        ThirdChoiseButton.enabled = false;
        Window.SetActive(true);
        dialogue = Dialogue.Load(TA);
        nodes = dialogue.nodes;
        Text.text = nodes[curNode].npctext;
        FirstChoiseButton.GetComponentInChildren<Text>().text = dialogue.nodes[curNode].answers[0].text;

        FirstChoiseButton.onClick.AddListener(butClick1);
        SecondChoiseButton.onClick.AddListener(butClick2);
        ThirdChoiseButton.onClick.AddListener(butClick3);

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
            if (dialogue.nodes[curNode].answers[curBut].end == "True")
                dialogEnded = true;
            curNode = dialogue.nodes[curNode].answers[curBut].nextNode;
        }

        Text.text = dialogue.nodes[curNode].npctext;
        FirstChoiseButton.GetComponentInChildren<Text>().text = dialogue.nodes[curNode].answers[0].text;
        if(dialogue.nodes[curNode].answers.Length >= 2)
        {
            SecondChoiseButton.enabled = true;
            SecondChoiseButton.GetComponentInChildren<Text>().text = dialogue.nodes[curNode].answers[1].text;
        }
        else
        {
            SecondChoiseButton.enabled = false;
            SecondChoiseButton.GetComponentInChildren<Text>().text = "";
        }
        if (dialogue.nodes[curNode].answers.Length == 3)
        {
            ThirdChoiseButton.enabled = true;
            ThirdChoiseButton.GetComponentInChildren<Text>().text = dialogue.nodes[curNode].answers[2].text;
        }
        else
        {
            ThirdChoiseButton.enabled = false;
            ThirdChoiseButton.GetComponentInChildren<Text>().text = "";
        }
    }

    private void butClick1()
    {
        butClicked = 0;
        AnswerClicked(0);
    }
    private void butClick2()
    {
        butClicked = 1;
        AnswerClicked(1);
    }
    private void butClick3()
    {
        butClicked = 2;
        AnswerClicked(2);
    }

    //private void butClick(int numButton) // Не работает, т.к. не возвращает ивент.
    //{
    //    butClicked = numButton;
    //    AnswerClicked(numButton);
    //}
}
