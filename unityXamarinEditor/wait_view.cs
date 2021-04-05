/*
 * Created by SharpDevelop.
 * User: kvnxpc2
 * Date: 02/04/2021
 * Time: 04:04 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;


	/// <summary>
	/// Description of wait_view.
	/// </summary>
	public partial class wait_view : Form
	{
		public wait_view()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			Timer tim = new Timer();
			tim.Interval = 3000;
			tim.Tick += delegate { this.Dispose(true);};
			tim.Start();
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void Wait_viewLoad(object sender, EventArgs e)
		{
			
		}
	}

