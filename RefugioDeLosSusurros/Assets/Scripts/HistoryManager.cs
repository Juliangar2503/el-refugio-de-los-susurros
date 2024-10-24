using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HistoryManager : MonoBehaviour
{
    public TextMeshProUGUI historyText;  // Referencia al texto en la UI
    public GameObject optionsPanel;  // Panel donde se mostrar�n los botones de opciones
    public Button buttonPrefabs;  // Prefab del bot�n de opci�n

    private Nodo currentNode;

    void Start()
    {
        StartHistory();  // Inicializamos la historia al comienzo
        ShowNodo(currentNode);
    }

    // M�todo para crear un bot�n
    void CrearBoton(string textoBoton)
    {
        // Instanciamos el prefab del bot�n en el panel de opciones
        Button nuevoBoton = Instantiate(buttonPrefabs, optionsPanel.transform);

        // Cambiamos el texto del bot�n
        TextMeshProUGUI textoDelBoton = nuevoBoton.GetComponentInChildren<TextMeshProUGUI>();
        if (textoDelBoton != null)
        {
            textoDelBoton.text = textoBoton;
        }
    }

    void StartHistory()
    {
        // Crear los nodos de la historia
        Nodo nodo1 = new Nodo("Llegas a una mansi�n abandonada. La puerta est� entreabierta.");
        Nodo nodo2 = new Nodo("Est�s en el vest�bulo oscuro. Hay una escalera que sube.");
        Nodo nodo3 = new Nodo("Rodeas la mansi�n y encuentras un jard�n l�gubre.");
        Nodo nodoFinalMalo = new Nodo("Te pierdes en la oscuridad y mueres.");
        Nodo nodoFinalBueno = new Nodo("Sobrevives y escapas de la mansi�n.");

        // Crear las opciones para cada nodo
        nodo1.AgregarOpcion("Entrar en la mansi�n", nodo2);
        nodo1.AgregarOpcion("Rodear la mansi�n", nodo3);

        nodo2.AgregarOpcion("Subir las escaleras", nodoFinalMalo, true);
        nodo2.AgregarOpcion("Abrir la puerta del fondo", nodoFinalBueno, true);

        nodo3.AgregarOpcion("Seguir explorando", nodoFinalMalo, true);

        // Inicializamos el nodo actual en el inicio de la historia
        currentNode = nodo1;
    }

    // M�todo para mostrar el texto y las opciones del nodo actual
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

    // M�todo cuando se selecciona una opci�n
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

