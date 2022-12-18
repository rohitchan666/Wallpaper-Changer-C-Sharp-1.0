/*
 * Created by SharpDevelop.
 * User: 
 * Date: 30-Nov-22
 * Time: 4:02 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
 
 /*
	Wallpaper Changer App
	
	it teaches three concepts
	1. pinvoke to call native windows feature
	2. use of fileopen dialog
	3. use of picturebox 
 */
 
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace WallChange
{
	public partial class MainForm : Form
	{
	
	//Code for calling Windows functions, bcoz .NET doesnt have inbuilt function of changing wallpaper
	
	[DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool SystemParametersInfo(uint uiAction, uint uiParam, String pvParam, uint fWinIni);	
	private const uint SPI_SETDESKWALLPAPER = 0x14;
    private const uint SPIF_UPDATEINIFILE = 0x1;
    private const uint SPIF_SENDWININICHANGE = 0x2;
    
	public static void SetWallpaper(String strpath)
	{
	    SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, strpath, SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
	}


	/// <summary>
	/// Description of MainForm.
	/// </summary>

		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			openFileDialog1.Multiselect = false;
		    openFileDialog1.Filter = "Images (*.jpg)|*.jpg";
		    
		    if (openFileDialog1.ShowDialog() == DialogResult.OK)
		    {
			    textBox1.Text = openFileDialog1.FileName;
				pictureBox1.ImageLocation = textBox1.Text;
		    }
			else
			{
				//User cancelled file open
			}
		    
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			SetWallpaper(openFileDialog1.FileName);
		}
	}
}
