using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMaster : MonoBehaviour
{
    private PlayerBrickInterface pb;
    public GameObject[] Levels;
    private int currentlvl;
    // Start is called before the first frame update
    void Start()
    {
        
        currentlvl = 1;
    }


    public void load(int lvl)
    {
        Debug.Log("passed" +lvl);
        
        int templvl = currentlvl;
        currentlvl = lvl;
        Levels[currentlvl - 1].SetActive(true);
        Levels[templvl - 1].SetActive(false);


        /*
         *  tmp =1
         *  current = 2
         *  set index 1 to active
         *  set index 0 to not active
         */
    }
}
