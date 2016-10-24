using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class FileParser : MonoBehaviour 
{

    // TODO: Change how images are handled.

	List<DialogueLine> lines;

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
		lines = new List<DialogueLine>();
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
            return lines[lineNumber].name;
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

                    }

                    // This is a Dialogue Statement
                    if (line_values.Length == 3)
                    {
                        DialogueLine dLine = new DialogueLine(line_values[0], line_values[1], int.Parse(line_values[2]));
                        lines.Add(dLine);
                    }
                }
            }
            while (line != null);
            reader.Close();
        }
	}
}
