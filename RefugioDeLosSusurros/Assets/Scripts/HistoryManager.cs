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
    public GameObject optionsPanel;  // Panel donde se mostrarán los botones de opciones
    public Button buttonPrefabs;  // Prefab del botón de opción
    public Image nodoImage;   // Referencia a la imagen del nodo en la UI
    private Nodo currentNode;
    private bool tieneVidaExtra = false;

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
        Nodo nodo1 = new Nodo("La entrada", "Llegas a una mansión abandonada. La puerta está entreabierta.", Resources.Load<Sprite>("Images/1"));
        Nodo nodo2 = new Nodo("El vestíbulo oscuro", "Estás en el vestíbulo oscuro. Hay una escalera que sube.");
        Nodo nodo3 = new Nodo("El jardín lúgubre", "Rodeas la mansión y encuentras un jardín lúgubre.");
        Nodo nodo4 = new Nodo("El dormitorio prohibido", "Un dormitorio con un espejo roto que refleja una silueta extraña. Obtienes una vida que encuentras al entrar en la habitación ", Resources.Load<Sprite>("Images/4"));
        Nodo nodo5 = new Nodo("El sótano escondido", "Un sótano oscuro con un murmullo extraño que viene del fondo.", Resources.Load<Sprite>("Images/5"));
        Nodo nodo6 = new Nodo("La cabaña olvidada", "Dentro de la cabaña hay un altar con símbolos extraños y un libro polvoriento.", Resources.Load<Sprite>("Images/6"));
        Nodo nodo7 = new Nodo("El pozo maldito", "Al mirar dentro del pozo, ves una figura sombría en el fondo.", Resources.Load<Sprite>("Images/7"));
        Nodo nodo8 = new Nodo("El espejo de la muerte", "Te ves atrapado en una dimensión oscura y mueres.");
        Nodo nodo9 = new Nodo("La verdad oculta", "Encuentras un medallón con símbolos antiguos, que parece tener el poder de enfrentar la maldición.\r\n.");
        Nodo nodoFinalMalo = new Nodo("El fin oscuro", "Las sombras te devoran y mueres en la oscuridad de la mansión...", Resources.Load<Sprite>("Images/10"));
        Nodo nodoFinalBueno = new Nodo("La salvación", "Sobrevives y escapas de la mansión.", Resources.Load<Sprite>("Images/11"));

        // Nodo 1
        nodo1.AgregarOpcion("Entrar en la mansión", nodo2);
        nodo1.AgregarOpcion("Rodear la mansión", nodo3);

        // Nodo 2
        nodo2.AgregarOpcion("Subir las escaleras", nodo4);
        nodo2.AgregarOpcion("Abrir la puerta del fondo", nodo5);

        // Nodo 3
        nodo3.AgregarOpcion("Inspeccionar la cabaña", nodo6);
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
        nodo7.AgregarOpcion("Alejarse rápidamente", nodo5);

        // Nodo 9
        nodo9.AgregarOpcion("Ignorar el medallón", nodoFinalMalo, true); // Final malo
        nodo9.AgregarOpcion("Usar el medallón para romper la maldición", nodoFinalBueno, true); // Final bueno

        // Inicializamos el nodo actual en el inicio de la historia
        if (tieneVidaExtra)
        {
            nodo8 =  new Nodo("El espejo de la muerte", "Has usado tu vida extra para escapar del espejo maldito. Continúas hacia el siguiente desafío....");
            nodo8.AgregarOpcion("Alejarse rápidamente", nodo5);
            currentNode = nodo8;
        }
        else
        {
            currentNode = nodo1;
        }
        
    }

    // Método para mostrar el texto y las opciones del nodo actual
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

    // Método cuando se selecciona una opción
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

