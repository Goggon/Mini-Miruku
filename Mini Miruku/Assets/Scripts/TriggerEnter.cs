using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnter : MonoBehaviour {

    public UnityEngine.Events.UnityEvent OnEnter;
    public UnityEngine.Events.UnityEvent OnExit;

    public bool hasseen;


    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player" && !hasseen)
        {
            OnEnter.Invoke();
            hasseen = true;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            OnExit.Invoke();
        }
    }
}
