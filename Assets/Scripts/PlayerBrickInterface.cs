using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBrickInterface : MonoBehaviour
{
    public GameObject WorldBrick;
    public Transform BrickSpawn;
    public bool holdingBrick = true;
    public Rigidbody2D brickRB;
    public float forceAmt;
    private SpriteRenderer sr;
    public Sprite holdingBrickSprite;
    public Sprite defaultSprite;
    public Sprite launchingBrickSprite;
    public Sprite throwingBrickSprite;
    private Transform level;


    // Start is called before the first frame update
    void Start()
    {
        level = transform.parent;
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = holdingBrickSprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (holdingBrick)
        {
            if (Input.GetMouseButtonDown(0))
            {
                sr.sprite = launchingBrickSprite;
                //draw the trajectory
            }
            if (Input.GetMouseButtonUp(0))
            {
                //throw the brick
                GameObject thrown = Instantiate(WorldBrick, BrickSpawn.position, BrickSpawn.rotation);
                thrown.transform.SetParent(level);
                brickRB = thrown.GetComponent<Rigidbody2D>();
                //brb.velocity.Set(100, 100);

                
                brickRB.AddForce(new Vector2(BrickSpawn.position.x - transform.position.x, BrickSpawn.position.y-transform.position.y).normalized*forceAmt, ForceMode2D.Impulse);
                holdingBrick = false;
                sr.sprite = defaultSprite;
            }
        }
    }

    public void FoundMyBrick()
    {
        holdingBrick = true;
        sr.sprite = holdingBrickSprite;
        for (int i = 0; i < level.GetComponentsInChildren<Progressor>().Length; i++)
        {
            level.GetComponentsInChildren<Progressor>()[i].UpdateProgressor();
        }
    }
}
