using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public PlayerLook playerLook;
    public static HUDController instance;
    public GameObject menuPanel;
    public GameObject PlayerHUD;
    public GameObject PausePanel;
    public bool menuAberto = true;
    public bool canPause = false;
    private void Start()
    {
        playerMovement.canMove = false;
        menuPanel.SetActive(true);
        PlayerHUD.SetActive(false);
        PausePanel.SetActive(false);
    }
    private void Update()
    {
        if (canPause)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (menuAberto)
                {
                    resumeGame();
                }
                else
                {
                    pauseGame();
                }

            }
        }
    }
    public void pauseGame()
    {
        menuAberto = true;
        Cursor.lockState = CursorLockMode.None;
        PausePanel.SetActive(true);
        playerLook.LockLook();
        Time.timeScale = 0;
    }
    public void resumeGame()
    {
        menuAberto = false;
        Time.timeScale = 1;
        PausePanel.SetActive(false);
        playerLook.FreeLook();
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void FecharJogo()
    {
        Application.Quit();
        Debug.Log("morri!");
    }
    private void Awake()
    {
        instance = this;
    }

    [SerializeField] public TMP_Text interactionText;

    public void EnableInteractionText(string text)
    {
        interactionText.text = text + "(E)";
        interactionText.gameObject.SetActive(true);
    }
    public void DisableInteractionText()
    {
        interactionText.gameObject.SetActive(false);
    }
}
