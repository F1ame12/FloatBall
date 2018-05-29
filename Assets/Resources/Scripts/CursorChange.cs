using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorChange : MonoBehaviour {

    public Texture2D cursor;
	// Use this for initialization
	void Start () {
       Cursor.SetCursor(cursor, new Vector2(24f ,24f), CursorMode.Auto);
    }

}
