using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public PlayerLook playerLook;
    public HUDController HUDController;
    public Interactable interactable;
    public EnemyGrab enemyGrab;
    [SerializeField] TextMeshProUGUI sanityDisplay;
    [SerializeField] float remainingTime;

    [SerializeField] float maxTime;
    public bool gameStart = false;
    public Transform player;
    public float enemyDetection = 2f;
    public LayerMask enemyMask;
    private void Start()
    {
        maxTime = remainingTime;
    }
    // Update is called once per frame
    void Update()
    {
        enemyGrab = null;
        Collider[] colliders = Physics.OverlapSphere(player.position, enemyDetection, enemyMask);

        foreach (Collider collider in colliders)
        {
            EnemyGrab grabComponent = collider.GetComponent<EnemyGrab>();
            if (grabComponent != null)
            {
                enemyGrab = grabComponent;
                break;
            }
        }

        if (gameStart)
        {
            //if (Input.GetKeyDown(KeyCode.B))
            //{
            //    TakeDamage();
            //}
            if (remainingTime > 0)
            {
                if (enemyGrab != null && enemyGrab.grabed == true)
                {
                    remainingTime -= 100f * Time.deltaTime;
                }
                else
                {
                    remainingTime -= Time.deltaTime;
                }
            }
            else if (remainingTime < 0)
            {
                remainingTime = 0;
            }
            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            sanityDisplay.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            if (remainingTime == 0)
            {
                SceneManager.LoadScene(0);
            }
            if (remainingTime < maxTime / 6)
            {
                sanityDisplay.color = Color.red;
            }
        }
    }
    public void startGame()
    {
        playerMovement.canMove = true;
        HUDController.canPause = true;
        playerLook.FreeLook();
        gameStart = true;
        HUDController.menuAberto = false;
        HUDController.menuPanel.SetActive(false);
        HUDController.PlayerHUD.SetActive(true);
        interactable.ElevatorDoors();
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("inimigo"))
    //    {
    //        remainingTime -= 120; 
    //    }
    //}
    //void TakeDamage()
    //{
    //    remainingTime -= 120f * Time.deltaTime;
    //}
}
