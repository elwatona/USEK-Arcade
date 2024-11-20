using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float vidaJefe,vidaRestanteJefe;
    public bool fasesDelJefe = true;
    public GameObject primeraFase,segundaFase;
    // Start is called before the first frame update
    void Start()
    {
        vidaRestanteJefe = vidaJefe;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamge(float damage)
    {
        vidaRestanteJefe -= damage;
        if(vidaRestanteJefe <= 50 && fasesDelJefe == true)
        {
            primeraFase.SetActive(false);
            segundaFase.SetActive(true);
            fasesDelJefe = false;
        }
        else if(vidaRestanteJefe <= 0)
        {
            segundaFase.SetActive(false);
            GameSceneManager.NextLevel();
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamge(10);
        }
    }


}
