using System.Collections.Generic;

using System;
using static Sandbox.Package;

namespace Sandbox
{
	//
	// Summary:
	//     A piece of player model customization.
	[GameResource( "tardis Definition", "tardis", "add all the models and sounds to create a new tardis.", Icon = "approval", IconBgColor = "#fdea90", IconFgColor = "blue" )]
	public class tardisDefinition : GameResource
	{




		public Curve demat { get; set; }
		public Curve remat { get; set; }




		public SoundEvent Demat_sound
		{
			get;
			set;
		}
		public SoundEvent Mat_sound
		{
			get;
			set;
		}
		public SoundEvent flight_sound
		{
			get;
			set;
		}

		[Property, ResourceType( "png" )]
		public string displayImage
		{
			get;
			set;
		}

		[Property, ResourceType( "interior" )]
		public string interiordef
		{
			get;
			set;
		}

		[Property, ResourceType( "exterior" )]
		public string exteriordef
		{
			get;
			set;
		}







	}
}	

