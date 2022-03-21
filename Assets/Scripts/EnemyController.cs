using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private int posTimer = 120;
    private int temp = 1;
    public float CrabSpeed;
    private Rigidbody2D Crab;
    // Start is called before the first frame update
    void Start()
    {
    Crab = GetComponent<Rigidbody2D>();      
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(posTimer==120)
            {
            temp = 1;
            }
        if(posTimer==0)
            {
            temp = 2;
            }
        if(temp==1)
            {
            posTimer -= 1;          
        Crab.AddForce(new Vector2(CrabSpeed, 0));
            }
        if(temp==2)
        {
            posTimer += 1;          
            Crab.AddForce(new Vector2(-CrabSpeed, 0));
        }
    }
}
