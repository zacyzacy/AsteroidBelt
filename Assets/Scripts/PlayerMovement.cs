using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1f;
    [SerializeField]
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") > 0.1f)
        {
            player.position += transform.forward * moveSpeed * Time.deltaTime;
        }
        else if (Input.GetAxis("Vertical") < -0.1f)
        {
            player.position -= transform.forward * moveSpeed * Time.deltaTime;
        }
        else if (Input.GetAxis("Horizontal") > 0.1f)
        {
            player.position += transform.right * moveSpeed * Time.deltaTime;
        }
        else if (Input.GetAxis("Horizontal") < -0.1f)
        {
            player.position -= transform.right * moveSpeed * Time.deltaTime;
        }
    }
}
