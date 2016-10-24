using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Character : MonoBehaviour {

	string characterName;
	Sprite characterSprite;
	public List<Sprite> poses = new List<Sprite>();
    public string position;
    public string facing;

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
