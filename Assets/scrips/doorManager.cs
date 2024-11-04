using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 
using UnityEngine.SceneManagement; 

public class doorManager : MonoBehaviour, IPointerClickHandler 
{
    public GameObject eventSystem; 
    private ButtonsBehaviourScript buttonsBehaviourScript; 

    // Referencia al DialogueManager
    public DialogueManager dialogueManager;

    void Start()
    {
        buttonsBehaviourScript = eventSystem.GetComponent<ButtonsBehaviourScript>();
        // Verifica si el DialogueManager está asignado
        if (dialogueManager == null)
        {
            Debug.LogError("DialogueManager no está asignado en el doorManager.");
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Caso "Mirar"
        if (buttonsBehaviourScript.GetLookButton())
        {
            dialogueManager.SetDialogue("Esta es la puerta de entrada");
            buttonsBehaviourScript.ResetAllButtonsAndStates();
        }

        // Caso "Usar"
        if (buttonsBehaviourScript.GetUseButton())
        {
            SceneManager.LoadScene("level2"); // Cambia el nombre por el de tu escena
        }
    }
}
