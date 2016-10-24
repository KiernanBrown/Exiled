using UnityEngine;
using System.Collections;

public class DialogueBox : MonoBehaviour 
{

	FileParser parser;

	public string dialogue;
	int lineNumber;
    string nm = "";
    string typingDialogue;
    int pose;

    public GUIStyle customStyle;
    public GUIStyle customStyleName;

    // Screen Dimensions
    /*float screenHeight;
    float screenWidth;*/


    // Use this for initialization
    void Start () 
	{
		dialogue = "";
		parser = GameObject.Find ("FileParserObj").GetComponent<FileParser> ();
        lineNumber = 0;
        //screenHeight = Camera.main.orthographicSize;
    }
	
	// Update is called once per frame
	void Update () 
	{
        // If the left mouse button or spacebar is pressed we advance the text
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            nm = parser.GetName(lineNumber);
            typingDialogue = parser.GetContent(lineNumber);
            dialogue = "";
            pose = parser.GetPose(lineNumber);
            ResetImages();
            DisplayImages();

            lineNumber++;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (nm != "")
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
    }

    // Sets the current sprite to null
    void ResetImages()
    {
        if(nm != "")
        {
            GameObject character = GameObject.Find(nm);
            SpriteRenderer currentSprite = character.GetComponent<SpriteRenderer>();
            currentSprite.sprite = null;
        }
    }

    void DisplayImages()
    {
        if(nm != "")
        {
            GameObject character = GameObject.Find(nm);
            Character cinfo = character.GetComponent<Character>();

            SpriteRenderer currentSprite = character.GetComponent<SpriteRenderer>();
            currentSprite.sprite = cinfo.poses[pose];
            character.transform.position = new Vector3(0, 0.4f);
            cinfo.facing = "Left";

            if(cinfo.facing == "Right")
            {
                character.transform.localScale = new Vector3(Mathf.Abs(character.transform.localScale.x), Mathf.Abs(character.transform.localScale.y));
            }

            if (cinfo.facing == "Left")
            {
                character.transform.localScale = new Vector3(-Mathf.Abs(character.transform.localScale.x), Mathf.Abs(character.transform.localScale.y));
            }
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
