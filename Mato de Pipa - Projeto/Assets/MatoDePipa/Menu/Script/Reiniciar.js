#pragma strict

function Start () {

}

function Update () {

}
function OnGUI () 
{
	if(GUI.Button(Rect(Screen.width /2 -71, Screen.height /2 -100, 145,48),"")) {}
	if(GUI.Button(Rect(Screen.width /2 -71, Screen.height /2 +8.5, 145,48),""))
	{
		Application.LoadLevel("Menu");
	}
}