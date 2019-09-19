using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonc : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;
    public float liftetime;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyBullet", liftetime);
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void DestroyBullet()
    {

        Destroy(gameObject);

    }
}
