using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPrueba : MonoBehaviour
{
    public float spd;
    public float rangeToChangeTarget;
    public Transform point1;
    public Transform point2;
    Vector3 currentTargetPosition;

    void Start()
    {
        currentTargetPosition = point1.position;
    }

    void Update()
    {
        if (IsOnPoint(point1.position))
        {
            currentTargetPosition = point2.position;
        }
        if (IsOnPoint(point2.position))
        {
            currentTargetPosition = point1.position;
        }

        MoveToTarget(currentTargetPosition);
    }

    void MoveToTarget(Vector3 target)
    {
        Vector3 dir = target - transform.position;
        dir.Normalize();
        transform.position += dir * spd * Time.deltaTime;
        transform.up = dir;

    }

    bool IsOnPoint(Vector3 targetPos)
    {
        return Vector3.Distance(transform.position, targetPos) < rangeToChangeTarget;
    }
}
