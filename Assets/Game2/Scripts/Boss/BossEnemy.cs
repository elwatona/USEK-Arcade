using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BossEnemy : MonoBehaviour, IDamageable
{
    //public GameManager gm;
    public PlayerManager player;
    public Crosshair crosshair;

    public Canvas canvasJuego;
    public Image bossHealthBar;
    public TextMeshProUGUI textoBossFight;
    public string textoFinal;
    public Sprite[] bossState;
    public SpriteRenderer bossMode;

    public Transform bossEnemy;
    public BossEnemy boss;
    public Transform spawnEnemies;
    public Transform[] enemyGoToPos;
    //public int spawnIndex;
    public GameObject enemyToSpawn;
    public float lifeMax, life;
    public bool isProtected, isAttacking;
    public float timeShield, timeForShield;
    public float damage, bulletPow, bulletPowTarget;
    public float timeToAttack, timeToTarget;

    IEnumerator BossDeath()
    {
        float alpha = 1f; // Start with full opacity (1)
        bossMode.color = new Color(1, 1, 1, alpha); // Set initial color

        //Debug.Log("Boss muriendo epicamente");

        // Gradually decrease alpha over time
        while (alpha > 0)
        {
            alpha -= 1.5f * Time.deltaTime; // Decrease alpha
            alpha = Mathf.Clamp(alpha, 0, 1); // Ensure alpha stays within 0 to 1
            bossMode.color = new Color(1, 1, 1, alpha); // Update color
            yield return null; // Wait for the next frame
        }

        BossDie(); // Call the BossDie method
    }

    void HealthCheck()
    {
        if (life > lifeMax)
        {
            life = lifeMax;
        }
        else if (life <= 0)
        {
            StartCoroutine(BossDeath());
        }
    }

    void UpdateHealth()
    {
        bossHealthBar.fillAmount = life / lifeMax;
    }

    void HealPlayerUponSpawn()
    {
        player.currentHealth = player.health;
    }

    public void TakeDamage(float dmg)
    {
        if (dmg == 0)
        {
            return;
        }

        if (!isProtected)
        {
            life -= dmg;
            //Debug.Log("Boss life: " + life);
            timeToAttack -= Random.Range(3, 5);
            if (bulletPow - 0.25f > 0)
            {
                bulletPow -= 0.25f;
            }
        }
        else
        {
            Debug.Log("Enemigo esta protejido");
        }
        HealthCheck();
        UpdateHealth();
    }

    void BossDie()
    {
        this.gameObject.SetActive(!gameObject.activeSelf);
        textoFinal = "Victoria";

        canvasJuego.gameObject.SetActive(!gameObject.activeSelf);
        textoBossFight.text = textoFinal;
    }

    public void ActivateShield()
    {
        isProtected = true;
        bossMode.sprite = bossState[1];
    }

    public void DeactivateShield()
    {
        isProtected = false;
        bossMode.sprite = bossState[0];
    }

    void TimeToShield()
    {
        if (!isProtected)
        {
            timeShield += Time.deltaTime;
            if (timeShield >= timeForShield)
            {
                if (timeToAttack > timeToTarget * 0.5f)
                {
                    timeToAttack = timeToTarget * 0.5f;
                }
                timeShield = 0;
                bulletPow = 0;
                SpawnEnemy();
                timeForShield = Random.Range(8, 10);
            }
        }
    }

    void SpawnEnemy()
    {
        GameObject newEnemy = Instantiate(enemyToSpawn, spawnEnemies.position, transform.rotation);
        ShieldEnemy enemy = newEnemy.GetComponent<ShieldEnemy>();
        enemy.lifeMax = 4;
        enemy.distanceShield = 100;
        enemy.bigBoss = boss;
        enemy.protectTarget = bossEnemy;
        enemy.enemyGoTo = enemyGoToPos;
    }

    void Attack()
    {
        player.TakeDamage(damage);
        bossMode.sprite = bossState[0];
    }

    public void ChargeAttack()
    {
        if (!isProtected)
        {
            if (!isAttacking)
            {
                timeToAttack += Time.deltaTime;
            }

            if (timeToAttack >= timeToTarget)
            {
                timeToAttack = 0;
                isAttacking = true;
                timeToTarget = Random.Range(6, 8);
            }

            if (isAttacking)
            {
                bossMode.sprite = bossState[2];
                bulletPow += Time.deltaTime;
                
                if (bulletPow >= bulletPowTarget)
                {
                    Attack();
                    bulletPow = 0;
                    isAttacking = false;
                }
            }
            else
            {
                bossMode.sprite = bossState[0];
            }
        }

        if (timeToAttack < 0)
        {
            timeToAttack = 0;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        textoFinal = "";
        life = lifeMax;
        timeForShield = 5;
        timeToTarget = 10;
        damage = 2;

        HealPlayerUponSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.currentHealth > 0)
        {
            if (life > 0)
            {
                TimeToShield();
            }
            ChargeAttack();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(5);
        }
    }
}
