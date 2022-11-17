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
		public Curve Damageddemat { get; set; }
		public Curve Damagedremat { get; set; }
		[Category("Sounds")]
		public SoundEvent fullPhaseSound
		{
			get;
			set;
		}
		[Category( "Sounds" )]
		public SoundEvent Demat_sound
		{
			get;
			set;
		}
		[Category( "Sounds" )]
		public SoundEvent Mat_sound
		{
			get;
			set;
		}
		[Category( "Sounds" )]
		public SoundEvent flight_sound
		{
			get;
			set;
		}
		[Category( "Sounds" )]
		public SoundEvent fullPhaseSound_damaged
		{
			get;
			set;
		}
		[Category( "Sounds" )]
		public SoundEvent Demat_sound_damaged
		{
			get;
			set;
		}
		[Category( "Sounds" )]
		public SoundEvent Mat_sound_damaged
		{
			get;
			set;
		}
		[Category( "Sounds" )]
		public SoundEvent Demat_sound_fail
		{
			get;
			set;
		}
		[Category( "Sounds" )]
		public SoundEvent Mat_sound_fail
		{
			get;
			set;
		}
		[Category( "Sounds" )]
		public SoundEvent flight_sound_damaged
		{
			get;
			set;
		}
		[Category( "Sounds" )]
		public SoundEvent cricalhealthsound
		{
			get;
			set;
		}
		[Category( "Sounds" )]
		public SoundEvent door_locked
		{
			get;
			set;
		}
		[Category( "Sounds" )]
		public SoundEvent on_lock
		{
			get;
			set;
		}
		[Category( "Sounds" )]
		public SoundEvent on_lockint
		{
			get;
			set;
		}
		[Category( "Sounds" )]
		public SoundEvent phase_on
		{
			get;
			set;
		}
		[Category( "Sounds" )]
		public SoundEvent phase_off
		{
			get;
			set;
		}
		[Category( "Sounds" )]
		public SoundEvent power_on
		{
			get;
			set;
		}
		[Category( "Sounds" )]
		public SoundEvent power_off
		{
			get;
			set;
		}
		[Category( "Sounds" )]
		public SoundEvent repairfinish
		{
			get;
			set;
		}
		[Category( "Sounds" )]
		public SoundEvent seq_bad
		{
			get;
			set;
		}
		[Category( "Sounds" )]
		public SoundEvent seq_ok
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

