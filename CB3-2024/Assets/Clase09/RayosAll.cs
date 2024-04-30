using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayosAll : MonoBehaviour
{
    [SerializeField] Material red;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //RayoChorizo();
        ExplotionLastCube();
    }

    void RayoChorizo()
    {
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.up, 100.0F);

        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            Renderer rend = hit.transform.GetComponent<Renderer>();

            if (rend)
            {
                // Change the material of all hit colliders
                rend.material = red;
            }
        }

    }

    void ExplotionLastCube()
    {
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.up, 100.0F);

        float auxDistance = 0;
        int auxindicador = 0;

        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            if(auxDistance < (hits[i].transform.position - transform.position).magnitude)
            {
                auxDistance = (hit.transform.position - transform.position).magnitude;
                auxindicador = i;
            }
        }
        Renderer rend = hits[auxindicador].transform.GetComponent<Renderer>();
        if (rend)
        {
            // Change the material of all hit colliders
            rend.material = red;
        }
    }
}
