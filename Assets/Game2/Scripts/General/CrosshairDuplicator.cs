using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairDuplicator : MonoBehaviour
{
    public GameObject crosshair;
    public Transform crosshairTransform;
    bool hasDuplicated = false;

    void Update()
    {
        if (Input.GetKey(KeyCode.X) && !hasDuplicated)
        {
            Instantiate(crosshair, crosshairTransform.position, crosshairTransform.rotation);
            hasDuplicated = true;
        }
    }
}
