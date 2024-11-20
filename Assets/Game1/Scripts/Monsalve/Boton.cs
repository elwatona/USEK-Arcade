using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boton : MonoBehaviour
{
    public void Cambio()
    {
        SceneManager.LoadScene("GME1_level1");
    }
}
