using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//anotações:
// por enquanto pulo desativado.
//
// por alguma macumba o jogador não consegue registrar colisão com o inimigo e
// o inimigo tambem não consegue registrar colisão com o player...
//
//
//
//
//
//
public class PlayerMovement : MonoBehaviour
{
    //public EnemyGrab enemyGrab;
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -19.62f;
    //public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    public bool canMove = true;
    // Update is called once per frame
    void Update()
    {
        
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (canMove == true)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);

            //if (Input.GetButtonDown("Jump") &&  isGrounded)
            //{
            //    velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            //}
        }
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("moveblocker"))
        {
            LockMove();
        }
        if (other.CompareTag("killbox"))
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(0);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("moveblocker"))
        {
            FreeMove();
        }
    }
    public void LockMove()
    {
        canMove = false;
    }
    public void FreeMove()
    {
        canMove = true;
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.collider.CompareTag("inimigo"))
    //    {
    //        Debug.Log("wwdrtfbuni");
    //        enemyGrab.Grab();
    //    }
    //}
}