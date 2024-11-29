using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrolling : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints; // Array de pontos de patrulha
    [SerializeField] private float speed = 2f;      // Velocidade de patrulhamento
    private int targetPoint = 0;                    // Ponto alvo atual
    private EnemyGrab enemyGrab;                   // Refer�ncia ao script EnemyGrab

    void Start()
    {
        targetPoint = 0; // Define o ponto alvo inicial

        // Obt�m o componente EnemyGrab no mesmo GameObject
        enemyGrab = GetComponent<EnemyGrab>();
        if (enemyGrab == null)
        {
            Debug.LogError("EnemyGrab n�o encontrado no GameObject.");
        }
    }

    void Update()
    {
        // Verifica se o inimigo est� agarrando o jogador
        if (enemyGrab != null && enemyGrab.grabed)
        {
            // Se estiver agarrando, n�o patrulha
            return;
        }

        // Verifica se o NPC chegou ao waypoint atual
        if (Vector3.Distance(transform.position, waypoints[targetPoint].position) < 0.1f)
        {
            // Atualiza o targetPoint para o pr�ximo waypoint
            targetPoint = (targetPoint + 1) % waypoints.Length;
        }

        // Gira o objeto para olhar na dire��o do pr�ximo waypoint
        Vector3 direction = waypoints[targetPoint].position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);

        // Move o NPC em dire��o ao waypoint atual
        transform.position = Vector3.MoveTowards(
            transform.position,
            waypoints[targetPoint].position,
            speed * Time.deltaTime
        );
    }
    //[SerializeField] private Transform[] waypoints; //array de pontos de patrulha
    //[SerializeField] private float speed = 2f;      //velocidade de patrulhamento
    //private int targetPoint = 0;                    //ponto alvo atual

    //// Start is called before the first frame update
    //void Start()
    //{
    //    targetPoint = 0; //define o ponto alvo como zero
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    // Verifica se o NPC chegou ao waypoint atual
    //    if (Vector3.Distance(transform.position, waypoints[targetPoint].position) < 0.1f)
    //    {
    //        // Atualiza o targetPoint para o pr�ximo waypoint
    //        targetPoint = (targetPoint + 1) % waypoints.Length;
    //    }

    //    // Gira o objeto para olhar na dire��o do pr�ximo waypoint
    //    Vector3 direction = waypoints[targetPoint].position - transform.position;
    //    Quaternion targetRotation = Quaternion.LookRotation(direction); // Calcula a rota��o desejada
    //    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f); // Suaviza a rota��o

    //    // Move o NPC em dire��o ao waypoint atual
    //    transform.position = Vector3.MoveTowards(
    //        transform.position,
    //        waypoints[targetPoint].position,
    //        speed * Time.deltaTime
    //    );
}

