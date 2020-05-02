using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Navigation : MonoBehaviour
{
    private NavMeshAgent agent;

    public GameObject[] path;
    public float speed = 5f;

    int currIndex = 0;
    bool disable = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!disable)
        {
            Vector3 objPos = new Vector3(transform.position.x, 0, transform.position.z);
            Vector3 destPos = new Vector3(agent.destination.x, 0, agent.destination.z);
            float dist = Vector3.Distance(objPos, destPos);

            if (dist < 2)
            {
                currIndex++;

                if (currIndex < path.Length)
                    agent.SetDestination(path[currIndex].transform.position);
                else
                    disable = true;
            }
        }
    }

    public void Navigate()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.speed = speed;
        agent.SetDestination(path[currIndex].transform.position);

        disable = false;
    }
}
