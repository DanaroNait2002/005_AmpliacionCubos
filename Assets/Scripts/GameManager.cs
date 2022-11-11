using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{
    public Material hitMaterial;
    public AudioClip shotSound;
    private AudioSource gunAudioSource;
    private AudioSource metalAudioSource;

    [SerializeField]
    TextMeshProUGUI score_Text;

    public int score;

    void Awake()
    {
        gunAudioSource = GetComponent<AudioSource>();
        metalAudioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {

        if ((Input.touchCount >= 1 && Input.GetTouch(0).phase == TouchPhase.Ended) || (Input.GetMouseButtonUp(0)))
        {
            gunAudioSource.PlayOneShot(shotSound);
            Vector3 pos = Input.mousePosition;
            if (Application.platform == RuntimePlatform.Android)
            {
                pos = Input.GetTouch(0).position;
            }

            Ray rayo = Camera.main.ScreenPointToRay(pos);
            RaycastHit hitInfo;
            if (Physics.Raycast(rayo, out hitInfo) /*== true*/)
            {
                if (hitInfo.collider.tag.Equals("Lata"))
                {
                    Rigidbody rigidbodyLata = hitInfo.collider.GetComponent<Rigidbody>();
                    rigidbodyLata.AddForce(rayo.direction * 50f, ForceMode.VelocityChange);
                    hitInfo.collider.GetComponent<MeshRenderer>().material = hitMaterial;

                    //Sumar 10 puntos
                    score += 10;
                    //metalAudioSource.PlayOneShot(metal);                   
                }
                else
                {
                    //Restar puntos
                    score -= 5;
                }

            }
            else
                score -= 5;
        }

        if (score <= 0)
        {
            score = 0;
        }

        //Display de puntos en el canvas
        score_Text.text = score.ToString();
         
        
    }
}
