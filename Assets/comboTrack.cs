using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class comboTrack : MonoBehaviour
{
    private Text gt;
    int combo;
    // Start is called before the first frame update
    void Start()
    {
        gt = GetComponent<Text>();
        combo = 0;

        gt.text = "COMBO: " + combo;
    }

    // Update is called once per frame
    public void Updatecombo(int newcom)
    {
        Debug.Log("comb");
        combo = newcom;
        gt.text = "COMBO: " + combo;
    }
}
