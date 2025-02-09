using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace WindowsFormsSample
{
	/// <summary>
	/// Summary description for frmSampleGrid1.
	/// </summary>
	[Sample("SourceGrid - Extensions", 27, "Array binding")]
	public class frmSample27 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cbArrayType;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btLoad;
		private System.Windows.Forms.TextBox txtCols;
		private System.Windows.Forms.TextBox txtRows;
		private SourceGrid.ArrayGrid arrayGrid;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmSample27()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			new SourceGrid.ArrayGrid();
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
            this.label3 = new System.Windows.Forms.Label();
            this.cbArrayType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btLoad = new System.Windows.Forms.Button();
            this.txtCols = new System.Windows.Forms.TextBox();
            this.txtRows = new System.Windows.Forms.TextBox();
            this.arrayGrid = new SourceGrid.ArrayGrid();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(10, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 19);
            this.label3.TabIndex = 24;
            this.label3.Text = "ArrayType:";
            // 
            // cbArrayType
            // 
            this.cbArrayType.Location = new System.Drawing.Point(149, 5);
            this.cbArrayType.Name = "cbArrayType";
            this.cbArrayType.Size = new System.Drawing.Size(173, 24);
            this.cbArrayType.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(10, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 27);
            this.label2.TabIndex = 22;
            this.label2.Text = "Rows:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(158, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 27);
            this.label1.TabIndex = 21;
            this.label1.Text = "Columns:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btLoad
            // 
            this.btLoad.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btLoad.Location = new System.Drawing.Point(418, 32);
            this.btLoad.Name = "btLoad";
            this.btLoad.Size = new System.Drawing.Size(90, 27);
            this.btLoad.TabIndex = 20;
            this.btLoad.Text = "Load";
            this.btLoad.Click += new System.EventHandler(this.btLoad_Click);
            // 
            // txtCols
            // 
            this.txtCols.Location = new System.Drawing.Point(230, 32);
            this.txtCols.Name = "txtCols";
            this.txtCols.Size = new System.Drawing.Size(87, 22);
            this.txtCols.TabIndex = 19;
            this.txtCols.Text = "1000";
            // 
            // txtRows
            // 
            this.txtRows.Location = new System.Drawing.Point(67, 32);
            this.txtRows.Name = "txtRows";
            this.txtRows.Size = new System.Drawing.Size(87, 22);
            this.txtRows.TabIndex = 18;
            this.txtRows.Text = "1000";
            // 
            // arrayGrid
            // 
            this.arrayGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.arrayGrid.DragOffset = 0;
            this.arrayGrid.EnableSmoothScrolling = false;
            this.arrayGrid.EnableSort = true;
            this.arrayGrid.HScrollBarVisible = false;
            this.arrayGrid.IsCustomAreaAutoScrollEnabled = false;
            this.arrayGrid.Location = new System.Drawing.Point(5, 65);
            this.arrayGrid.Name = "arrayGrid";
            this.arrayGrid.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.arrayGrid.Size = new System.Drawing.Size(418, 294);
            this.arrayGrid.TabIndex = 25;
            this.arrayGrid.TabStop = true;
            this.arrayGrid.ToolTipText = "";
            this.arrayGrid.VScrollBarVisible = false;
            // 
            // frmSample27
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.ClientSize = new System.Drawing.Size(428, 366);
            this.Controls.Add(this.arrayGrid);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbArrayType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btLoad);
            this.Controls.Add(this.txtCols);
            this.Controls.Add(this.txtRows);
            this.Name = "frmSample27";
            this.Text = "Array binding";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);

			arrayGrid.FixedColumns = 1;
			arrayGrid.FixedRows = 1;

			cbArrayType.Items.Add(typeof(string));
			cbArrayType.Items.Add(typeof(int));
			cbArrayType.Items.Add(typeof(long));
			cbArrayType.Items.Add(typeof(DateTime));
			cbArrayType.Items.Add(typeof(double));
			cbArrayType.Items.Add(typeof(float));
			cbArrayType.Items.Add(typeof(Int64));
			cbArrayType.Items.Add(typeof(AnchorStyles));
			//cbArrayType.Items.Add(typeof(ContentAlignment)); //this enum cannot be used because doesn't have a 0 Value (required if you not initializa the array)
			cbArrayType.Items.Add(typeof(Rectangle));
			cbArrayType.SelectedIndex = 0;

		}

		private void btLoad_Click(object sender, System.EventArgs e)
		{
			try
			{
				Type type;
				if (cbArrayType.SelectedItem is Type)
					type = (Type)cbArrayType.SelectedItem;
				else
					type = Type.GetType(cbArrayType.SelectedText,true);

				System.Array array = Array.CreateInstance(type, int.Parse(txtRows.Text), int.Parse(txtCols.Text));
				arrayGrid.DataSource = array;
			}
			catch(Exception err)
			{
				DevAge.Windows.Forms.ErrorDialog.Show(this,err, "Error");
			}
		}
	}
}
