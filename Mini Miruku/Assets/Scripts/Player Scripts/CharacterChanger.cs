using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChanger : MonoBehaviour {

    public GameObject avatar1, avatar2;

    int currentavatar = 1;

    // Use this for initialization
    void Start () {
        avatar1.gameObject.SetActive(true);
        avatar2.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.G))
        {
            switch (currentavatar)
            {
                case 1:
                    currentavatar = 2;
                    avatar1.gameObject.SetActive(false);
                    avatar2.gameObject.SetActive(true);
                    break;

                case 2:
                    currentavatar = 1;
                    avatar1.gameObject.SetActive(true);
                    avatar2.gameObject.SetActive(false);
                    break;

            }
        }
    }
}
