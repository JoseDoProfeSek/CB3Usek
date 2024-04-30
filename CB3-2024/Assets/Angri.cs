using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angri : MonoBehaviour
{
    Vector3 posInicial, posFinal, dir;
    Rigidbody rb;

    public float speed = 5;
    public float rootSpeed = 10;

    public Vector3[] arregloDire;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            posInicial = Input.mousePosition;
            Debug.Log(posInicial);
        }
        if (Input.GetMouseButtonUp(0))
        {
            posFinal = Input.mousePosition;
            Debug.Log(posFinal);
            dir = posFinal - posInicial;
            rb.isKinematic = false;
            rb.AddForce(-1* dir.normalized * dir.magnitude, ForceMode.Impulse);
        }
    }

    //private void Trayectoria()
    //{
    //    for (int i = 0; i < arregloDire.Length; i++)
    //    {
    //        arregloDire[i].transform.position = transform.position + (transform.up * speed) * i;
    //    }
    //}


}
