using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuHandler : MonoBehaviour
{

    public List<string> choices;

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    void OnGUI()
    {
        for(int i = 0; i < choices.Count; i++)
        {
            GUI.Button(new Rect(0, 50 + 100 * i, 0, 0), choices[i]);
        }
    }
}
