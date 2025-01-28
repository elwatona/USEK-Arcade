using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Boton : MonoBehaviour
{
    public void Inicio()
    {
        SceneManager.LoadScene("GME1_level1");

    }
    public void Menu()
    {
        SceneManager.LoadScene("GME1_menu");
    }

}
