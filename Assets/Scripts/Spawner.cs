using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //Variables
    [SerializeField]
    public float timer = 0, timeMin, timeMax;

    public GameObject can;

    //Función que hace aparecer las latas
    public void Drop_Can()
    {
        Instantiate(can, gameObject.transform.position, Quaternion.identity);
    }

    public void Start()
    {
        InvokeRepeating("rop_Can", timeMin, Random.Range(timeMin, timeMax));
        timer = Random.Range(timeMin, timeMax);
    }

    /*public void Update()
    {
        //Timer aumenta con el tiempo
        timer += Time.deltaTime;
        //Cada 5sec
        if (timer % 5 == 0)
        {
            //Llama a la función Drop_Can
            Drop_Can();
        }
    }
    */

    /*
     * Variables de timeMin y Max, prefabTarget y timer
     * 
     * Start => InvokeRepating ("CreateTartget", timeMin, Random.Range(timeMin, timeMax);
     *          timer = Random.Range(timeMin, timeMax)
     * 
     * Update => timer -= Time.deltaTime
     *           if ()             FALTA INFO.
     * 
     * CreateTarget => Instatiate(prefabTarget, gameObject.transform.position, Quaternion.identity);
     */
}
