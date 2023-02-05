using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabelComboTime : MonoBehaviour
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
        gameObject.SetActive(Game.instance.isComboing);
        text.text = Game.instance.comboRemainTime.ToString("0.0");
    }

    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }
}
