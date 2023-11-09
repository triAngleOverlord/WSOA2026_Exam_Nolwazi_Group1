using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{   
    private GameObject sensor;
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
        agent.SetDestination(eTarget.position);
    }
    public void patroling()
    {
        targetPoint++;
        if (targetPoint >= patrolPoints.Length)
            targetPoint = 0;

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
        else if (collision != null && collision.CompareTag("Player"))
        {
            //player enters escape scene
        }
    }

    public void pause()
    {
        agent.speed = 0f;
    }

    public void resume()
    {
        agent.speed = enemySpeed;
    }
}
