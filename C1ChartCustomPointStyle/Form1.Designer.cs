namespace C1ChartCustomPointStyle
{
   partial class Form1
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
         this.c1Chart1 = new C1.Win.C1Chart.C1Chart();
         this.cmdStart = new System.Windows.Forms.Button();
         ((System.ComponentModel.ISupportInitialize)(this.c1Chart1)).BeginInit();
         this.SuspendLayout();
         // 
         // c1Chart1
         // 
         this.c1Chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.c1Chart1.Location = new System.Drawing.Point(12, 12);
         this.c1Chart1.Name = "c1Chart1";
         this.c1Chart1.PropBag = resources.GetString("c1Chart1.PropBag");
         this.c1Chart1.Size = new System.Drawing.Size(776, 385);
         this.c1Chart1.TabIndex = 0;
         // 
         // cmdStart
         // 
         this.cmdStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.cmdStart.Location = new System.Drawing.Point(12, 415);
         this.cmdStart.Name = "cmdStart";
         this.cmdStart.Size = new System.Drawing.Size(75, 23);
         this.cmdStart.TabIndex = 1;
         this.cmdStart.Text = "Start";
         this.cmdStart.UseVisualStyleBackColor = true;
         this.cmdStart.Click += new System.EventHandler(this.cmdStart_Click);
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(800, 450);
         this.Controls.Add(this.cmdStart);
         this.Controls.Add(this.c1Chart1);
         this.Name = "Form1";
         this.Text = "Form1";
         ((System.ComponentModel.ISupportInitialize)(this.c1Chart1)).EndInit();
         this.ResumeLayout(false);

      }

        #endregion

        private C1.Win.C1Chart.C1Chart c1Chart1;
        private System.Windows.Forms.Button cmdStart;
    }
}

