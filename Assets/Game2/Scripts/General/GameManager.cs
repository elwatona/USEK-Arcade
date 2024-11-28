using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float timeLevel1, timeLevel2;
    float elapsedTime = 0f;
    bool level1Won, level2Won;

    void WinLevel1()
    {
        Debug.Log("Won level 1");
        level1Won = true;
        SceneManager.LoadScene("GME2_level2");
    }

    void WinLevel2()
    {
        Debug.Log("Won level 2");
        level2Won = true;
        SceneManager.LoadScene("GME2_boss");
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (!level1Won && elapsedTime >= timeLevel1)
        {
            WinLevel1();
        }
        else if (level1Won && !level2Won && elapsedTime >= timeLevel2)
        {
            WinLevel2();
        }
    }
}
