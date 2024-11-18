using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCommon : MonoBehaviour
{
    public int rutina;
    public float cronometro;
    public int dir;
    public float walkSpeed;
    public float runSpeed;
    public bool isAttacking;
    public GameObject target;

    //public float visionRange;
    //public float attackRange;
    //public GameObject range;
    //public GameObject hit;
    void Start()
    {
        target = GameObject.Find("player");
    }
    void Update()
    {
        Comportamientos();
    }
    public void Comportamientos()
    {
        cronometro += 1 * Time.deltaTime;
        if (cronometro >= 4)
        {
            rutina = Random.Range(0, 2);
            cronometro = 0;
        }

        switch (rutina)
        {
            case 0:
                dir = Random.Range(0, 2);
                rutina++;
                break;
            case 1:
                switch (dir)
                {
                    case 0:
                        transform.rotation = Quaternion.Euler(0, 0, 0);
                        transform.Translate(Vector3.left * walkSpeed * Time.deltaTime);
                        break;
                }
                break;
        }
        //if(Mathf.Abs(transform.position.x - target.transform.position.x) > visionRange && !isAttacking)
        //{
        //    cronometro += 1 * Time.deltaTime;
        //    if (cronometro >= 4)
        //    {
        //        rutina = Random.Range(0, 2);
        //        cronometro = 0;
        //    }

        //    switch (rutina)
        //    {
        //        case 0:
        //            dir = Random.Range(0, 2);
        //            rutina++;
        //            break;
        //        case 1:
        //            switch (dir)
        //            {
        //                case 0:
        //                    transform.rotation = Quaternion.Euler(0, 0, 0);
        //                    transform.Translate(Vector3.left * walkSpeed * Time.deltaTime);
        //                    break;
        //            }
        //            break;
        //    }
        //}
        //else
        //{
        //    if(Mathf.Abs(transform.position.x - target.transform.position.x) > attackRange && !isAttacking)
        //    {
        //        if(transform.position.x < target.transform.position.x)
        //        {
        //            transform.Translate(Vector3.left * runSpeed * Time.deltaTime);
        //            transform.rotation = Quaternion.Euler(0, 0, 0);
        //        }
        //        else
        //        {
        //            transform.Translate(Vector3.left * runSpeed * Time.deltaTime);
        //            transform.rotation = Quaternion.Euler(0, 180, 0);
        //        }
        //    }
        //    else
        //    {
        //        if(!isAttacking)
        //        {
        //            if(transform.position.x < target.transform.position.x)
        //            {
        //                transform.rotation = Quaternion.Euler(0, 0, 0);
        //            }
        //            else
        //            {
        //                transform.rotation = Quaternion.Euler(0, 180, 0);
        //            }
        //        }
        //    }
        //}
    }
}
