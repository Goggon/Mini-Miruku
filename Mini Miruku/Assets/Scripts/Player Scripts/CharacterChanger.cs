using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChanger : MonoBehaviour {

    public GameObject avatar1, avatar2, avatar3, avatar4;

    int currentavatar = 1;

    // Use this for initialization
    void Start () {
        avatar1.gameObject.SetActive(true);
        avatar2.gameObject.SetActive(false);
        avatar3.gameObject.SetActive(false);
        avatar4.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("1"))
        {
            avatar1.gameObject.SetActive(true);
            avatar2.gameObject.SetActive(false);
            avatar3.gameObject.SetActive(false);
            avatar4.gameObject.SetActive(false);
        }
        else if (Input.GetKeyDown("2"))
        {
            avatar1.gameObject.SetActive(false);
            avatar2.gameObject.SetActive(true);
            avatar3.gameObject.SetActive(false);
            avatar4.gameObject.SetActive(false);
        }
        else if (Input.GetKeyDown("3"))
        {
            avatar1.gameObject.SetActive(false);
            avatar2.gameObject.SetActive(false);
            avatar3.gameObject.SetActive(true);
            avatar4.gameObject.SetActive(false);
        }
        else if (Input.GetKeyDown("4"))
        {
            avatar1.gameObject.SetActive(false);
            avatar2.gameObject.SetActive(false);
            avatar3.gameObject.SetActive(false);
            avatar4.gameObject.SetActive(true);
        }
    }
}
