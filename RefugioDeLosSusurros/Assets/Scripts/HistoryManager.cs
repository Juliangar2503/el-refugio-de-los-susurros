using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HistoryManager : MonoBehaviour
{
    public TextMeshProUGUI historyText;  // Referencia al texto en la UI
    public GameObject optionsPanel;  // Panel donde se mostrarán los botones de opciones
    public Button buttonPrefabs;  // Prefab del botón de opción

    private Nodo currentNode;

    void Start()
    {
        StartHistory();  // Inicializamos la historia al comienzo
        ShowNodo(currentNode);
    }

    // Método para crear un botón
    void CrearBoton(string textoBoton)
    {
        // Instanciamos el prefab del botón en el panel de opciones
        Button nuevoBoton = Instantiate(buttonPrefabs, optionsPanel.transform);

        // Cambiamos el texto del botón
        TextMeshProUGUI textoDelBoton = nuevoBoton.GetComponentInChildren<TextMeshProUGUI>();
        if (textoDelBoton != null)
        {
            textoDelBoton.text = textoBoton;
        }
    }

    void StartHistory()
    {
        // Crear los nodos de la historia
        Nodo nodo1 = new Nodo("Llegas a una mansión abandonada. La puerta está entreabierta.");
        Nodo nodo2 = new Nodo("Estás en el vestíbulo oscuro. Hay una escalera que sube.");
        Nodo nodo3 = new Nodo("Rodeas la mansión y encuentras un jardín lúgubre.");
        Nodo nodoFinalMalo = new Nodo("Te pierdes en la oscuridad y mueres.");
        Nodo nodoFinalBueno = new Nodo("Sobrevives y escapas de la mansión.");

        // Crear las opciones para cada nodo
        nodo1.AgregarOpcion("Entrar en la mansión", nodo2);
        nodo1.AgregarOpcion("Rodear la mansión", nodo3);

        nodo2.AgregarOpcion("Subir las escaleras", nodoFinalMalo, true);
        nodo2.AgregarOpcion("Abrir la puerta del fondo", nodoFinalBueno, true);

        nodo3.AgregarOpcion("Seguir explorando", nodoFinalMalo, true);

        // Inicializamos el nodo actual en el inicio de la historia
        currentNode = nodo1;
    }

    // Método para mostrar el texto y las opciones del nodo actual
    public void ShowNodo(Nodo nodo)
    {
        historyText.text = nodo.textoNodo;

        // Limpiamos las opciones anteriores
        foreach (Transform child in optionsPanel.transform)
        {
            Destroy(child.gameObject);
        }

        // Asegurarse de que las opciones no sean null
        if (nodo.opciones == null || nodo.opciones.Count == 0)
        {
            Debug.LogError("El nodo no tiene opciones configuradas.");
            return;
        }

        // Creamos los botones de opciones
        foreach (Opcion opcion in nodo.opciones)
        {
            Button nuevoBoton = Instantiate(buttonPrefabs, optionsPanel.transform);
            nuevoBoton.GetComponentInChildren<TextMeshProUGUI>().text = opcion.descripcion;

            nuevoBoton.onClick.AddListener(() => GetOption(opcion));
        }
    }

    // Método cuando se selecciona una opción
    public void GetOption(Opcion opcion)
    {
        if (opcion.esFinal)
        {
            // Si es un nodo final, mostrar el final del juego
            historyText.text = opcion.nodoDestino.textoNodo + "\n\nFin del juego.";
            optionsPanel.SetActive(false);  // Ocultamos los botones de opciones
        }
        else
        {
            // Si no es un nodo final, pasamos al siguiente nodo
            currentNode = opcion.nodoDestino;
            ShowNodo(currentNode);
        }
    }


}

