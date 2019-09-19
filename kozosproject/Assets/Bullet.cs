using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;
    public float liftetime;
    
    public float liftetime2;
    






    // Start is called before the first frame update
    private void Start()
    {
        Invoke("DIS", liftetime2);
        Invoke("DestroyBullet",liftetime);
         rb.velocity = transform.right * speed;
       
    }

    // Update is called once per frame
    private void Update()
    {
       
    }
    void DestroyBullet()
    {
        
        gameObject.transform.localScale += new Vector3(40, 0, 0);
        rb.bodyType = RigidbodyType2D.Static;
        
    }
    void DIS ()
    {
        Destroy(gameObject);
        
    }
}
