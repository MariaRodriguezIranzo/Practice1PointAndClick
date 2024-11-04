using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FlorBehaviourScript : MonoBehaviour, IPointerClickHandler
{
    public bool hasGrown = false; // La flor solo crece si ha sido regada
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

        if (dialogueManager == null)
        {
            Debug.LogError("DialogueManager no está asignado.");
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Caso "Mirar"
        if (buttonsBehaviourScript.GetLookButton())
        {
            if (hasGrown)
            {
                dialogueManager.SetDialogue("La flor ha crecido.");
            }
            else
            {
                dialogueManager.SetDialogue("Aún no ha crecido, necesita agua.");
            }
            buttonsBehaviourScript.ResetAllButtonsAndStates();
        }

        // Caso "Usar" (Hacer crecer la flor)
        if (buttonsBehaviourScript.GetUseButton())
        {
            if (!hasGrown)
            {
                dialogueManager.SetDialogue("La flor está creciendo...");
                animator.SetBool("isGrown", true); // Activar animación de crecimiento
                hasGrown = true;
            }
            buttonsBehaviourScript.ResetAllButtonsAndStates();
        }

        // Caso "Coger"
        if (buttonsBehaviourScript.GetGrabButton())
        {
            if (hasGrown)
            {
                dialogueManager.SetDialogue("Has cogido la flor.");

                // Clona la flor y la mueve al inventario
                GameObject florClone = Instantiate(gameObject);
                florClone.transform.SetParent(inventoryContent);
                florClone.transform.localScale = Vector3.one; // Ajustar escala

                gameObject.SetActive(false); // Ocultar la flor original en la escena
            }
            else
            {
                dialogueManager.SetDialogue("No puedes coger una flor que aún no ha crecido.");
            }
            buttonsBehaviourScript.ResetAllButtonsAndStates();
        }
    }
}
