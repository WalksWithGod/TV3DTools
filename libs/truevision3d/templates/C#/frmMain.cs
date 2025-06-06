using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

// Add MTV3D65 to using clause:
using MTV3D65;

namespace Template
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmMain : System.Windows.Forms.Form
	{
		// Declare the TV Objects.
		public TVEngine TV;
		public TVScene Scene;
		public TVInputEngine Input;
		public TVGlobals Globals;
		public bool bDoLoop;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmMain()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// frmMain
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(632, 453);
			this.Name = "frmMain";
			this.Text = "TV3D SDK 6.5 Template";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frmMain_Closing);
			this.Load += new System.EventHandler(this.frmMain_Load);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmMain());
		}

		private void frmMain_Load(object sender, System.EventArgs e)
		{
			// Create the TV Interface first:
			TV = new TVEngine();

			// Set the debug file/options.
			// Do this before the 3D init so it can log any errors found during init.
			TV.SetDebugMode(true, true);
			TV.SetDebugFile(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\debugfile.txt");
  
			// Set your beta-key/license:
			// TV.SetLicenseKey(TV_LICENSE_COMMERCIAL, "username", "key");
			TV.SetBetaKey("", "");
			
			// After setting the beta-key/license its time to init the engine:
			TV.Init3DWindowed(this.Handle, true);

			// Something good to do is to enable the auto-resize feature:
			// Get the default viewport and set autoresize to true for it:
			TV.GetViewport().SetAutoResize(true);

			// Lets display the FPS:
			TV.DisplayFPS(true);

			// Set the prefered angle system:
			TV.SetAngleSystem(MTV3D65.CONST_TV_ANGLE.TV_ANGLE_DEGREE);

			// Now after we are done initializing the TVEngine component lets continue:
			// Create any other components after TV init.

			Scene = new TVScene();

			Globals = new TVGlobals();

			// Input has an additional init method to call.
			Input = new TVInputEngine();
			// Lets init both keyboard and mouse:
			Input.Initialize(true, true);

			// Now we have setup the most basic of components.
			// Something to think about, if the component has a diffrent construct method
			// then the Object = new TV<NAME>, use that one instead.

			// For example:
			// TVMesh Mesh;
			// Mesh = Scene.CreateMeshBuilder("MyMesh"); <- Instead of Mesh = TVMesh();
			// Same goes for RenderSurface, Viewport etc.

			bDoLoop = true;
			this.Show();
			this.Focus();

			// Lets setup the Loop:
			while(bDoLoop)
			{
				// Check if the application has focus, if yes thats when we process the loop.
				if(this.Focused)
				{				
					// The actual render loop:
					TV.Clear(false);
						// Render everything
						Scene.RenderAll(true);
					TV.RenderToScreen();

					// Lets check if the user presses ESC key, if yes we will quit the app.
					if(Input.IsKeyPressed(MTV3D65.CONST_TV_KEY.TV_KEY_ESCAPE)) { bDoLoop = false; };
				} else { 
					// So we arent calling DoEvents to many times if we arent using full CPU power.
					System.Threading.Thread.Sleep(100); 
				}
				
				Application.DoEvents();			
			}

			// Additional Info:
			/*
			Normally you dont have to keep track of the TV component and free it on closing.
			.NET will free the Managed Interface on close and thus automatically all the internal
			objects will be free'd. Such as Mesh's, Textures etc.

			Though it might be good to know you do have the ability to destroy and nil objects
			for re-creation or cleanup during runtime if you want that.

			TV = null;

			Will free all of the internal objects automatically.
			There are several other Destroy methods such as:

			TV<NAME>.Destroy , DestroyAll exists for some objects aswell if it is a Factory of some sort.

			Some other good destroy methods are:
			TVScene.DestroyAllMeshs.
			TVTextureFactory.DeleteAllTextures.

			And others...			
			*/

			TV = null;

			// End the application.
			this.Close();
		}

		private void frmMain_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			// If we close the application lets stop the loop.
			bDoLoop = false;
		}
	}
}
