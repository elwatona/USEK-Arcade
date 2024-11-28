using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BonusCollect : MonoBehaviour
{
    public Image[] images;
    public GameObject prefabBattery;
    public int index = -1;
    private void OnEnable()
    {
        Movement.OnBatteryCollision += BatteryCollision;
    }
    private void OnDisable()
    {
        Movement.OnBatteryCollision -= BatteryCollision;
    }
    private void BatteryCollision(Collider2D collision)
    {
        index++;
        BatteryFill(index);
        Destroy(collision.gameObject);
        if (index >= 9)
        {
            GameSceneManager.NextLevel();
        }
    }
    void BatteryFill(int _index)
    {
        for (int i = 0; i < images.Length; i++)
        {
            images[i].color = Color.grey;
        }
        for (int j = 0; j <= _index; j++)
        {
            images[j].color = Color.white;
        }
    }

}
