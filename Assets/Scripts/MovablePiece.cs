using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovablePiece : MonoBehaviour {
	
	//Variables
	//Reference to piece script
	private Piece piece;
	private IEnumerator moveCoroutine;
	//public bool piecefalling = false;

	//Awake with no null ref
	void Awake(){
		piece = GetComponent<Piece> ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//move piece function
	public void Move(int newX, int newY, float time)
	{
		if (moveCoroutine != null) {
			StopCoroutine (moveCoroutine);
		}
		moveCoroutine = MoveCoroutine (newX, newY, time);
		StartCoroutine (moveCoroutine);
	}

	private IEnumerator MoveCoroutine(int newX, int newY, float time)
	{
		piece.X = newX;
		piece.Y = newY;
		Vector3 startPos = transform.position;
		Vector3 endPos = piece.GridRef.GetWorldPosition (newX, newY);

		for (float t = 0; t <= 1* time; t += Time.deltaTime){
			piece.transform.position = Vector3.Lerp (startPos, endPos, t / time);

			yield return 0;

		}
		piece.transform.position = endPos;
		//piecefalling = false;
	}
}

