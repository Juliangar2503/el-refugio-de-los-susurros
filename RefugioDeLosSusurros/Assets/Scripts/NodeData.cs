using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewNodeData", menuName = "NodeData")]

public class NodeData : ScriptableObject
{
    public string title;
    [field: TextArea(3, 10)] public string history;
    public Sprite imagen;

    [System.Serializable]
    public class Opcion
    {
        public string descripcion;
        public NodeData nodoDestino;
        public bool esFinal;
        public bool desactivar = false;
        // Delegado para realizar cambios específicos en el nodo
        public delegate void ChangeHistoryDelegate();
        public ChangeHistoryDelegate changeHistoryDelegate;

    }

    public List<Opcion> opciones = new List<Opcion>();

    

}
