using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene01_Events : MonoBehaviour
{
    [Header("Scene Objects")]
    [SerializeField] private GameObject FadeScreenIn;
    [SerializeField] private GameObject Char1;
    [SerializeField] private GameObject Char2;
    [SerializeField] private GameObject TextBox;

    [Header("Audio")]
    [SerializeField] private AudioSource audio1;
    [SerializeField] private AudioSource audio2;

    [Header("Systems")]
    [SerializeField] private CSVLoader csvLoader;
    [SerializeField] private TextCreator textCreator;
    [SerializeField] private TMPro.TMP_Text speakerNameText;


    void Start()
    {
        StartCoroutine(EventStarter());
    }

    IEnumerator EventStarter()
    {
        // Intro fade
        FadeScreenIn.SetActive(true);
        yield return new WaitForSeconds(1f);
        FadeScreenIn.SetActive(false);

        // First character enters
        Char1.SetActive(true);
        audio1.Play();

        yield return new WaitForSeconds(2f);

        // Load dialogue from CSV
        List<DialogueLine> dialogue = csvLoader.LoadDialogue();

        // Play all lines sequentially
        foreach (DialogueLine line in dialogue)
        {
            yield return ShowLine(line);
        }

        // Continue scene after dialogue
        yield return new WaitForSeconds(2f);

        Char2.SetActive(true);

        yield return new WaitForSeconds(4f);
        audio2.Play();
    }

    IEnumerator ShowLine(DialogueLine line)
    {
        TextBox.SetActive(true);

        // Update speaker name
        if (speakerNameText != null)
            speakerNameText.text = line.speaker;

        // Optional: react to speaker
        HandleSpeaker(line.speaker);

        // Type the text and wait until it's fully done
        yield return textCreator.TypeText(line.text);

        // Wait after the line (from CSV)
        yield return new WaitForSeconds(line.delay);
    }

    void HandleSpeaker(string speaker)
    {
        // Basic example, expand later
        switch (speaker)
        {
            case "Char1":
                Char1.SetActive(true);
                Char2.SetActive(false);
                break;

            case "Char2":
                Char2.SetActive(true);
                Char1.SetActive(false);
                break;
        }
    }
}