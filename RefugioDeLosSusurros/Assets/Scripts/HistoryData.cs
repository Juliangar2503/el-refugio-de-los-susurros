using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewHistory", menuName = "HistoryData")]
public class HistoriaData : ScriptableObject
{
    public Nodo nodoInicial;
    public List<Nodo> nodos = new List<Nodo>();
}
