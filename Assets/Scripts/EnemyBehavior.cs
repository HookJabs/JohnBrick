using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public int hp = 1;
    private int bloodchooser;
    public GameObject bs1;
    public GameObject bs2;
    public GameObject bs3;
    public GameObject dead;
    private GameObject thisOne;
    private GameObject player;
    private Transform level;
    Vector3 targetPos;
    Vector3 thisPos;
    float angle;
    public bool watcher;

    // Start is called before the first frame update
    void Start()
    {
        level = transform.parent;
        thisOne = GetComponent<GameObject>();
        player = GameObject.FindWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (watcher)
        {
            targetPos = player.transform.position;
            thisPos = transform.position;
            targetPos.x = targetPos.x - thisPos.x;
            targetPos.y = targetPos.y - thisPos.y;
            angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 270));
        }
        
    }

    public void Hit()
    {
        hp--;
        if(hp < 1)
        {
            bloodchooser = Random.Range(1, 4);
            float bloodSize = Random.Range(2f, 3f);
            switch(bloodchooser)
            {
                case 1:
                    GameObject bs = Instantiate(bs1, transform.position, transform.rotation);
                    bs.transform.localScale = new Vector3(bloodSize, bloodSize,1);
                    bs.transform.parent = level;
                    
                    break;
                case 2:
                    GameObject bsa = Instantiate(bs2, transform.position, transform.rotation);
                    bsa.transform.localScale = new Vector3(bloodSize, bloodSize, 1);
                    bsa.transform.parent = level;
                    break;
                case 3:
                    GameObject bsb = Instantiate(bs3, transform.position, transform.rotation);
                    bsb.transform.localScale = new Vector3(bloodSize, bloodSize, 1);
                    bsb.transform.parent = level;
                    break;
                default:
                    break;

            }
            for(int i = 0; i < level.GetComponentsInChildren<Progressor>().Length; i++)
            {
                level.GetComponentsInChildren<Progressor>()[i].UpdateProgressor();
            } 
            GameObject deadman = Instantiate(dead, transform.position, transform.rotation);
            deadman.transform.parent = level;
            Destroy(gameObject);
            
        }
    }
}
