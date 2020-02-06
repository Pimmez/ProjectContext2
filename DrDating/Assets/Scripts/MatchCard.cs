using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MatchCard : ScriptableObject
{
	public Sprite matchCardIcon;
	public int matchCardID;
	public string matchCardName;
	public string dialogue;
}