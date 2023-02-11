

using Sandbox;

[GameResource( "exterior Definition", "exterior", "add all the models and sounds to create a new tardis.", Icon = "approval", IconBgColor = "#0c45a8", IconFgColor = "blue" )]
	public class exteriorDefinition : BaseDefinition
	{


	[Title( "Allow external Shell Usage" )]
	[Description( "Allow Exterior to be mixedmashed with interior/Use with chameleoncircuit" )]
	public bool AllowMixing
	{
		get;
		set;
	} = false;


	[Property, ResourceType( "vmdl" )]
		[Title( "Model with all Exterior Parts together" )]
		public string exterior_model_with_doors
		{
			get;
			set;
		}

	[Property, ResourceType( "vmdl" )]
	public string exterior_model
	{
		get;
		set;
	} = "models/drmatt/tardis/exterior/exterior.vmdl";

		[Property, ResourceType( "vmdl" )]
		public string exterior_doors
		{
			get;
			set;
		}
	}
