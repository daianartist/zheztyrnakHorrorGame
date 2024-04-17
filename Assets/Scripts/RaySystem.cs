using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaySystem : MonoBehaviour
{
    public Transform raypoint;
    public float usingdistantion = 1.75f;
    RaycastHit hit;

    public Text info;

    public int rune = 0;
    public Text runetext;
    private AudioSource source;
    public AudioClip pickupclip;

    private void Start()
    {
        runetext.text = "0 / 5";
        source = GetComponent<AudioSource>();
    }



    void LateUpdate()
    {
        if (Physics.Raycast(raypoint.position, raypoint.forward, out hit, usingdistantion))
        {
            if (hit.collider.tag == "Untagged")
            {
                info.text = null;
            }

            if (hit.collider.tag == "door")
            {
                info.text = "door";

                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Door door = hit.collider.GetComponent<Door>();
                    door.Using();
                }

            }
            if (hit.collider.tag == "rune")
            {
                info.text = "рунаааа";
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    rune++;
                    runetext.text = rune + " / 5";
                    Destroy(hit.collider.gameObject);
                    source.Stop();
                    source.PlayOneShot(pickupclip);
                }
            }
        }
        else
        {
            info.text = null;
        }
    }

}
