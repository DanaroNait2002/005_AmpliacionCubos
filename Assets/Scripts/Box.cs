using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public bool clicked = false;

    [SerializeField]
    public Material f_Material, t_Material;

    private void Update()
    {
        if ((Input.touchCount >= 1 && Input.GetTouch(0).phase == TouchPhase.Ended) || (Input.GetMouseButtonUp(0)))
        {
            Vector3 pos = Input.mousePosition;
            if (Application.platform == RuntimePlatform.Android)
            {
                pos = Input.GetTouch(0).position;
            }

            Ray rayo = Camera.main.ScreenPointToRay(pos);
            RaycastHit hitInfo;
            if (Physics.Raycast(rayo, out hitInfo) /*== true*/)
            {
                if (hitInfo.collider.tag.Equals("Box"))
                {
                    Rigidbody rigidbodyBox = hitInfo.collider.GetComponent<Rigidbody>();

                    Vector3 size = rigidbodyBox.gameObject.transform.localScale;

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
                    }
                }
            }
        }
    }
}

