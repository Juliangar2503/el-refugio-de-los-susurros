using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Nodo : MonoBehaviour
{
    public string titleNodo;
    public string textoNodo;  // El texto que describe lo que sucede en el nodo
    public Sprite imgNodo;  // Nueva propiedad para la imagen del nodo
    public List<Opcion> opciones;  // Las acciones que el jugador puede tomar


    public Nodo(string title, string texto, Sprite img = null)
    {
        titleNodo = title;
        textoNodo = texto;
        imgNodo = img;
        opciones = new List<Opcion>();
    }

    // Método para agregar opciones al nodo
    public void AgregarOpcion(string descripcion, Nodo nodoDestino, bool esFinal = false)
    {
        Opcion nuevaOpcion = new Opcion(descripcion, nodoDestino, esFinal);
        opciones.Add(nuevaOpcion);
    }
}