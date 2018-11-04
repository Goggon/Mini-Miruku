﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public Text NameText;
    public Text DialogueText;

    public Animator animator;

    private Queue<string> lines;

	// Use this for initialization
	void Start () {
        lines = new Queue<string>();
	}
	
    public void StartDialogue (Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);

        NameText.text = dialogue.name;

        lines.Clear();

        foreach (string line in dialogue.lines)
        {
            lines.Enqueue(line);
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

        DialogueText.text = line;
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);

        Debug.Log("end of conversation");
    }
}
