using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Elevatorpanel : MonoBehaviour
{
    public Interactable interactable;
    public TextMeshProUGUI textoSenha;
    public int tokens = 4;
    public string senhaCerta = "1401";
    public string senhaTentativa;
    public GameObject andar1;
    public GameObject andar2;
    void Start()
    {
        andar1.SetActive(true);
        andar2.SetActive(false);
    }

    
    void Update()
    {
        
    }
    public void enviar()
    {
        if (tokens <= 0)
        {
            if (senhaTentativa == senhaCerta)
            {
                if (interactable.estadoDoElevador == true)
                {
                    interactable.ElevatorDoors();
                }
                Invoke("trocarDeAndar", 2);
                senhaTentativa = "";
                textoSenha.text = senhaTentativa;
            }
        }
    }
    public void deletar()
    {
        senhaTentativa = "";
        textoSenha.text = senhaTentativa;
        tokens = 4;
    }
    public void trocarDeAndar()
    {
        andar1.SetActive(false);
        andar2.SetActive(true);
    }
    #region botoesNumericos
    public void botao1()
    {
        if (tokens > 0)
        {
            tokens--;
            senhaTentativa += "1";
            textoSenha.text = senhaTentativa;
            Debug.Log(senhaTentativa);
        }
    }
    public void botao2()
    {
        if (tokens > 0)
        {
            tokens--;
            senhaTentativa += "2";
            textoSenha.text = senhaTentativa;
            Debug.Log(senhaTentativa);
        }
    }
    public void botao3()
    {
        if (tokens > 0)
        {
            tokens--;
            senhaTentativa += "3";
            textoSenha.text = senhaTentativa;
            Debug.Log(senhaTentativa);
        }
    }
    public void botao4()
    {
        if (tokens > 0)
        {
            tokens--;
            senhaTentativa += "4";
            textoSenha.text = senhaTentativa;
            Debug.Log(senhaTentativa);
        }
    }
    public void botao5()
    {
        if (tokens > 0)
        {
            tokens--;
            senhaTentativa += "5";
            textoSenha.text = senhaTentativa;
            Debug.Log(senhaTentativa);
        }
    }
    public void botao6()
    {
        if (tokens > 0)
        {
            tokens--;
            senhaTentativa += "6";
            textoSenha.text = senhaTentativa;
            Debug.Log(senhaTentativa);
        }
    }
    public void botao7()
    {
        if (tokens > 0)
        {
            tokens--;
            senhaTentativa += "7";
            textoSenha.text = senhaTentativa;
            Debug.Log(senhaTentativa);
        }
    }
    public void botao8()
    {
        if (tokens > 0)
        {
            tokens--;
            senhaTentativa += "8";
            textoSenha.text = senhaTentativa;
            Debug.Log(senhaTentativa);
        }
    }
    public void botao9()
    {
        if (tokens > 0)
        {
            tokens--;
            senhaTentativa += "9";
            textoSenha.text = senhaTentativa;
            Debug.Log(senhaTentativa);
        }
    }
    public void botao0()
    {
        if (tokens > 0)
        {
            tokens--;
            senhaTentativa += "0";
            textoSenha.text = senhaTentativa;
            Debug.Log(senhaTentativa);
        }
    }
    #endregion
}
