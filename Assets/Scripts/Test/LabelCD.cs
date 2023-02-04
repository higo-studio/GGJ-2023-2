using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabelCD : MonoBehaviour
{
    private TMPro.TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.SetActive(Game.instance.isComboCD);
        text.text = Game.instance.comboRemainCDTime.ToString("0.0");
    }

    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }
}
