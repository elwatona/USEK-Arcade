using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float lifeBoss,currentLifeBoss;
    public bool bossPhase = true;
    public GameObject bossPhase1,bossPhase2;
    // Start is called before the first frame update
    void Start()
    {
        currentLifeBoss = lifeBoss;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamge(float damage)
    {
        currentLifeBoss -= damage;
        if(currentLifeBoss <= 50 && bossPhase == true)
        {
            bossPhase1.SetActive(false);
            bossPhase2.SetActive(true);
            bossPhase = false;
        }
        else if(currentLifeBoss <= 0)
        {
            bossPhase2.SetActive(false);
            GameSceneManager.NextLevel();
        }

    }
    
   
}
