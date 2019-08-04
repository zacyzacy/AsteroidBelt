using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchRocket : MonoBehaviour
{
    [SerializeField]
    float powah = 100, ropeTime = 0.5f;
    [SerializeField]
    Rigidbody rb, player;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            startLaunch();
        }

    }

    void startLaunch()
    {
        StartCoroutine(launch());

    }

    private IEnumerator launch()
    {
        rb.AddForce(transform.up * powah, ForceMode.Impulse);
        yield return new WaitForSeconds(ropeTime);
        player.velocity = rb.velocity;
    }

    private void OnTriggerEnter(Collider other)
    {
        rb.velocity = Vector3.zero;
    }
}
