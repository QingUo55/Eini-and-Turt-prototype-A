using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class UIHandler : MonoBehaviour
{
    
    [SerializeField] TextMeshProUGUI dialogTextBox;
    [SerializeField] List<string> textQueue;
    [SerializeField] string lineToTriggerAction;
    [SerializeField] List<DialogEvents> dialogEvents;
    [SerializeField] Image textBox;

    private Action nextAction;
    private GameState nextState;
    private bool setStateOrNot;
    public int currentText;

    private static UIHandler instance;
    public static UIHandler Instance => instance;

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        Showtext();
    }

    public void Showtext()
    {
        if (textQueue.Count > 0)
        {
            dialogTextBox.text = textQueue[currentText];
        }
        else
        {
            dialogTextBox.text = "";
        }
    }

    public void ShowNextLine()
    {
        setStateOrNot = true;
        if (textQueue.Count > 1)
        {
            textQueue.RemoveAt(0);
            if (textQueue.Count <= 1)
            {
                if (setStateOrNot == true)
                {
                    GameHandler.Instance.SetState(nextState);
                }
            }
        }
        for (int i = 0; i < dialogEvents.Count; i++)
        {
            if (dialogEvents[i].LineToTrigger == textQueue[0])
            {
                dialogEvents[i].ActionToTrigger();
                dialogEvents.Remove(dialogEvents[i]);
            }
        }
    }

    public void ShowNextLine(bool nextStateBool)
    {
        setStateOrNot = nextStateBool;
        if (textQueue.Count > 1)
        {
            textQueue.RemoveAt(0);
            if (textQueue.Count <= 1)
            {
                if (setStateOrNot == true)
                {
                    GameHandler.Instance.SetState(nextState);
                }
            }
        }
    }

    public void NextDialog()
    {
        if (currentText < textQueue.Count - 1)
        {
            currentText++;
        }
        else if (currentText >= textQueue.Count - 1)
        {
            currentText = 0;
        }
    }

    public void ReplaceDialog(Dialog _dl)
    {
        textQueue = _dl.Line;
    }

    public void MoveTextBox(float x, float y)
    {
        textBox.transform.position = new Vector3(x, y);
    }
}
