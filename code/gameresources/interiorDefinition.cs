

using Sandbox;

[GameResource( "interior Definition", "interior", "add all the models and sounds to create a new tardis.", Icon = "approval", IconBgColor = "#a80c8e", IconFgColor = "blue" )]
	public class interiorDefinition : BaseDefinition
{

		
		
		
		[Property, ResourceType( "sndscape" )]
		public string InteriorSoundScape
		{
			get;
			set;
		}

	

		[Property, ResourceType( "vmdl" )]
		public string interior_model
		{
			get;
			set;
		}


	[Property, ResourceType( "vmdl" )]
	public string main_door_model
	{
		get;
		set;
	}


}

