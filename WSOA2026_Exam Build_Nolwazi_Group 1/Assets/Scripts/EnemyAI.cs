using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{   
    public GameObject sensor;
    private NavMeshAgent agent;
    public float enemySpeed;
    public bool playerSpotted;

    public Transform[] patrolPoints;
    public int targetPoint;
    public Transform patrolTarget;
    public Transform eTarget;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = enemySpeed;
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        sensor = transform.GetChild(0).gameObject;

        targetPoint = 0;
        eTarget = patrolPoints[targetPoint];

        StartCoroutine(hasEnemyMoved(transform.position));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //if (playerSpotted == false)
        //{
            //patroling();
            //followPlayer(eTarget);
        //}
        agent.SetDestination(eTarget.position);
        
    }

    public void followPlayer(Vector3 target)
    {
        Vector2 direction = target - transform.position;
        direction.Normalize();
        transform.position = Vector2.MoveTowards(this.transform.position, target, enemySpeed * Time.deltaTime);

        //if (target == transform.position)
            //playerSpotted = false;
    }

    public void patroling()
    {
        //Debug.Log(eTarget.name);
        //if (Mathf.Abs( transform.position.x - patrolPoints[targetPoint].position.x) < 1f && Mathf.Abs( transform.position.y - patrolPoints[targetPoint].position.y) < 1f)
        //{
            Debug.Log("Arrived at patrol point "+ targetPoint.ToString() );
            targetPoint++;
            if (targetPoint >= patrolPoints.Length)
                targetPoint = 0;
        //}
        eTarget = patrolPoints[targetPoint];
        patrolTarget.position = eTarget.position;
    }

    public void sensorMovement(float xPOS, float yPOS)
    {
        var xAbs = Mathf.Abs(xPOS);
        var yAbs = Mathf.Abs(yPOS);
        if (yAbs > xAbs && yPOS > 0) //up
        {
            sensor.transform.localPosition = new Vector2(0f, 1.9f);
            sensor.transform.rotation = Quaternion.Euler(0f, 0f, 180f);
        }
        else if (yAbs > xAbs && yPOS < 0) //down
        {
            sensor.transform.localPosition = new Vector2(0f, -1.9f);
            sensor.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if (yAbs < xAbs && xPOS < 0) //left
        {
            sensor.transform.localPosition = new Vector2(-1.9f, 0f);
            sensor.transform.rotation = Quaternion.Euler(0f, 0f, 30f);
            
        }
        else if (yAbs < xAbs && xPOS > 0) //right
        {
            sensor.transform.localPosition = new Vector2(1.9f, 0f);
            sensor.transform.rotation = Quaternion.Euler(0f, 0f, -30f);
        }

    }

    public IEnumerator hasEnemyMoved(Vector2 currPOS)
    {
        yield return new WaitForEndOfFrame();
        Vector2 nextPOS = transform.position;

        var changeInPOS = nextPOS - currPOS;
        if (changeInPOS != currPOS)
        {
            sensorMovement(changeInPOS.x, changeInPOS.y);
        }
        StartCoroutine(hasEnemyMoved(transform.position));

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.transform == patrolTarget)
        {
            patroling();
        }
    }
}
