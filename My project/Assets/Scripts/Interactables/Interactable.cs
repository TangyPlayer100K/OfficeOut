using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;

public class Interactable : MonoBehaviour
{
    [SerializeField] Animator doorAnimator;
    [SerializeField] public bool estadoDoElevador = false;

    
    [SerializeField] static bool chave1 = false;
    [SerializeField] public TMP_Text naoDeu;

    #region essentials
    Outline outline;
    public string Message;

    public UnityEvent onInteraction; 

    private void Start()
    {
        outline = GetComponent<Outline>();
        outline.enabled = false;
    }

    public void Interact()
    {
        onInteraction.Invoke();
    }

    public void DisableOutLine()
    {
        outline.enabled = false;
    }
    public void EnableOutLine()
    {
        outline.enabled = true;
    }
    #endregion
    #region interações 
    public void ElevatorDoors()
    {
        if (estadoDoElevador ==  false)
        {
            doorAnimator.SetTrigger("abrir");
            estadoDoElevador = true;
        }
        else
        {
            doorAnimator.SetTrigger("fechar");
            estadoDoElevador = false;
        }
    }

    public void PickUpKey()
    {
        chave1 = true;
        Destroy(gameObject);
    }
    public void OpenDrawer()
    {
        if(chave1 == true)
        {
            chave1 = false;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(0);
        }
        else
        {
            naoDeu.text = "precisa de uma chave";
        }
    }
    #endregion
}
