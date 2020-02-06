using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
	[SerializeField] private Texture2D cursorTexture;
	[SerializeField] private CursorMode cursorMode = CursorMode.Auto;
	[SerializeField] private Vector2 hotSpot = Vector2.zero;

	private void OnMouseEnter()
	{
		Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
	}

	private void OnMouseExit()
	{
		Cursor.SetCursor(cursorTexture, Vector2.zero, cursorMode);
	}
}