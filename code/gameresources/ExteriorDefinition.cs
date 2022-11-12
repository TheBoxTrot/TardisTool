

using Sandbox;

[GameResource( "exterior Definition", "exterior", "add all the models and sounds to create a new tardis.", Icon = "approval", IconBgColor = "#0c45a8", IconFgColor = "blue" )]
	public class exteriorDefinition : BaseDefinition
	{
	
		


		[Property, ResourceType( "vmdl" )]
		[Title( "Model with all Exterior Parts together" )]
		public string exterior_model_with_doors
		{
			get;
			set;
		}
		[DefaultValue( "models/drmatt/tardis/exterior/exterior.vmdl" )]
		[Property, ResourceType( "vmdl" )]
		public string exterior_model
		{
			get;
			set;
		}

		[Property, ResourceType( "vmdl" )]
		public string exterior_doors
		{
			get;
			set;
		}
	}
