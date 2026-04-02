using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class Scene01_Events : MonoBehaviour
{
    [SerializeField] private GameObject FadeScreenIn;
    [SerializeField] private GameObject Char1;
    [SerializeField] private GameObject Char2;
    [SerializeField] private GameObject TextBox;

    [SerializeField] string textToSpeak;
    [SerializeField] int currentTextLenght;
    [SerializeField] int textLenght;
    [SerializeField] GameObject mainTextObject;

    void Update()
    {
        textLenght = TextCreator.charCount;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(EventStarter());
    }

    IEnumerator EventStarter()
    {
        FadeScreenIn.SetActive(true);
        yield return new WaitForSeconds(1);
        FadeScreenIn.SetActive(false);
        Char1.SetActive(true);
        yield return new WaitForSeconds(2);
        TextBox.SetActive(true);
        textToSpeak = "Hola Loli 2, parece que tienes algo para decir.";
        mainTextObject.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLenght = textToSpeak.Length;
        TextCreator.runTextPrint = true;

        yield return new WaitUntil(() => textLenght == currentTextLenght);
        yield return new WaitForSeconds(0.5f);


        yield return new WaitForSeconds(2);
        Char2.SetActive(true);
        yield return new WaitForSeconds(4);

    }
}
