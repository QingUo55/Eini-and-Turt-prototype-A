using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using static InputHandler;

public class GameHandler : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    public GameState gameState;
    public Character ActiveCharacter;
    public GameObject ObjEini;
    public GameObject ObjTurt;
    private bool isEiniActive;
    public bool PushToggle;
    public bool sprintToggle;


    private static GameHandler instance;

    public static GameHandler Instance => instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        SwitchCharacter(true);
        InputHandler.Instance.OnCharacterSwitched += SwitchCharacter;
        EiniAnimationHandler.Instance.PlayIdleAnimation();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
       
    }

    public virtual void SwitchCharacter(bool switchCharacter)
    {
        if (!isEiniActive)
        {
            ActiveCharacter = Character.Eini;
            ObjEini.SetActive(true);
            ObjTurt.SetActive(false);
            isEiniActive = true;
            PushToggle = false;
            ObjEini.transform.position = ObjTurt.transform.position;
            sprintToggle = true;       
        }
        else
        {
            ActiveCharacter = Character.Turt;
            ObjEini.SetActive(false);
            ObjTurt.SetActive(true);
            isEiniActive = false;
            PushToggle = true;
            ObjTurt.transform.position = ObjEini.transform.position;
            sprintToggle = false;
        }
    } 

    public void SetState(GameState whatStateToSet)
    {
        gameState = whatStateToSet;
    }
}
public enum GameState
{
    Menu = 0,
    Cutscene = 1,
    Gameplay = 2,
    Dialog = 3,
    Shop = 4,
    Reward = 5,
    GameOver = 6
}

public enum Character
{
    Eini,
    Turt
}
