#pragma strict
var Rect : GUI;
function Start () 
{
}
function Update () {

}

function OnGUI() 
{
	if(GUI.Button(Rect(Screen.width /2 -71, Screen.height /2 +92.5, 145,48),""))
	{
		Application.Quit();
	}
	var pontos : String;
	pontos = PlayerPrefs.GetString("Pontos");
	var guiText = GameObject.Find("GUITextPontos").GetComponent(GUIText);
	guiText.text = pontos.ToString();
}