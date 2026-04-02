using System.Collections;
using TMPro;
using UnityEngine;

public class TextCreator : MonoBehaviour
{
    [SerializeField] private TMP_Text textUI;
    [SerializeField] private float typingSpeed = 0.03f;

    private Coroutine typingCoroutine;

    public IEnumerator TypeText(string text)
    {
        // Stop previous typing if running
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        typingCoroutine = StartCoroutine(TypeRoutine(text));

        yield return typingCoroutine; // 👈 this is the key
    }

    private IEnumerator TypeRoutine(string text)
    {
        textUI.text = "";

        foreach (char c in text)
        {
            textUI.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }

        typingCoroutine = null;
    }
}