using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_mechanic : MonoBehaviour
{
    public Generate_buttons instance_generate_Buttons; // Referencia al script que genera los botones
    private GameObject mirrorScreen; // Objeto de la pantalla que cambia de color
    private Renderer mirrorScreenRenderer;
    public int suma = 0;

    // Start is called before the first frame update
    void Start()
    {
        mirrorScreen = GameObject.Find("Pantalla");
        mirrorScreenRenderer = mirrorScreen.GetComponent<Renderer>(); // Obtén el Renderer de la pantalla
    }

    // Update is called once per frame
    void Update()
    {
        // Si no necesitas realizar operaciones por frame, puedes dejar este método vacío.
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hand_VR"))
        {
            Renderer renderer_button = gameObject.GetComponent<Renderer>(); // Renderer del botón que colisionó

            // Compara el color del botón con el color de la pantalla
            if (renderer_button.material.color == mirrorScreenRenderer.material.color)
            {
                suma++;
                mostrarsuma(); // Muestra la suma en la consola
            }
        }
    }

    public void mostrarsuma()
    {
        Debug.Log("La suma es: " + suma);
    }
}

