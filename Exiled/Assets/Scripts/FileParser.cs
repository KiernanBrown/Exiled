using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class FileParser : MonoBehaviour 
{

    // TODO: Change how images are handled.

	//List<DialogueLine> lines;
    List<Line> lines;

	struct DialogueLine
    {
		public string name;
		public string content;
		public int pose;

		public DialogueLine(string n, string c, int p)
		{
			name = n;
			content = c;
			pose = p;
		}
	}

	// Use this for initialization
	void Start () 
	{
		lines = new List<Line>();
		LoadDialogue ("TestScene.txt");
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

    public string GetName(int lineNumber)
    {
        if(lineNumber < lines.Count)
        {
            return lines[lineNumber].nm;
        }
        return "";
    }

    public string GetContent(int lineNumber)
    {
        if (lineNumber < lines.Count)
        {
            return lines[lineNumber].content;
        }
        return "";
    }

    public int GetPose(int lineNumber)
    {
        if (lineNumber < lines.Count)
        {
            return lines[lineNumber].pose;
        }
        return 0;
    }

    public string GetLineType(int lineNumber)
    {
        if(lineNumber < lines.Count)
        {
            return lines[lineNumber].type;
        }
       return "";
    }

    public string GetAction(int lineNumber)
    {
        if (lineNumber < lines.Count)
        {
            return lines[lineNumber].action;
        }
        return "";
    }

    public string GetMoving(int lineNumber)
    {
        if (lineNumber < lines.Count)
        {
            return lines[lineNumber].moving;
        }
        return "";
    }

    public string GetFacing(int lineNumber)
    {
        if (lineNumber < lines.Count)
        {
            return lines[lineNumber].facing;
        }
        return "";
    }

    void LoadDialogue(string filename)
	{
		string file = "Assets/Dialogues/" + filename;
		string line;
		StreamReader reader = new StreamReader (file);

        using (reader)
        {
            do
            {
                line = reader.ReadLine();
                if (line != null)
                {
                    // Split the line based on the '|' character
                    string[] line_values = line.Split('|');

                    // This is a menu creation statement
                    if(line_values.Length == 1)
                    {
                    }

                    // This is an Action Statement
                    if (line_values.Length == 2)
                    {
                        Line nLine = new Line("Action");
                        nLine.nm = line_values[0];
                        switch (line_values[1])
                        {
                            case "Move Right": nLine.action = "Move";
                                nLine.moving = "Right";
                                break;
                            case "Move Left": nLine.action = "Move";
                                nLine.moving = "Left";
                                break;
                            case "Face Right": nLine.action = "Face";
                                nLine.facing = "Right";
                                break;
                            case "Face Left": nLine.action = "Face";
                                nLine.facing = "Left";
                                break;
                        }
                        lines.Add(nLine);
                    }

                    // This is a Dialogue Statement
                    if (line_values.Length == 3)
                    {
                        //DialogueLine dLine = new DialogueLine(line_values[0], line_values[1], int.Parse(line_values[2]));
                        //lines.Add(dLine);

                        Line nLine = new Line("Dialogue");
                        nLine.nm = line_values[0];
                        nLine.content = line_values[1];
                        nLine.pose = int.Parse(line_values[2]);
                        lines.Add(nLine);
                    }
                }
            }
            while (line != null);
            reader.Close();
        }
	}
}
