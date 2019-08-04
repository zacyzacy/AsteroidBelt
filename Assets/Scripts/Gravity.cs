using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;

    public float gravityForce = 1;
    public Transform gravitySource;

    [SerializeField]
    float transitionTime = 2, transitionSpeed = 2;

    private bool lerpRotation = false;
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

                if (lerpRotation)
                {
                    transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, Time.deltaTime * transitionTime);
                }
                else
                {
                    transform.rotation = toRotation;
                }
                rb.AddForce(-transform.up.normalized * gravityForce);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        gravitySource = other.transform;
        StartCoroutine(ChangePlanet());
    }

    private IEnumerator ChangePlanet()
    {
        while (true)
        {
            lerpRotation = true;
            yield return new WaitForSeconds(transitionTime);
            lerpRotation = false;
        }
    }
}