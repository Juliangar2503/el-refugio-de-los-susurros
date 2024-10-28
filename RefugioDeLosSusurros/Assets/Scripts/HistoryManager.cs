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
    private Nodo currentNode;
    private bool tieneVidaExtra = false;

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
        Nodo nodo1 = new Nodo("La entrada", "Llegas a una mansi�n abandonada. La puerta est� entreabierta.", Resources.Load<Sprite>("Images/1"));
        Nodo nodo2 = new Nodo("El vest�bulo oscuro", "Est�s en el vest�bulo oscuro. Hay una escalera que sube.");
        Nodo nodo3 = new Nodo("El jard�n l�gubre", "Rodeas la mansi�n y encuentras un jard�n l�gubre.");
        Nodo nodo4 = new Nodo("El dormitorio prohibido", "Un dormitorio con un espejo roto que refleja una silueta extra�a. Obtienes una vida que encuentras al entrar en la habitaci�n ", Resources.Load<Sprite>("Images/4"));
        Nodo nodo5 = new Nodo("El s�tano escondido", "Un s�tano oscuro con un murmullo extra�o que viene del fondo.", Resources.Load<Sprite>("Images/5"));
        Nodo nodo6 = new Nodo("La caba�a olvidada", "Dentro de la caba�a hay un altar con s�mbolos extra�os y un libro polvoriento.", Resources.Load<Sprite>("Images/6"));
        Nodo nodo7 = new Nodo("El pozo maldito", "Al mirar dentro del pozo, ves una figura sombr�a en el fondo.", Resources.Load<Sprite>("Images/7"));
        Nodo nodo8 = new Nodo("El espejo de la muerte", "Te ves atrapado en una dimensi�n oscura y mueres.");
        Nodo nodo9 = new Nodo("La verdad oculta", "Encuentras un medall�n con s�mbolos antiguos, que parece tener el poder de enfrentar la maldici�n.\r\n.");
        Nodo nodoFinalMalo = new Nodo("El fin oscuro", "Las sombras te devoran y mueres en la oscuridad de la mansi�n...", Resources.Load<Sprite>("Images/10"));
        Nodo nodoFinalBueno = new Nodo("La salvaci�n", "Sobrevives y escapas de la mansi�n.", Resources.Load<Sprite>("Images/11"));

        // Nodo 1
        nodo1.AgregarOpcion("Entrar en la mansi�n", nodo2);
        nodo1.AgregarOpcion("Rodear la mansi�n", nodo3);

        // Nodo 2
        nodo2.AgregarOpcion("Subir las escaleras", nodo4);
        nodo2.AgregarOpcion("Abrir la puerta del fondo", nodo5);

        // Nodo 3
        nodo3.AgregarOpcion("Inspeccionar la caba�a", nodo6);
        nodo3.AgregarOpcion("Mirar dentro del pozo", nodo7);

        // Nodo 4
        nodo4.AgregarOpcion("Examinar el espejo", nodo8, true); // Final malo
        nodo4.AgregarOpcion("Buscar entre los cajones", nodo9);

        // Nodo 5
        nodo5.AgregarOpcion("Seguir el murmullo", nodoFinalMalo, true); // Final malo
        nodo5.AgregarOpcion("Buscar una salida alternativa", nodo9);

        // Nodo 6
        nodo6.AgregarOpcion("Abrir el libro", nodo8, true); // Final malo
        nodo6.AgregarOpcion("Registrar el altar", nodo9);

        // Nodo 7
        nodo7.AgregarOpcion("Descender al pozo", nodoFinalMalo, true); // Final malo
        nodo7.AgregarOpcion("Alejarse r�pidamente", nodo5);

        // Nodo 9
        nodo9.AgregarOpcion("Ignorar el medall�n", nodoFinalMalo, true); // Final malo
        nodo9.AgregarOpcion("Usar el medall�n para romper la maldici�n", nodoFinalBueno, true); // Final bueno

        // Inicializamos el nodo actual en el inicio de la historia
        if (tieneVidaExtra)
        {
            nodo8 =  new Nodo("El espejo de la muerte", "Has usado tu vida extra para escapar del espejo maldito. Contin�as hacia el siguiente desaf�o....");
            nodo8.AgregarOpcion("Alejarse r�pidamente", nodo5);
            currentNode = nodo8;
        }
        else
        {
            currentNode = nodo1;
        }
        
    }

    // M�todo para mostrar el texto y las opciones del nodo actual
    public void ShowNodo(Nodo nodo)
    {
        //Sprite imagenEntrada = Resources.Load<Sprite>("Images/1");
        historyTitle.text = nodo.titleNodo;
        historyText.text = nodo.textoNodo;

        // Activa la vida extra en el Nodo 4
        if (historyTitle.text == "El dormitorio prohibido")
        {
            tieneVidaExtra = true;
        }

        // Mostrar o esconder la imagen del nodo si existe o no
        if (nodo.imgNodo != null)
        {
            nodoImage.sprite = nodo.imgNodo;
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

            if (opcion.descripcion == "Examinar el espejo" && tieneVidaExtra)
            {
                StartHistory();
                // Usar la vida extra y redirigir al jugador
                tieneVidaExtra = false;
                ShowNodo(currentNode);
                return;
            }

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

