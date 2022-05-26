using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progressor : MonoBehaviour
{
    public GameObject arrow;
    public PlayerBrickInterface pb;
    public LevelMaster LvlMaster;
    public int number;
    public bool loadable;
    public Transform level;
    // Start is called before the first frame update
    void Start()
    {
        level = transform.parent;
        loadable = false;
        pb = FindObjectOfType<PlayerBrickInterface>();
        arrow = transform.GetChild(0).gameObject;
        LvlMaster = FindObjectOfType<LevelMaster>();
    }

    public virtual void UpdateProgressor()
    {
        pb = FindObjectOfType<PlayerBrickInterface>();
        if (GameObject.FindWithTag("Enemy") == null && pb.holdingBrick)
        {
            arrow.SetActive(true);
            loadable = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(loadable)
        {
            arrow.SetActive(false);
            LvlMaster.load(number);
            Destroy(gameObject);
        }
        
    }

}
