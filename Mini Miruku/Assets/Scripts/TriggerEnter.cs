using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnter : MonoBehaviour {

    public UnityEngine.Events.UnityEvent OnEnter;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            OnEnter.Invoke();
        }
    }
}
