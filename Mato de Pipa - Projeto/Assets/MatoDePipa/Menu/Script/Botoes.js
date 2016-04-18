#pragma strict
var sound: AudioClip;
function Start () {

}

function Update () {

}

function OnGUI () 
{
	if(GUI.Button(Rect(Screen.width /2 -36.5, Screen.height /2 +76.5, 115,45),""))
	{	
		//Enquanto tocando
		//while(AudioClip.
		//audio.PlayOneShot(sound, 0.7F);		
		//Terminou de tocar
		Application.LoadLevel("Jogo");
	}
}
