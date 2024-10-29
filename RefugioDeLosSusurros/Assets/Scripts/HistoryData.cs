using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewHistory", menuName = "HistoryData")]
public class HistoriaData : ScriptableObject
{
    public NodeData nodoInicial;
    public List<NodeData> nodos = new List<NodeData>();
}
