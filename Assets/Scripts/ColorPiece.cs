using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPiece : MonoBehaviour {


	//Variables
	//Enum the number of possible colors
	public enum ColorType
	{
		YELLOW,
		PURPLE,
		RED,
		BLUE,
		GREEN,
		PINK,
		ANY,
		COUNT,
	};

	//Array to assign a sprite to each color
	[System.Serializable]
	public struct ColorSprite
	{
		public ColorType color;
		public Sprite sprite;
	};

	public ColorSprite[] colorSprites;

	//reference to the sprite
	private ColorType color;
	public ColorType Color {
		get { return color; }
		set { SetColor(value); }
	}

	public int NumColors {
		get { return colorSprites.Length; }
	}

	//to store the spriterenderer
	private SpriteRenderer sprite;


	//Convert to dictionnary for easier access
	private Dictionary<ColorType, Sprite> colorSpriteDict;

	void Awake()
	{
		//reference to spriterenderer
		sprite = transform.Find("piece").GetComponent<SpriteRenderer>();

		//Instantiate dictionnary
		colorSpriteDict = new Dictionary<ColorType, Sprite>();
		//Loop through array to fill dictionnary
		for (int i = 0; i < colorSprites.Length; i++) {
			//Check if already has key
			if (!colorSpriteDict.ContainsKey (colorSprites [i].color)) {
				//else add the key
				colorSpriteDict.Add (colorSprites [i].color, colorSprites [i].sprite);
			}
		}
	}




	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetColor(ColorType newColor)
	{
		color = newColor;
		if (colorSpriteDict.ContainsKey (newColor)) {
			sprite.sprite = colorSpriteDict [newColor];
		}
	}
}


