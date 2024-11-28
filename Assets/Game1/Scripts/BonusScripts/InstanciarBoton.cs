using UnityEngine;
using UnityEngine.UI;  
using UnityEngine.SceneManagement;  

public class ActivarBotonCambioEscena : MonoBehaviour
{
    public Button boton;  
    public float tiempoDeEspera = 30f;  

    private void Start()
    {
        
        boton.gameObject.SetActive(false);

        
        Invoke("ActivarBoton", tiempoDeEspera);
    }

    void ActivarBoton()
    {
        
        boton.gameObject.SetActive(true);

        
        
    }

   
}
