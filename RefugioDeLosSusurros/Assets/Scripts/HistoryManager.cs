using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class HistoryManager : MonoBehaviour
{
    public TextMeshProUGUI historyTitle;  // Referencia al texto en la UI
    public TextMeshProUGUI historyText;  // Referencia al texto en la UI
    public GameObject optionsPanel;  // Panel donde se mostrar�n los botones de opciones
    public Button buttonPrefabs;  // Prefab del bot�n de opci�n
    public Image nodoImage;   // Referencia a la imagen del nodo en la UI

    // Referencia al primer nodo (Scriptable Object)
    public HistoriaData historiaData;
    private NodeData currentNode;

    void Start()
    {
        currentNode = historiaData.nodoInicial;
        ShowNode(currentNode);
    }

    // M�todo para mostrar el texto y las opciones del nodo actual
    public void ShowNode(NodeData node)
    {
        node.InvokeChangeHistory();

        historyTitle.text = node.title;
        historyText.text = node.history;

        if (node.imagen != null)
        {
            nodoImage.sprite = node.imagen;
            nodoImage.gameObject.SetActive(true);
        }
        else
        {
            nodoImage.gameObject.SetActive(false);
        }

        // Limpiamos las opciones anteriores
        foreach (Transform child in optionsPanel.transform)
        {
            Destroy(child.gameObject);
        }

        // Limpiar opciones anteriores
        foreach (Transform child in optionsPanel.transform)
        {
            Destroy(child.gameObject);
        }

        // Crear botones para cada opci�n
        foreach (var opcion in node.opciones)
        {
            Button nuevoBoton = Instantiate(buttonPrefabs, optionsPanel.transform);
            nuevoBoton.GetComponentInChildren<TextMeshProUGUI>().text = opcion.descripcion;
            nuevoBoton.onClick.AddListener(() => SelectOption(opcion));
        }
    }

    // M�todo cuando se selecciona una opci�n
    public void SelectOption(NodeData.Opcion opcion)
    {
        if (opcion.esFinal)
        {
            // Si es un nodo final, muestra el final del juego
            historyText.text = opcion.nodoDestino.history + "\n\nFin del juego.";
            optionsPanel.SetActive(false);
        }
        else
        {
            // Avanza al siguiente nodo
            currentNode = opcion.nodoDestino;
            ShowNode(currentNode);
        }
    }


}

