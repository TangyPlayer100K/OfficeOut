using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class EnemyGrab : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Animator enemyAnimator;
    public PlayerMovement playerMovement;
    public PlayerLook playerLook;
    public GameObject player;
    public GameObject playerCamera;
    public GameObject enemyFace;

    public float struggleMax = 100;
    public float struggleDone;
    public int strugglePerPress = 10;
    public float enemyRotation;
    public float opositeEnemyRotation;
    public Vector3 directionToEnemy;
    Quaternion lookRotation;
    public Vector3 directionToPlayer;
    Quaternion lookRotationToPlayer;

    [SerializeField] Slider struggleSlider;
    [SerializeField] GameObject struggleSliderObject;
    [SerializeField] public KeyCode struggleKey;

    public bool grabed = false;
    public bool stunned = false;
    public bool recoverPedido = false;
    public float stunTime = 5;
    void Start()
    {
        playerCamera = GameObject.Find("FirstPersonCamera");
        player = GameObject.Find("FirstPersonPlayer");
        struggleSlider.maxValue = struggleMax;
        struggleSliderObject.SetActive(false);
        
    }
    void Update()
    {
        #region debuging
        //if (Input.GetKeyDown(KeyCode.V) && stunned == false)
        //{
        //    Grab();
        //}
        #endregion
        
        if (grabed)
        {
            struggleSlider.value = struggleDone;
            if (Time.timeScale == 1)
            {
                if (Input.GetKeyDown(struggleKey))
                {
                    struggleDone += strugglePerPress;
                }
                if (struggleDone < 0)
                {
                    struggleDone = 0;
                }
                if (struggleDone < struggleMax)
                {
                    if (struggleDone > 0)
                    {
                        struggleDone -= 10f * Time.deltaTime;
                    }
                }
                if (struggleDone >= struggleMax)
                {
                    Release();
                }
            }
        }
        if (stunned)
        {
            if (!recoverPedido)
            {
                recoverPedido = true;
                Invoke("Recover", stunTime);
            }
        }
    }
    public void Grab()
    {
        audioMixer.SetFloat("volume", 20);
        directionToEnemy = enemyFace.transform.position - player.transform.position;
        directionToEnemy.y = 0;
        lookRotation = Quaternion.LookRotation(directionToEnemy);
        player.transform.rotation = lookRotation;

        directionToPlayer = transform.position - player.transform.position;
        directionToPlayer.y = 0;
        lookRotationToPlayer = Quaternion.LookRotation(-directionToPlayer);
        transform.rotation = lookRotationToPlayer;

        //playerCamera.transform.eulerAngles = new Vector3(-13, playerCamera.transform.rotation.y, playerCamera.transform.rotation.z);

        struggleSliderObject.SetActive(true);
        enemyAnimator.SetTrigger("Attack");
        playerMovement.LockMove();
        playerLook.LockLook();
        grabed = true;
        Debug.Log("Agarrado");
    }
    public void Release()
    {
        audioMixer.SetFloat("volume", 0);
        struggleSliderObject.SetActive(false);
        enemyAnimator.SetTrigger("Stunned");
        playerMovement.FreeMove();
        playerLook.FreeLook();
        grabed = false;
        struggleDone = 0;
        stunned = true;
        Debug.Log("Escapou");
    }
    public void Recover()
    {
        stunned = false;
        recoverPedido = false;
        Debug.Log("Inimigo se recuperou");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && stunned == false)
        {
            //Debug.Log("Colidiu com o jogador");
            Grab();
        }
    }
}
