/*
 * Created by SharpDevelop.
 * User: kvnxpc2
 * Date: 02/04/2021
 * Time: 04:04 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
	partial class wait_view
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(172, 64);
			this.label1.TabIndex = 0;
			this.label1.Text = "Loading..";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// wait_view
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(192, 84);
			this.Controls.Add(this.label1);
			this.Name = "wait_view";
			this.Text = "Running..";
			this.Load += new System.EventHandler(this.Wait_viewLoad);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label label1;
	}
