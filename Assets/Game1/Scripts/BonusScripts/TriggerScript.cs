using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TriggerScript : MonoBehaviour
{
    private int score = 0;
    private BonusManager bM;
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        bM = GetComponent<BonusManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
            Debug.Log(other.name);
        if (other.gameObject.CompareTag("Player"))
        {
           score++;
            scoreText.text = " " + score.ToString();
            
        }
       
    }
   
}
