
using Sandbox;
using System.Collections.Generic;
using System.Linq;

namespace Tools;
internal class TardisEditor : BaseResourceEditor<exteriorDefinition>
{
	public TardisEditor()
	{
		Layout = Layout.Column();
	}

	protected override void Initialize( Asset asset, exteriorDefinition resource )
	{
		Layout.Clear( true );

		var properties = Layout.Add( new PropertySheet( this ) );
		properties.Target = resource;

		var expander = properties.CreateExpander( "Clothing Icon" );

		var ip = properties.AddRow( new IconProperty() );

		ip.Scene.InstallClothing( resource );
		ip.Clothing = resource;
		ip.ContentMargins = 16;
		expander.SetWidget( ip );
	}

	public static void RenderAllIcons()
	{
		using var progress = Progress.Start( "Rendering Icons" );
		var token = Progress.GetCancel();
		var allClothes = AssetSystem.All.Where( x => x.AssetType.FileExtension == "clothing" ).ToArray();

		int i = 0;
		foreach ( var asset in allClothes )
		{
			Progress.Update( asset.Name, ++i, allClothes.Length );

			var resource = asset.LoadResource<BaseDefinition>();
			RenderIcon( asset, resource );

			if ( token.IsCancellationRequested )
				return;
		}
	}

	private static void RenderIcon( Asset asset, BaseDefinition resource )
	{
		// force an icon path
		var iconInfo = resource.Icon;

		iconInfo.Path = $"/clothing_icons/{asset.Name}.png";
		resource.Icon = iconInfo;

		var Scene = new ClothingScene();
		Scene.UpdateLighting();
		Scene.InstallClothing( resource );
		Scene.UpdateCameraPosition();

		var pixelMap = new Pixmap( 256, 256 );
		Scene.Camera.RenderToPixmap( pixelMap );

		if ( asset.SaveToDisk( resource ) )
		{
			asset.Compile( false );
		}

		var root = asset.AbsolutePath[0..^(asset.RelativePath.Length)];
		pixelMap.SavePng( root + iconInfo.Path );
	}

	class IconProperty : Widget
	{
		public ClothingScene Scene;

		public BaseDefinition Clothing;

		Widget CanvasWidget;

		public IconProperty() : base( null )
		{
			Layout = Layout.Row();

			Scene = new ClothingScene();

			CanvasWidget = new Widget( this );
			CanvasWidget.FixedHeight = 256;
			CanvasWidget.FixedWidth = 256;

			Layout.Add( CanvasWidget );
			Layout.AddStretchCell();
		}

		public string IconPath { get; internal set; }

		protected override void OnPaint()
		{
			Scene.UpdateLighting();
			Scene.UpdateCameraPosition();
			Scene.Camera.RenderToWidget( CanvasWidget );

			Update();
		}

		protected override void OnMousePress( MouseEvent e )
		{
			base.OnMousePress( e );

			if ( e.RightMouseButton )
			{
				var allClothes = AssetSystem.All.Where( x => x.AssetType.FileExtension == "exterior" );

				var menu = new Menu( this );
				menu.AddOption( $"Render All Icons ({allClothes.Count():n0})", null, () => TardisEditor.RenderAllIcons() );

				menu.OpenAt( Application.CursorPosition );
			}
		}
	}

	public class ClothingScene
	{
		public SceneWorld World;
		public SceneCamera Camera;

		public SceneModel Body;

		public SceneModel TargetModel;

		List<SceneLight> Lights = new();

		public float Pitch = 15.0f;
		public float Yaw = 35.0f;
		public SlotMode Target = SlotMode.ModelBounds;

		public enum SlotMode
		{
			ModelBounds,
			Face
		}

		public ClothingScene()
		{
			World = new SceneWorld();
			Camera = new SceneCamera( "ClothingEditor" );

			Body = new SceneModel( World, "models/citizen/citizen.vmdl", Transform.Zero );
			Body.Rotation = Rotation.From( 0, 0, 0 );
			Body.Position = 0;
			Body.SetAnimParameter( "b_grounded", true );
			Body.SetAnimParameter( "aim_eyes", Vector3.Forward * 100.0f );
			Body.SetAnimParameter( "aim_head", Vector3.Forward * 100.0f );
			Body.SetAnimParameter( "aim_body", Vector3.Forward * 100.0f );
			Body.SetAnimParameter( "aim_body_weight", 1.0f );
			Body.Update( 1 );

			Camera.World = World;
			Camera.BackgroundColor = new Color( 0.1f, 0.1f, 0.1f, 0.0f );
			Camera.AmbientLightColor = Color.White * 0.1f;

			TargetModel = Body;
		}

		public void InstallClothing( BaseDefinition clothing )
		{
			var created = BaseDefinition.DressSceneObject( Body, new BaseDefinition[] { clothing } );
			TargetModel = created.FirstOrDefault();

			if ( TargetModel == null )
			{
				TargetModel = Body;
				Target = SlotMode.Face;
				return;
			}

			

			var greySkin = Material.Load( "models/citizen/skin/citizen_skin_grey.vmat" );

			Body.SetMaterialOverride( greySkin, "skin" );
			//Body.SetMaterialOverride( greySkin, "eyes" );
			//Body.SetMaterialOverride( greySkin, "eyeao" );

			TargetModel.SetMaterialOverride( greySkin, "skin" );
			//TargetModel.SetMaterialOverride( greySkin, "eyes" );

			TargetModel.Update( 1 );
		}

		public void UpdateLighting()
		{
			foreach ( var light in Lights )
			{
				light.Delete();
			}
			Lights.Clear();

			Lights.Add( new SceneLight( World, new Vector3( -100, -10, 20 ), 200, new Color( 0.8f, 1, 1 ) * 1.3f ) { ShadowTextureResolution = 512 } );
			Lights.Add( new SceneLight( World, new Vector3( -100, 150, 60 ), 400, new Color( 1, 0.9f, 0.6f ) * 16.0f ) { ShadowTextureResolution = 512 } );
			Lights.Add( new SceneLight( World, new Vector3( 200, 50, 500 ), 1200, new Color( 1, 0.9f, 0.85f ) * 20.0f ) { ShadowTextureResolution = 512 } );
		}

		public void UpdateCameraPosition()
		{
			if ( TargetModel == null )
				return;

			Camera.FieldOfView = 5;
			Camera.ZFar = 2000;
			Camera.ZNear = 10;

			var bounds = TargetModel.Bounds;

			if ( Target == SlotMode.ModelBounds )
			{
				bounds = TargetModel.Bounds;
			}
			else if ( Target == SlotMode.Face )
			{
				var headBone = TargetModel.GetBoneWorldTransform( "head" );
				headBone.Position += Vector3.Up * 6;
				bounds = new BBox( headBone.Position - 7, headBone.Position + 7 );
			}

			var lookAngle = new Angles( Pitch, 180 - Yaw, 0 );
			var forward = lookAngle.Forward;
			var distance = MathX.SphereCameraDistance( bounds.Size.Length * 0.5f, Camera.FieldOfView );

			Camera.Position = bounds.Center - forward * distance;
			Camera.Rotation = Rotation.From( lookAngle );
		}
	}
}
