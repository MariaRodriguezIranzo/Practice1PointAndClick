using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsBehaviourScript : MonoBehaviour
{
    public Button BtnMirar;
    public Button BtnUsar;
    public Button BtnCoger;

    public Color colorDeshabilitado = Color.gray;
    private Color colorHabilitado = new Color(0f, 0.992f, 0f);

    public bool useButton = false;
    public bool lookButton = false;
    public bool grabButton = false;

    public DialogueManager dialogueManager;

    void Start()
    {
        HabilitarTodosLosBotones();
        if (dialogueManager == null)
        {
            Debug.LogError("DialogueManager no está asignado.");
        }
    }

    private void DeshabilitarOtrosBotones(Button botonPulsado)
    {
        CambiarEstadoBoton(BtnMirar, botonPulsado == BtnMirar);
        CambiarEstadoBoton(BtnUsar, botonPulsado == BtnUsar);
        CambiarEstadoBoton(BtnCoger, botonPulsado == BtnCoger);
    }

    private void CambiarEstadoBoton(Button boton, bool habilitado)
    {
        boton.interactable = habilitado;
        Text textoBoton = boton.GetComponentInChildren<Text>();
        if (textoBoton != null)
        {
            textoBoton.color = habilitado ? colorHabilitado : colorDeshabilitado;
        }
    }

    public void HabilitarTodosLosBotones()
    {
        CambiarEstadoBoton(BtnMirar, true);
        CambiarEstadoBoton(BtnUsar, true);
        CambiarEstadoBoton(BtnCoger, true);
        useButton = false;
        lookButton = false;
        grabButton = false;
    }

    public void ResetAllButtonsAndStates()
    {
        HabilitarTodosLosBotones();
    }

    public bool GetUseButton()
    {
        return useButton;
    }

    public bool GetLookButton()
    {
        return lookButton;
    }

    public bool GetGrabButton()
    {
        return grabButton;
    }

    public void UseButtonMirar()
    {
        lookButton = true;
        DeshabilitarOtrosBotones(BtnMirar);
    }

    public void UseButtonUsar()
    {
        useButton = true;
        DeshabilitarOtrosBotones(BtnUsar);
    }

    public void UseButtonCoger()
    {
        grabButton = true;
        DeshabilitarOtrosBotones(BtnCoger);
    }
}
