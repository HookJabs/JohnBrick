using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBrick : MonoBehaviour
{

    public Rigidbody2D rb;
    public Transform tf;
    public CameraShaker camShaker;
    public GameObject bloodSpurt;
    public int combo = 0;
    public comboTrack ct;
    public Transform level;

    // Start is called before the first frame update
    void Start()
    {
        level = transform.parent;
        rb = GetComponent<Rigidbody2D>();
        tf = GetComponent<Transform>();
        camShaker = FindObjectOfType<CameraShaker>();
        ct = level.GetComponentInChildren<comboTrack>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //Quaternion rot = Quaternion.Euler(0,0, rb.velocity.magnitude * 1);
        //tf.rotation = rot;
        if (rb.velocity.magnitude > 0.1)
        {
            tf.Rotate(0, 0, rb.velocity.magnitude * 3);
        }
        else
        {
            tf.Rotate(0, 0, 1);
        }
        //rb.AddForce(new Vector2(11111, 1), ForceMode2D.Impulse);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            collision.collider.GetComponent<PlayerBrickInterface>().FoundMyBrick();
            Destroy(gameObject);
        }
        else if (collision.collider.tag == "Enemy" && rb.velocity.magnitude > 1.5f)
        {
            StartCoroutine(camShaker.Shake(.07f,.15f));
            Instantiate(bloodSpurt, transform.position, transform.rotation);
            collision.collider.GetComponent<EnemyBehavior>().Hit();
            combo++;
            ct.Updatecombo(combo);
        }
    }

   
}
