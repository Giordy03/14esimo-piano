using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController1 : MonoBehaviour
{
    [SerializeField]
    private int thrust;

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        float randomDirection =  Random.Range(0,2)*2-1;
        rb.AddForce(new Vector2(7 * randomDirection, 7 * randomDirection) * thrust, ForceMode2D.Force);
    }

    public void ResetBall()
    {
        transform.position = Vector2.zero;
        rb.velocity = Vector2.zero;
        float randomDirection =  Random.Range(0,2)*2-1;
        rb.AddForce(new Vector2(7 * randomDirection, 7 * randomDirection) * thrust, ForceMode2D.Force);
    }
}
