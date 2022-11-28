
using Sandbox;
using System.Collections.Generic;
using static BaseDefinition.tardisparts;
using static BaseDefinition.tardisparts.conditionsstruct;
using static Sandbox.Package;

public partial class BaseDefinition : GameResource
{
	
	public bool HasChanged = false;
	protected override void PostReload()
	{
		HasChanged = true;
		
	}

	

	public SoundEvent Door_open_sound
	{
		get;
		set;
	}
	public SoundEvent Door_close_sound
	{
		get;
		set;
	}
	[DefaultValue( "0 0 0" )]
	public Vector3 main_PortalOffset
	{
		get;
		set;
	}

	[DefaultValue( "0 0 0" )]
	public Rotation main_Portalrotation
	{
		get;
		set;
	}
	public List<Bodygroup> mainbody
	{
		get;
		set;
	}
	public List<Bodygroup> maindoor
	{
		get;
		set;
	}
	public int Main_body_skin
	{
		get;
		set;
	}

	public int Main_door_skin
	{
		get;
		set;
	}
	[Description( "X is Depth, Y is Width , Z is Height" )]
	public Vector3 PortalExtends
	{
		get;
		set;
	}
	/// <summary>
	/// legacy needs removing
	/// </summary>
	public float main_portal_width
	{
		get;
		set;
	}
	/// <summary>
	/// legacy needs removing
	/// </summary>
	public float main_portal_depth
	{
		get;
		set;
	}
	/// <summary>
	/// legacy needs removing
	/// </summary>
	public float main_portal_height
	{
		get;
		set;
	}
	[DefaultValue( "1,1,1" )]
	public float main_door_scale
	{
		get;
		set;
	} = 1;

	public SoundFile Sound_on_pressed_main_door
	{
		get;
		set;
	}
	[DefaultValue( "0 0 0" )]
	public Vector3 Offset_main_door
	{
		get;
		set;
	}

	public Rotation Rotation_main_door
	{
		get;
		set;
	}
	public AttachTo Attach_main_door
	{
		get;
		set;
	}
	public enum AttachTo
	{
		BaseModel,
		OtherPart,
	}
	[HideIf( nameof( Attach_main_door ), AttachTo.BaseModel )]
	[Title( "Name of Part to Attach To" )]
	public string NameofParent
	{
		get;
		set;
	}

	[Title( "Use Bone or Attachment" )]
	public bool usebone_main_door
	{
		get;
		set;
	}
	[Title( "Name of the Bone or Attachment" )]
	[HideIf( nameof( usebone_main_door ), false )]
	public string bone
	{
		get;
		set;
	}




	[Title( "parts" )]
		public List<tardisparts> parts
		{
			get;
			set;
		}


	public enum Custompropetytype
	{
		Int,
		Float,
		Bool,
		String,
	}
	public struct CustomProperties
	{
		public string name
		{
			get;
			set;
		}
		public string value
		{
			get;
			set;
		}

		public Custompropetytype customproptype
		{
			get;
			set;
		}
	}
	public enum ActionType
	{
		dematerialize,
		materialize,
		fastreturn,
		hads,
		TriggerButtonAction,
		custom,
	}

	public struct Bodygroup
	{
		public int bodygroupnum
		{
			get;
			set;
		}
		public int bodygroupvalve
		{
			get;
			set;
		}
	}
	public struct ParticleControlPoints
	{
		public int Controlpointnum
		{
			get;
			set;
		}
		public Vector3 Controlpointval
		{
			get;
			set;
		}
	}

	public struct ToolTips
	{
		[Description( "The text that will be displayed in the tooltip (Leave blank to set to name)" )]
		public string displaytext
		{
			get;
			set;
		}
		public Vector3 offset
		{
			get;
			set;
		}

	}
		public struct tardisparts
		{
		///maybe need a way to have these selectable in editor if using a custom type. although keep what matt said in mind. 
		[ShowIf( nameof( Category ), partCategory.custom )]
		public bool needslight => Category == partCategory.Light;
		[ShowIf( nameof( Category ), partCategory.custom )]
		public bool Needsparticle => Category == partCategory.tparticle;
		[ShowIf( nameof( Category ), partCategory.custom )]
		public bool NeedsModel => Category == partCategory.BaseButton || Category == partCategory.basepart;
		[ShowIf( nameof( Category ), partCategory.custom )]
		[Title( "custom properties" )]
		public List<CustomProperties> customprop
		{
			get;
			set;
		}
	

