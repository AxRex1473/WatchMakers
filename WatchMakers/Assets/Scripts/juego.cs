using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class juego : MonoBehaviour
{
    public Sprite[] Niveles;
    public GameObject MenuGanar;
    public GameObject PiezaSeleccionada;
    public int capa = 1;    
    public int PiezasEncajadas = 0;

    void Start()
    {
        // Se separan las piezas con las que vamos jugar
        for (int i = 0;i < 36; i++)
        {
            GameObject.Find("Pieza (" + i + ")").transform.Find("Puzzle").GetComponent<SpriteRenderer>().sprite = Niveles[PlayerPrefs.GetInt("Nivel")];
        }
    }

    // Seleccion de piezas con el mouse
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.transform.CompareTag("Puzzle"))
            {
                if (!hit.transform.GetComponent<pieza>().Encajada)
                {
                    PiezaSeleccionada = hit.transform.gameObject;
                    PiezaSeleccionada.GetComponent<pieza>().Seleccionada = true;
                    PiezaSeleccionada.GetComponent<SortingGroup>().sortingOrder = capa;
                    capa++;
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (PiezaSeleccionada != null)
            {
                PiezaSeleccionada.GetComponent<pieza>().Seleccionada = false;
                PiezaSeleccionada = null;
            }
        }
        if (PiezaSeleccionada != null)
        {
            Vector3 raton = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            PiezaSeleccionada.transform.position = new Vector3(raton.x,raton.y,0);
        }             
        if (PiezasEncajadas == 36)
        {
            MenuGanar.SetActive(true);
        }
    }

    // Se puede encontrar la pantalla de carga para seleccionar otro nivel 
    public void SiguienteNivel()
    {
        if(PlayerPrefs.GetInt("Nivel")<Niveles.Length-1)
        {
            PlayerPrefs.SetInt("Nivel", PlayerPrefs.GetInt("Nivel") + 1);
        }
        else
        {
            PlayerPrefs.SetInt("Nivel", 0);
        }
        SceneManager.LoadScene("Juego");
    }

    // Regresar al menu
    public void MenuPrincipal()
    {
        SceneManager.LoadScene("Menu");
    }
}