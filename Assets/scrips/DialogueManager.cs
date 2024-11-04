using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI TextMeshPro;
    public string[] dialoges;
    public float letterDelay = 0.05f;
    private Coroutine typingCoroutine;

    void Start()
    {
        // Mostrar el mensaje inicial al empezar el juego
        SetDialogue("¿Qué deseas hacer?");
    }

    public void StartDialogue()
    {
        typingCoroutine = StartCoroutine(TypeDiaLogue());
    }

    IEnumerator TypeDiaLogue()
    {
        foreach (string dialoge in dialoges)
        {
            TextMeshPro.text = "";
            foreach (char letter in dialoge)
            {
                TextMeshPro.text += letter;
                yield return new WaitForSeconds(letterDelay);
            }
        }
    }

    public void skipDialogue()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
            typingCoroutine = null;
            TextMeshPro.text = dialoges[dialoges.Length - 1];
        }
    }

    // Nueva función para establecer el texto dinámicamente
    public void SetDialogue(string newText)
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        // Establecemos directamente el nuevo texto
        TextMeshPro.text = newText;
    }

    // Nueva función para borrar el texto
    public void ClearDialogue()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }
        TextMeshPro.text = ""; // Limpia el texto del diálogo
    }

    void Update()
    {

    }
}
