using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearLinePiece : ClearablePiece {

	public bool isRow;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void Clear()
	{
		base.Clear ();

		if (isRow) {
			//Clear row
			piece.GridRef.ClearRow (piece.Y);
		} else {
			//clear column
			piece.GridRef.ClearColumn (piece.X);
		}
	}
}
