using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public bool clicked = false;

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
                    /*Rigidbody rigidbodyBox = hitInfo.collider.GetComponent<Rigidbody>();

                    Vector3 size = rigidbodyBox.gameObject.transform.localScale;*/

                    CubeBehaviour cubeBehaviour = hitInfo.collider.GetComponent<CubeBehaviour>();
                    cubeBehaviour.ClickOnCube();
                }
            }
        }
    }
}

