using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ComboNodes : MonoBehaviour
{
    public GameObject NodesContainer;
    //public Transform InputNodesContainer;

    private List<QTENode> nodes;
    private List<QTENode> inputNodes;
    private int curComboIndex;

    private void Start()
    {
        nodes = new List<QTENode>(NodesContainer.GetComponentsInChildren<QTENode>());
        //inputNodes = new List<QTENode>(InputNodesContainer.GetComponentsInChildren<QTENode>());
        Hide();
    }

    public void Show(List<EmQTE> targets)
    { 
        for (int i = 1; i <= targets.Count; i++)
        {
            nodes[nodes.Count - i].SetData(targets[targets.Count - i]);
        }
        curComboIndex = nodes.Count - targets.Count;
    }

    public void Hide()
    {
        nodes.ForEach(node => node.Clear());
        //inputNodes.ForEach(node => node.Clear());
    }

    public void OnInputCombo(EmQTE qte)
    {
        nodes[curComboIndex++].Clear();        
    }
}
