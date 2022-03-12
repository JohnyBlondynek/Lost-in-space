using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class AIMovement : MonoBehaviour
{
    int speed;
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;
    public Transform[] Waypints;
    public int WayPointIndex;
    public bool RandomWaypint;
    public FieldOfView fieldOfView;
    public Animator[] animators;
    public void Start()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        agent.GetComponent<Rigidbody>();
    }
    public float szukanie=3;
    bool czyn;
    private void Update()
    {
        if (!czyn)Move();
        else
        {
            agent.enabled = false;
            animators[0].SetBool("Move", false);
            animators[1].SetBool("Move", false);
        }
    }
    void Move()
    {
        //Check for sight and attack range
        if (!fieldOfView.canSeePlayer) Patroling();
        if (szukanie < 3) ChasePlayer();
        if (fieldOfView.canSeePlayer) szukanieGracza();
        animators[0].SetBool("Move", true);
        animators[0].speed = speed;
        animators[1].SetBool("Move", true);
        animators[1].speed = speed;
        agent.speed = speed;
    }
    void szukanieGracza()
    {
        szukanie = 0;
    }

    private void Patroling()
    {
        speed = 3;
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
            if (RandomWaypint)
            {
                WayPointIndex = Random.Range(0, Waypints.Length);
            }
            else
            {
                if (WayPointIndex < Waypints.Length) WayPointIndex++;
                if (WayPointIndex == Waypints.Length) WayPointIndex = 0;
            }
            walkPoint = new Vector3(Waypints[WayPointIndex].transform.position.x, Waypints[WayPointIndex].transform.position.y, Waypints[WayPointIndex].transform.position.z);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }
    private void ChasePlayer()
    {
        head.LookAt(player);
        speed = 7;
       agent.SetDestination(player.position);
        szukanie += 1 * Time.deltaTime;
    }
    public GameObject[] cameras;
    public Transform head;
    public AudioSource[] audios;
    IEnumerator Jumpscere()
    {
        agent.GetComponent<Rigidbody>().isKinematic = true;
        FindObjectOfType<Player>().pauza = true;
        head.transform.rotation = new Quaternion(0,0,0,0);
        animators[1].speed = 2;
        cameras[1].SetActive(true);
        cameras[0].SetActive(false);
        animators[1].SetBool("Jump", true);
        audios[0].Play();
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!czyn)
            {
                StartCoroutine(Jumpscere());
                czyn = true;
            }
        }
    }
}
