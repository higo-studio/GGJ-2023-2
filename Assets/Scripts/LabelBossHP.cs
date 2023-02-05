using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabelBossHP : MonoBehaviour
{
    private TMPro.TextMeshProUGUI text;
    // Start is called before the first frame update
    void Awake()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();
    }

    public void UpdateHP(int hp)
    {
        text.text = hp.ToString();
    }
}
