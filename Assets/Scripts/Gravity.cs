using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;

    public float gravityForce = 1;
    public Transform gravitySource;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gravitySource != null)
        {
            RaycastHit hit;
            Ray ray = new Ray(transform.position, gravitySource.position - transform.position);
            if (Physics.Raycast(ray, out hit))
            {
                Debug.DrawRay(gravitySource.position, transform.position, Color.red);
                Vector3 gravityNormal = Vector3.Normalize(hit.normal);
                Debug.DrawRay(hit.point, gravityNormal, Color.green);
                Quaternion toRotation = Quaternion.FromToRotation(transform.up, gravityNormal) * transform.rotation;
                transform.rotation = toRotation;
                rb.AddForce(-transform.up.normalized * gravityForce);
            }
        }
    }
}