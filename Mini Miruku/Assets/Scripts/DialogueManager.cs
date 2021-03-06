﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public Text NameText;
    public Text DialogueText;

    public Animator animator;

    private Queue<string> lines;
    private Queue<string> Names;

	// Use this for initialization
	void Start () {
        lines = new Queue<string>();
        Names = new Queue<string>();
	}
	
    public void StartDialogue (Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);

        //NameText.text = dialogue.name;

        lines.Clear();
        Names.Clear();

        foreach (string line in dialogue.lines)
        {
            lines.Enqueue(line);
        }
        foreach (string name in dialogue.names)
        {
            Names.Enqueue(name);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (lines.Count == 0)
        {
            EndDialogue();
            return;
        }

        string line = lines.Dequeue();
        string name = Names.Dequeue();

        DialogueText.text = line;
        NameText.text = name;

    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);

        Debug.Log("end of conversation");
    }
}
