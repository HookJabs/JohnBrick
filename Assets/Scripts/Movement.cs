using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float speed;

    private Rigidbody2D rb;
    private Vector2 moveVel;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveIn = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVel = moveIn.normalized * speed;
    }

    private void FixedUpdate()
    {
        //GetComponent<Rigidbody2D>().velocity.Set(100, 100);
        rb.MovePosition(rb.position + moveVel * Time.fixedDeltaTime);
        LookAtMouse();
    }

    private void LookAtMouse()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector2 dir = new Vector2(
            mousePos.x - transform.position.x,
            mousePos.y - transform.position.y
            );

        transform.up = dir;
    }
}
