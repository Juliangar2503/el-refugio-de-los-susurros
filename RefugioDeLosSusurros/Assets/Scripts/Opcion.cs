using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opcion
{
    public string descripcion;  // El texto de la opci�n
    public Nodo nodoDestino;  // A qu� nodo lleva esta opci�n
    public bool esFinal;  // Si esta opci�n lleva a un final del juego

    public Opcion(string descripcion, Nodo nodoDestino, bool esFinal)
    {
        this.descripcion = descripcion;
        this.nodoDestino = nodoDestino;
        this.esFinal = esFinal;
    }
}

