using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Character : MonoBehaviour {

	string characterName;
	Sprite characterSprite;
	public List<Sprite> poses = new List<Sprite>();
    public string position;
    public string movePosition;
    public string facing;
    public float moveSpeed = 0.20f; // Speed for moving, default is 2

	public Dictionary<string, Sprite> cposes = new Dictionary<string, Sprite>();

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
