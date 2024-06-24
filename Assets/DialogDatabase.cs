using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DialogDatabase : MonoBehaviour
{
    private Action nextAction;
    private GameState nextState;
    private bool setStateOrNot;

    public Dialog NPC001_Start;
    public Dialog NPC001_SecondTime;
    public Dialog NPC002_Start;

    private static DialogDatabase instance;
    public static DialogDatabase Instance => instance;

    private void Awake()
    {
        instance = this;

        NPC001_Start = new Dialog(new List<string>()
        {
            "Who are you?",
            "What do you seek?"
        });

        NPC001_SecondTime = new Dialog(new List<string>()
        {
            "I have some items to sell",
            "Are you interest to buy some?"
        });

        NPC002_Start = new Dialog(new List<string>()
        {
            "Hi there, you look weird.",
            "Are you Acoustic?",
            "Do you want some icecream?"
        });
    }
}