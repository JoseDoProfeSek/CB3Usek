using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MRUA : MonoBehaviour
{
    // pos final = pos inicial + velocidad * t

    Vector3 v3Final;

    public Vector3 direccion;
    float speed = 2;

    [SerializeField] GameObject prefab;

    [SerializeField]Vector3[] arrayPos;
    [SerializeField] GameObject[] arrayGO;
    public float lengthPrefab = 10;
    public float forceSphereDistance = 0.2f;

    [SerializeField]LineRenderer ln;
    void Start()
    {
        ln.positionCount = (int)lengthPrefab;
        direccion = transform.up; // (0,1,0)
        arrayGO = new GameObject[0];

    }

    [SerializeField]Vector3 posInicialMouse;
    [SerializeField]Vector3 posFinalMouse;
    // Update is called once per frame
    void Update()
    {
        // MRU
        //v3Final = transform.position + (direccion * speed) * Time.deltaTime;
        //transform.position = v3Final;

        // transform.Rotate(Vector3.forward * -5 * Time.deltaTime) ;
        if (Input.GetMouseButtonDown(0))
        {
            posInicialMouse = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            posFinalMouse = Input.mousePosition;
            direccion = posInicialMouse - posFinalMouse;
            float mag = direccion.magnitude;
            forceSphereDistance = Mathf.Clamp(mag, 0, .5f);

        }
        if (Input.GetMouseButtonUp(0))
        {
            posFinalMouse = Input.mousePosition;
            direccion = posInicialMouse - posFinalMouse;
            float mag = direccion.magnitude;
            forceSphereDistance = Mathf.Clamp(mag, 0, .5f);

        }
            TrajectorySphere();

    }

    void TrajectorySphere()
    {
        arrayPos = new Vector3[(int)lengthPrefab];
        if (arrayGO.Length == 0)
        {
            arrayGO = new GameObject[(int)lengthPrefab];
            for (int i = 0; i < lengthPrefab; i++)
            {
                // MRU
                //v3Final = transform.position + (direccion * speed) * Time.deltaTime;
                arrayPos[i] = transform.position + (direccion.normalized * speed) * i * forceSphereDistance;
                arrayGO[i] = Instantiate(prefab, arrayPos[i], Quaternion.identity);
            }
        }
        else
        {
            for (int i = 0; i < lengthPrefab; i++)
            {
                arrayPos[i] = transform.position + (direccion.normalized * speed) * i * forceSphereDistance;
                arrayGO[i].transform.position = arrayPos[i];
            }
            ln.SetPositions(arrayPos);
        }
    }
}
