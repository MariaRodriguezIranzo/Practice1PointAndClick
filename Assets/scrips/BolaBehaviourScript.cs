using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BolaBehaviourScript : MonoBehaviour, IPointerClickHandler
{
    public bool isCollected = false; // Indica si la bola ya ha sido recogida
    public GameObject eventSystem;

    private ButtonsBehaviourScript buttonsBehaviourScript;
    private Animator animator;

    // Referencia al DialogueManager
    public DialogueManager dialogueManager;

    // Referencia al inventario
    public Transform inventoryContent; // Panel de inventario donde se añadirán los objetos recogidos

    void Start()
    {
        buttonsBehaviourScript = eventSystem.GetComponent<ButtonsBehaviourScript>();
        animator = this.GetComponent<Animator>();

        // Verifica si el DialogueManager está asignado
        if (dialogueManager == null)
        {
            Debug.LogError("DialogueManager no está asignado en el BolaBehaviourScript.");
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Caso "Mirar"
        if (buttonsBehaviourScript.GetLookButton())
        {
            if (!isCollected)
            {
                dialogueManager.SetDialogue("Esta es la bola que pertenecía al abuelo de Goku.");
            }
            else
            {
                dialogueManager.SetDialogue("Ya tienes la bola en tu inventario.");
            }
            buttonsBehaviourScript.ResetAllButtonsAndStates();
        }

        // Caso "Usar"
        if (buttonsBehaviourScript.GetUseButton())
        {
            if (!isCollected)
            {
                dialogueManager.SetDialogue("Faltan reunir las otras 6 bolas para invocar a Shenron.");
            }
            else
            {
                dialogueManager.SetDialogue("Primero debes recoger la bola.");
            }
            buttonsBehaviourScript.ResetAllButtonsAndStates();
        }

        // Caso "Coger"
        if (buttonsBehaviourScript.GetGrabButton())
        {
            if (!isCollected)
            {
                dialogueManager.SetDialogue("Has cogido la bola.");
                isCollected = true;

                // Clona la bola y la mueve al inventario
                GameObject bolaClone = Instantiate(gameObject);
                bolaClone.transform.SetParent(inventoryContent);
                bolaClone.transform.localScale = Vector3.one; // Ajustar escala

                gameObject.SetActive(false); // Ocultar la bola original en la escena
            }
            else
            {
                dialogueManager.SetDialogue("Ya has cogido la bola.");
            }
            buttonsBehaviourScript.ResetAllButtonsAndStates();
        }
    }
}
