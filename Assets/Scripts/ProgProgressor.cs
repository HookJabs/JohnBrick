using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgProgressor : Progressor
{
    //void Start()
    //{
    //    level = transform.parent;
    //    loadable = false;
    //    pb = FindObjectOfType<PlayerBrickInterface>();
    //    arrow = transform.GetChild(0).gameObject;
    //    LvlMaster = FindObjectOfType<LevelMaster>();
    //}
    public override void UpdateProgressor()
    {
        
    }
    public void Update()
    {
        pb = FindObjectOfType<PlayerBrickInterface>();
        if (GameObject.FindGameObjectsWithTag("Progressor").Length <= 1 && pb.holdingBrick)
        {
            arrow.SetActive(true);
            loadable = true;
        }
    }
}
