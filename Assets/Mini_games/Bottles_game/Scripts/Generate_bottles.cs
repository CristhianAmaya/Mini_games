using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Generate_bottles : MonoBehaviour
{
    public GameObject Bottles_game; // Prefab para generar los objetos botella
    public GameObject Platforms_game; // Prefab para generar los objetos plataforma
    public Vector3 Initial_positions; // Se aginan las posiciones iniciales de los objetos
    [HideInInspector]
    public int Generate_number; // Numero de objetos a generar
    private Vector3[] positions_platforms; // Posiciones de las plataformas
    private Vector3[] positions_bottles; // Posiciones d elas botellas
    private Color[] Colors; // Lista de colores para asignar a los objetos
    private List<int> usedColors; // Lista para rastrear los colores utilizados
    private List<int> usedColors2; // Lista para rastrear los colores utilizados
    public Bottles_mechanics bottles_Mechanics;

    void Start()
    {
        Initialize_variable();
        Generate_platforms_bottles_stay();
        Generate_platforms_bottles_game();
    }

    public void Initialize_variable()
    {
        Generate_number = 5;
        positions_platforms = new Vector3[Generate_number];
        positions_bottles = new Vector3[Generate_number];
        positions_platforms[0] = new Vector3(Initial_positions.x, Initial_positions.y + Platforms_game.transform.localScale.y / 2, Initial_positions.z);
        positions_bottles[0] = new Vector3(Initial_positions.x, Initial_positions.y + Bottles_game.transform.localScale.y / 2.0f + 0.6f, Initial_positions.z);

        Colors = new Color[Generate_number];
        Colors[0] = Color.red;
        Colors[1] = Color.blue;
        Colors[2] = Color.green;
        Colors[3] = Color.yellow;
        Colors[4] = Color.black;

        usedColors = new List<int>(); // Inicializar la lista de colores usados
        usedColors2 = new List<int>();
    }

    public void Generate_platforms_bottles_stay()
    {
        for (int i = 0; i < Generate_number; i++)
        {
            if (i < Generate_number - 1)
            {
                positions_platforms[i + 1] = new Vector3(positions_platforms[i].x, positions_platforms[i].y, positions_platforms[i].z - 3.0f); // Asigna las posiciones de las plataformas restantes
                positions_bottles[i + 1] = new Vector3(positions_bottles[i].x, positions_bottles[i].y, positions_bottles[i].z - 3.0f); // Asigna las posiciones de las botellas restantes
            }

            GameObject newPlatform = Instantiate(Platforms_game, positions_platforms[i], Quaternion.identity); // Crea un objeto plataforma
            GameObject newBottle = Instantiate(Bottles_game, positions_bottles[i], Quaternion.identity); // Crea un objeto botella
            Renderer bottleRenderer = newBottle.GetComponent<Renderer>(); // Toma el renderer del objeto generado

            int random_color;

            // Seleccionar un color no utilizado
            do
            {
                random_color = Random.Range(0, Colors.Length); // Genera un valor aleatorio
            } while (usedColors.Contains(random_color)); // Compara si el valor random es igual a alguno de la lista

            bottleRenderer.material.color = Colors[random_color]; // Asigna el color random al material de la botella
            usedColors.Add(random_color); // Agregar el color utilizado a la lista

            newBottle.name = "Bottle_Stay_" + (i + 1); // Asigna un nuevo nombre al objeto
            newPlatform.name = "Platform_Stay_" + (i + 1); // Asigna un nuevo nombre al objeto
            bottles_Mechanics.Platforms_mec_stay.Add(newPlatform);
        }
    }

    public void Generate_platforms_bottles_game()
    {
        Vector3[] newpositions_platforms = new Vector3[Generate_number];
        Vector3[] newpositions_bottles = new Vector3[Generate_number];

        newpositions_platforms[0] = new Vector3(Initial_positions.x,
                Initial_positions.y + Platforms_game.transform.localScale.y / 2.0f + 5.0f,
                Initial_positions.z);
        newpositions_bottles[0] = new Vector3(Initial_positions.x,
                Initial_positions.y + Bottles_game.transform.localScale.y / 2.0f + Platforms_game.transform.localScale.y + 5.1f,
                Initial_positions.z);


        for (int i = 0; i < Generate_number; i++)
        {
            if (i < Generate_number - 1)
            {
                newpositions_platforms[i + 1] = new Vector3(newpositions_platforms[i].x, newpositions_platforms[i].y, newpositions_platforms[i].z - 3.0f); // Asigna las posiciones de las plataformas restantes
                newpositions_bottles[i + 1] = new Vector3(newpositions_bottles[i].x, newpositions_bottles[i].y, newpositions_bottles[i].z - 3.0f); // Asigna las posiciones de las botellas restantes
            }

            GameObject newPlatform = Instantiate(Platforms_game, newpositions_platforms[i], Quaternion.identity); // Crea un objeto plataforma
            GameObject newBottle = Instantiate(Bottles_game, newpositions_bottles[i], Quaternion.identity); // Crea un objeto botella
            Renderer bottleRenderer = newBottle.GetComponent<Renderer>(); // Toma el renderer del objeto generado

            int random_color;

            // Seleccionar un color no utilizado
            do
            {
                random_color = Random.Range(0, Colors.Length); // Genera un valor aleatorio
            } while (usedColors2.Contains(random_color)); // Compara si el valor random es igual a alguno de la lista

            bottleRenderer.material.color = Colors[random_color]; // Asigna el color random al material de la botella
            usedColors2.Add(random_color); // Agregar el color utilizado a la lista

            newBottle.name = "Bottle_Game_" + (i + 1); // Asigna un nuevo nombre al objeto
            newPlatform.name = "Platform_Game_" + (i + 1); // Asigna un nuevo nombre al objeto
            bottles_Mechanics.Platforms_mec_Game.Add(newPlatform);
        }
    }
}

