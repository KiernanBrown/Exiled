using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DialogueHandler : MonoBehaviour 
{

	FileParser parser;

	public string dialogue;
	int lineNumber;
    string nm = "";
    string typingDialogue;
    string lineType = "";
    string action = "";
    int pose;

    public GUIStyle customStyle;
    public GUIStyle customStyleName;

    GameObject character;
    Character cinfo;

    Camera camera;

    // Screen Dimensions
    /*float screenHeight;
    float screenWidth;*/

    //Positions
    Dictionary<string, float> positions = new Dictionary<string, float>();
    /*float right = 768.0f;
    float center = 512.0f;
    float left = 256.0f;*/


    // Use this for initialization
    void Start () 
	{
        positions.Add("Right", 768.0f);
        positions.Add("Center", 512.0f);
        positions.Add("Left", 256.0f);
		dialogue = "";
		parser = GameObject.Find ("FileParserObj").GetComponent<FileParser> ();
        lineNumber = 0;
        //screenHeight = Camera.main.orthographicSize;
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
	
	// Update is called once per frame
	void Update () 
	{
        // If the left mouse button or spacebar is pressed we advance the text
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || lineNumber == 0)
        {
            ClearLine();
            while (lineType != "Dialogue")
            {
                lineType = parser.GetLineType(lineNumber);

                if (lineType == "")
                {
                    break;
                }

                nm = parser.GetName(lineNumber);
                character = GameObject.Find(nm);
                cinfo = character.GetComponent<Character>();

                if (lineType == "Dialogue")
                {
                    typingDialogue = parser.GetContent(lineNumber);
                    dialogue = "";
                    pose = parser.GetPose(lineNumber);
                    Debug.Log("Dialogue Line.");
                }

                if (lineType == "Action")
                {
                    action = parser.GetAction(lineNumber);
                    if (action == "Face")
                    {
                        cinfo.facing = parser.GetFacing(lineNumber);
                        Debug.Log("Action: Face " + cinfo.facing);
                        lineNumber++;
                        continue;
                    }
                    if (action == "Move")
                    {
                        cinfo.movePosition = parser.GetMoving(lineNumber);
                        Debug.Log("We hit a move. We're moving " + cinfo.movePosition);
                        lineNumber++;
                        continue;
                    }
                }

                ResetImages();
                DisplayImages();
            }

            lineNumber++;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        // If the line has not finished typing, we continue to type it out
        if (lineType != "")
        {
            if (dialogue != typingDialogue)
            {
                dialogue += typingDialogue[dialogue.Length];
            }
            if (dialogue != typingDialogue)
            {
                dialogue += typingDialogue[dialogue.Length];
            }
        }

        // If the character is not yet in the position they are moving to, we move them
        if(cinfo.position != cinfo.movePosition && cinfo.movePosition != "")
        {
            float screenX = camera.WorldToScreenPoint(cinfo.transform.position).x;
            Vector3 pos;
            float endPosition = positions[cinfo.movePosition];
            if (screenX > endPosition)
            {
                pos = new Vector3(cinfo.transform.position.x - cinfo.moveSpeed, cinfo.transform.position.y);
                cinfo.transform.position = pos;
                screenX = camera.WorldToScreenPoint(cinfo.transform.position).x;
                if (screenX <= endPosition)
                {
                    cinfo.position = cinfo.movePosition;
                    float newX = camera.ScreenToWorldPoint(new Vector3(endPosition, 0)).x;
                    cinfo.transform.position = new Vector3(newX, cinfo.transform.position.y);
                    cinfo.movePosition = "";
                }
            }
            else if (screenX < endPosition)
            {
                pos = new Vector3(cinfo.transform.position.x + cinfo.moveSpeed, cinfo.transform.position.y);
                cinfo.transform.position = pos;
                screenX = camera.WorldToScreenPoint(cinfo.transform.position).x;
                if (screenX >= endPosition)
                {
                    cinfo.position = cinfo.movePosition;
                    float newX = camera.ScreenToWorldPoint(new Vector3(endPosition, 0)).x;
                    cinfo.transform.position = new Vector3(newX, cinfo.transform.position.y);
                    cinfo.movePosition = "";
                }
            }

            // Old Movement code
            /*switch (cinfo.movePosition)
            {
                case "Right":
                    if (screenX > right)
                    {
                        pos = new Vector3(cinfo.transform.position.x - cinfo.moveSpeed, cinfo.transform.position.y);
                        cinfo.transform.position = pos;
                        screenX = camera.WorldToScreenPoint(cinfo.transform.position).x;
                        if (screenX <= right)
                        {
                            cinfo.position = "Right";
                            cinfo.transform.position = new Vector3(right, cinfo.transform.position.y);
                            cinfo.movePosition = "";
                        }
                    }
                    else if (screenX < right)
                    {
                        pos = new Vector3(cinfo.transform.position.x + cinfo.moveSpeed, cinfo.transform.position.y);
                        cinfo.transform.position = pos;
                        screenX = camera.WorldToScreenPoint(cinfo.transform.position).x;
                        Debug.Log("Position: " + screenX);
                        if (screenX >= right)
                        {
                            cinfo.position = "Right";
                            float newX = camera.ScreenToWorldPoint(new Vector3(right, 0)).x;
                            cinfo.transform.position = new Vector3(newX, cinfo.transform.position.y);
                            cinfo.movePosition = "";
                        }
                    }
                    break;
                case "Left":
                    if (screenX > left)
                    {
                        pos = new Vector3(cinfo.transform.position.x - cinfo.moveSpeed, cinfo.transform.position.y);
                        cinfo.transform.position = pos;
                        screenX = camera.WorldToScreenPoint(cinfo.transform.position).x;
                        if (screenX <= left)
                        {
                            cinfo.position = "Left";
                            cinfo.transform.position = new Vector3(left, cinfo.transform.position.y);
                            cinfo.movePosition = "";
                        }
                    }
                    else if (screenX < left)
                    {
                        pos = new Vector3(cinfo.transform.position.x + cinfo.moveSpeed, cinfo.transform.position.y);
                        cinfo.transform.position = pos;
                        screenX = camera.WorldToScreenPoint(cinfo.transform.position).x;
                        Debug.Log("Position: " + screenX);
                        if (screenX >= left)
                        {
                            cinfo.position = "Left";
                            float newX = camera.ScreenToWorldPoint(new Vector3(left, 0)).x;
                            cinfo.transform.position = new Vector3(newX, cinfo.transform.position.y);
                            cinfo.movePosition = "";
                        }
                    }
                    break;
            }*/
        }
    }

    void ClearLine()
    {
        lineType = "";
        nm = "";
        dialogue = "";
        typingDialogue = "";
        action = "";
    }

    // Sets the current sprite to null
    void ResetImages()
    {
        character = GameObject.Find(nm);
        SpriteRenderer currentSprite = character.GetComponent<SpriteRenderer>();
        currentSprite.sprite = null;
    }

    void DisplayImages()
    {
        SpriteRenderer currentSprite = character.GetComponent<SpriteRenderer>();
        currentSprite.sprite = cinfo.poses[pose];

        if (cinfo.facing == "Right")
        {
            character.transform.localScale = new Vector3(-Mathf.Abs(character.transform.localScale.x), Mathf.Abs(character.transform.localScale.y));
        }

        if (cinfo.facing == "Left")
        {
            character.transform.localScale = new Vector3(Mathf.Abs(character.transform.localScale.x), Mathf.Abs(character.transform.localScale.y));
        }
    }

    // Method that sets the position of the sprite, maybe throw away.
    /*void SetSpritePosition(GameObject spriteObj)
    {
        if(position == "Left")
        {

        }

        if(position == "Right")
        {

        }
    }*/

    // We write the name of the character that is speaking and what they are saying here
    void OnGUI()
    {
        GUI.Label(new Rect(0, 550, 600, 50), nm, customStyleName);
        GUI.Label(new Rect(0, 580, 944, 180), dialogue, customStyle);
    }
}
