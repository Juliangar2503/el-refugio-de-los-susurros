using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opcion
{
    public string descripcion;  // El texto de la opción
    public Nodo nodoDestino;  // A qué nodo lleva esta opción
    public bool esFinal;  // Si esta opción lleva a un final del juego

    public Opcion(string descripcion, Nodo nodoDestino, bool esFinal)
    {
        this.descripcion = descripcion;
        this.nodoDestino = nodoDestino;
        this.esFinal = esFinal;
    }
}

