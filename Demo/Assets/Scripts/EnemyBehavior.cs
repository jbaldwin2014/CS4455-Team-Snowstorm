using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float speed = 0;
    public GameObject player;
    private Vector3 offset;
    private Rigidbody rb;
    private Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        offset = transform.position - player.transform.position;
        float movementX = offset.x < 0 ? 1 : movementX = -1;
        float movementZ = offset.z < 0 ? 1 : movementZ = -1;
        float movementY = offset.y < 0 ? 1 : movementY = -1;

        Vector3 movement = new Vector3(movementX, movementY, movementZ);
        rb.AddForce(movement * speed);
    }

    private void resetEnemy()
    {
        transform.position = initialPosition;
        rb.velocity = Vector3.zero;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            resetEnemy();
        }
        //else if (other.gameObject.CompareTag("Wall"))
        //{
        //    rb.velocity = Vector3.zero;
        //}

    }
}
