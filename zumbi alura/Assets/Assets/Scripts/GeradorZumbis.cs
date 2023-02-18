using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorZumbis : MonoBehaviour
{
    public GameObject Zumbi;
    private float contatorTempo = 0;
    public float TempoGerarZumbi = 1;

    void Update()
    {
        contatorTempo += Time.deltaTime;

        if(contatorTempo >= TempoGerarZumbi)
        {
            Instantiate(Zumbi, transform.position, transform.rotation);
            contatorTempo = 0;
        }
    }
}
