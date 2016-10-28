using UnityEngine;
using System.Collections;

public class Line
{
    public string type;

    // Information for a dialogue line
    public string nm;
    public string content;
    public int pose;

    // Information for an action statement
    public string action;
    public string moving;
    public string facing;

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(type == "Dialogue")
        {

        }

        if(type == "Menu")
        {

        }
	}

    public Line(string t)
    {
        type = t;
    }
}
