using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class npc1 : MonoBehaviour
{
    [SerializeField] GameObject NpcTextBox;
    [SerializeField] GameObject InteractButton;
    [SerializeField] List<string> dialogLineQueue;

    private void Start()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D _col)
    {
        if(_col.gameObject != null)
        {
            NpcTextBox.SetActive(true);      
            UIHandler.Instance.MoveTextBox(transform.position.x , transform.position.y + 2);
            UIHandler.Instance.ReplaceDialog(DialogDatabase.Instance.NPC001_Start);
            int currentLine = UIHandler.Instance.currentText;
            UIHandler.Instance.NextDialog();
        }     
    }

    private void OnTriggerExit2D(Collider2D _col)
    {
        NpcTextBox.SetActive(false);
    }
}
