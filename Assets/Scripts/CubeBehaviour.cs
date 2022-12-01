using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehaviour : MonoBehaviour
{
    bool clicked = false;

    [SerializeField]
    public Material f_Material, t_Material;

    public void ClickOnCube()
    {
        if (clicked)
        {
            DoSmall();
        }
        else
        {
            DoBig();
        }
    }

    void DoBig()
    {
        gameObject.GetComponent<MeshRenderer>().material = t_Material;
        LeanTween.scale(gameObject, Vector3.one * 4f, 0.5f).setEaseInOutBack();
    }

    void DoSmall()
    {
        gameObject.GetComponent<MeshRenderer>().material = f_Material;
        LeanTween.scale(gameObject, Vector3.one, 0.5f).setEaseInOutBack();
    }


    /*
     //Esto es el problema, la escala no siempre va a ser 1. Si dejara de ser 1 ya no funcionaría.
                    //Aquí debería estar un booleano de condición. Y eso ya necesita otro script :(

                    if (size.x == 1)
                    {
                        clicked = false;
                        hitInfo.collider.GetComponent<MeshRenderer>().material = f_Material;
                    } else
                    {
                        clicked = true;
                        hitInfo.collider.GetComponent<MeshRenderer>().material = t_Material;
                    }

                    if (clicked == true)
                    {
                        LeanTween.scale(rigidbodyBox.gameObject, Vector3.one, 0.5f).setEaseInOutBack();
                        clicked = false;
                    } else
                    {
                        LeanTween.scale(rigidbodyBox.gameObject, Vector3.one * 4f, 0.5f).setEaseInOutBack();
                        clicked = true;
     */

}