using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MosterCtrl : MonoBehaviour
{
    public List<Transform> wayPoints;
    public int nextIdx;
    private NavMeshAgent nav;
    public Transform target;
    Animator ani;

    float monsterSpeed = 2f;
    float damping = 2f;
    float TargetDistance;
    float distance;

    bool isTrace = false;

    public float speed
    {
        get { return nav.velocity.magnitude; }
    }

    private void Awake()
    {
        nav = gameObject.GetComponent<NavMeshAgent>();
        target = GameObject.FindWithTag("Player").transform;
        ani = gameObject.GetComponent<Animator>();
        nav.autoBraking = false;
        nav.updateRotation = false;
        nav.speed = monsterSpeed;
        var group = GameObject.Find("WayPointGroup");
        if (group != null)
        {
            group.GetComponentsInChildren<Transform>(wayPoints);
            wayPoints.RemoveAt(0);
        }
        else
            return;
        ani.SetTrigger("Walk_forward");
    }

    private void Update()
    {
        MoveWayPoint();
        RotateMonster();
        AroundTarget();
    }

    void MoveWayPoint()
    {
        if (!isTrace)
        {
            nav.isStopped = false;
            nav.destination = wayPoints[nextIdx].position;

            Patrol();
        }
        if (isTrace)
            return;
    }

    void RotateMonster()
    {
        Quaternion rot = Quaternion.LookRotation(nav.desiredVelocity);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * damping);
        if (rot == Quaternion.Euler(Vector3.zero))
            return;
    }

    void AroundTarget()
    {
        distance = Vector3.Distance(transform.position, target.position);
        if (distance < 5f)
        {
            isTrace = true;
            monsterSpeed = 3f;
            TraceTarget();
        }
        else if (distance >= 5f)
        {
            isTrace = false;
            monsterSpeed = 2f;
            ani.SetBool("isTrace", false);
            MoveWayPoint();

        }

    }


    void Patrol()
    {
        if (nav.remainingDistance < 2f)
        {
            if (nextIdx + 1 >= wayPoints.Count)
                nextIdx = 0;
            else
                nextIdx += 1;
        }
        nav.destination = wayPoints[nextIdx].position;
        ani.SetTrigger("Walk_forward");
    }

    void EndTrace()
    {
        isTrace = false;
        ani.SetBool("isTrace", false);

        float remainDis;
        float temp;
        int resultIdx = 0;

        for (int i = 0; i < wayPoints.Count - 1; i++)
        {
            remainDis = Vector3.Distance(transform.position, wayPoints[i].position);
            temp = Vector3.Distance(transform.position, wayPoints[i + 1].position);
            remainDis = (remainDis < temp) ? remainDis : temp;
            resultIdx = (remainDis < temp) ? i : i + 1;
        }
        nextIdx = resultIdx;
        MoveWayPoint();
    }

    void TraceTarget()
    {
        distance = Vector3.Distance(transform.position, target.position);
        ani.SetBool("isTrace", true);
        nav.destination = target.position;
        if (distance < 5f)
        {
            if (nav.remainingDistance < 1f)
            {
                Vector3 cen = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
                Debug.DrawRay(cen, transform.forward, Color.green, 2f);
                nav.isStopped = true;
                ani.SetBool("isAttack", true);
            }
            else if (nav.remainingDistance >= 1f && nav.remainingDistance < 5f)
            {
                nav.isStopped = false;
                ani.SetBool("isAttack", false);
            }
            else if (nav.remainingDistance >= 5f)
            {
                EndTrace();
                monsterSpeed = 2f;
            }
        }
        if (distance >= 5f)
        {
            EndTrace();
            monsterSpeed = 2f;
        }
    }
}
