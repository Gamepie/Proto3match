using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour {

	//Variables
	//Piece position
	private int x;
	private int y;

	//Public proprety of piece position
	public int X 
	{
		get { return x; }
		set {
			if (IsMovable ()) {
				x = value;
			}
		}
	}
	public int Y
	{
		get { return y; }
		set {
			if (IsMovable ()) {
				y = value;
			}
		}
	}

	//Piece type
	private Grid.PieceType type;
	//Public proprety of piece type
	public Grid.PieceType Type
	{
		get { return type; }
	}

	//Reference of grid
	private Grid grid;
	//Public property of grid
	public Grid GridRef
	{
		get { return grid; }
	}

	//Reference to movable piece script
	private MovablePiece movableComponent;
	public MovablePiece MovableComponent {
		get { return movableComponent; }
	}

	private ColorPiece colorComponent;
	public ColorPiece ColorComponent {
		get { return colorComponent; }
	}

	private ClearablePiece clearableComponent;

	public ClearablePiece ClearableComponent {
		get { return clearableComponent; }
	}

	//Awake for null
	void Awake()
	{
		movableComponent = GetComponent<MovablePiece> ();
		colorComponent = GetComponent<ColorPiece> ();
		clearableComponent = GetComponent<ClearablePiece> ();
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//Initialisation function for the variables
	public void Init(int _x, int _y, Grid _grid, Grid.PieceType _type)
	{
		x = _x;
		y = _y;
		grid = _grid;
		type = _type;

	}

	//Clicks
	void OnMouseEnter()
	{
		grid.EnterPiece (this);
	}

	void OnMouseDown ()
	{
		grid.PressPiece (this);
	}

	void OnMouseUp ()
	{
		grid.ReleasePiece ();
	}

	//Check if piece is movable
	public bool IsMovable()
	{
		return movableComponent != null;
	}

	public bool IsColored ()
	{
		return colorComponent != null;
	}

	public bool IsClearable ()
	{
		return clearableComponent != null;
	}
}
