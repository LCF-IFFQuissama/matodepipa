#pragma strict

var tempoPassado : int = 30;
var iniciaFuncao : boolean = false;
var ativar: boolean = false;
var estilo : GUIStyle;

function Start ()
{
	ativar = true;
	tempoPassado = 30;
	iniciaFuncao = true;
	PlayerPrefs.SetString("Pontos","Pontos:0");
}


function Update ()
{
	if(tempoPassado <=0)
	{	
		Application.LoadLevel("GameOver");
	}	
	if(iniciaFuncao)
	{
		iniciaFuncao = false;
		AtivaTimer();
	}
		
	var guiText = GameObject.Find("GUI Text").GetComponent(GUIText);
	var pontos : String;
	pontos = PlayerPrefs.GetString("Pontos");
	if(guiText.text != pontos)
	{
		pontos = pontos.Replace("Pontos:",'');
		if(int.Parse(pontos) <= 20)
		{
			tempoPassado = tempoPassado +3;
		}
		else if(int.Parse(pontos) <= 40)
		{
			tempoPassado = tempoPassado +2;
		}
		else if(int.Parse(pontos) <= 80)
		{
			tempoPassado = tempoPassado +1;
		}
		
	}	//aumenta o tempo ao apagar o fogo
	if(tempoPassado >= 60)
	{		
		tempoPassado = 60;
	}
	PlayerPrefs.SetString("Pontos",guiText.text);
}

function AtivaTimer ()
{
	while(ativar)
	{
		tempoPassado = tempoPassado -1;
		yield WaitForSeconds(1);
	}
}

function OnGUI()
{ 
	if(tempoPassado >=11)
	{
		estilo.normal.textColor = Color.black;
	} 
	else
	{
		estilo.normal.textColor = Color.red;
	}
	estilo.padding.top = 30;
	estilo.padding.left = 30;
	GUILayout.Label(tempoPassado.ToString(),estilo);
}