		public string Name
		{
			get;
			set;
		}
		[ShowIf( nameof( NeedsModel ), true )]
		[Property, ResourceType( "vmdl" )]
		public string Model
		{
			get;
			set;
		}
		[ShowIf( nameof( Needsparticle ), true )]
		[Property, ResourceType( "vpcf" )]
		public string particle
		{
			get;
			set;
		}
		[ShowIf( nameof( Needsparticle ), true )]
		public List<ParticleControlPoints> particlecontrolpoint
		{
			get;
			set;
		}
		[ShowIf( nameof( needslight ), true )]
		public Color lightColour
		{
			get;
			set;
		}
		[ShowIf( nameof( needslight ), true )]
		public float LightRadius
		{
			get;
			set;
		}
		[ShowIf( nameof( needslight ), true )]
		public float Brightness
		{
			get;
			set;
		}
		[Title( "Light act like lamp" )]
		[Description("the light brightness will be tied to the phasing effect on the tardis and will be off when dematerlized")]
		[ShowIf( nameof( needslight ), true )]
		public bool LightasLamp
		{
			get;
			set;
		}
		[Title( "Essential Light" )]
		[Description( "wheather or not the light is essential to the tardis aka if the light stays on while the power is off" )]
		[ShowIf( nameof( needslight ), true )]
		public bool RequiredLight
		{
			get;
			set;
		}
		[ShowIf( nameof( NeedsModel ), true )]
		public List<Bodygroup> bodygroup
		{
			get;
			set;
		}
		[ShowIf( nameof( NeedsModel ), true )]
		public int skin
		{
			get;
			set;
		}
		
			[ShowIf( nameof( partCategory.BaseButton ), true )]
		public SoundEvent Sound_on_pressed
		{
			get;
			set;
		}
		[DefaultValue( "0 0 0" )]
		public Vector3 Offset
		{
			get;
			set;
		}

		public Rotation Rotation
		{
			get;
			set;
		}
		public AttachTo Attach
		{
			get;
			set;
		}
		public enum AttachTo
		{
			BaseModel,
			OtherPart,
		}
		[HideIf( nameof( Attach ), AttachTo.BaseModel )]
		[Title( "Name of Part to Attach To" )]
		public string NameofParent
		{
			get;
			set;
		}

		[Title( "Use Bone or Attachment" )]
		public bool usebone
		{
			get;
			set;
		}
		[Title( "Name of the Bone or Attachment" )]
		[HideIf( nameof( usebone ), false )]
		public string bone
		{
			get;
			set;
		}
		//
		// Summary:
		//     Width of the decal.

		[ShowIf( nameof( Category ), partCategory.BaseButton )]
		public ToolTips Tooltips
		{
			get;
			set;
		}
		[ShowIf( nameof( Category ), partCategory.BaseButton )]
		[Title( "Action" )]
		public List<actions> actions
		{
			get;
			set;
		}
		public partCategory Category
		{
			get;
			set;
		}
		public enum partCategory
		{
			basepart,
			BaseButton,
			WorldPortalDoor,
			Light,
			monitor,
			throttle,
			custom,
			tparticle,
			etc5
		}

		//
		// Summary:
		//     Rotation to apply when placing the decal.


		public enum conditionTypes
		{
			IF,
			IFNOT,
		}
		[Title( "conditions" )]
		public List<conditionsstruct> conditionlist
		{
			get;
			set;
		}

		//
		// Summary:
		//     Rotation to apply when placing the decal.





		public enum conditions
		{
			TardisIsDead,
			VR,
			TardisBelow20PercentHealth,
			hadsEnabled,
			custom,
		}
		public enum conditionsActions
		{
			activate,
			Lock,
			ChangeSkin,
			IgnoreUse,
		}
	
		public struct conditionsstruct
		{

			public conditionTypes conditionstypes
			{
				get;
				set;
			}
			public conditions conditions
			{
				get;
				set;
			}
			public conditionsActions conditionsActions
			{
				get;
				set;
			}






			public struct actions
			{
				public ActionType Actiontype
				{
					get;
					set;
				}
				[ShowIf( nameof( Actiontype ), ActionType.TriggerButtonAction )]
				public string ActionTarget
				{
					get;
					set;
				}
				[ShowIf( nameof( Actiontype ), ActionType.TriggerButtonAction )]
				public string ActionTargetAction
				{
					get;
					set;
				}
				[ShowIf( nameof( Actiontype ), ActionType.custom )]
				public string customname
				{
					get;
					set;
				}
			}
		
		}
	}







}

	

