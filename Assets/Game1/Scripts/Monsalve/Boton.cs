using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Boton : MonoBehaviour
{
    public void Inicio()
    {
        GameSceneManager.LoadScene("GME1_level1");

    }
    public void Menu()
    {
        GameSceneManager.LoadScene("GME1_menu");
    }

}
