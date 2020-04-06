namespace Muistipeli
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblAika = new System.Windows.Forms.Label();
            this.lblTaso = new System.Windows.Forms.Label();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.lblSiirrot = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "peitto.png");
            this.imageList1.Images.SetKeyName(1, "kuva1.png");
            this.imageList1.Images.SetKeyName(2, "kuva2.png");
            this.imageList1.Images.SetKeyName(3, "kuva3.png");
            this.imageList1.Images.SetKeyName(4, "kuva4.png");
            this.imageList1.Images.SetKeyName(5, "kuva5.png");
            this.imageList1.Images.SetKeyName(6, "kuva6.png");
            this.imageList1.Images.SetKeyName(7, "kuva7.png");
            this.imageList1.Images.SetKeyName(8, "kuva8.png");
            this.imageList1.Images.SetKeyName(9, "kuva9.png");
            this.imageList1.Images.SetKeyName(10, "kuva10.png");
            this.imageList1.Images.SetKeyName(11, "kuva11.png");
            this.imageList1.Images.SetKeyName(12, "kuva12.png");
            this.imageList1.Images.SetKeyName(13, "kuva13.png");
            this.imageList1.Images.SetKeyName(14, "kuva14.png");
            this.imageList1.Images.SetKeyName(15, "kuva15.png");
            this.imageList1.Images.SetKeyName(16, "kuva16.png");
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblAika
            // 
            this.lblAika.AutoSize = true;
            this.lblAika.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAika.Location = new System.Drawing.Point(12, 9);
            this.lblAika.Name = "lblAika";
            this.lblAika.Size = new System.Drawing.Size(75, 31);
            this.lblAika.TabIndex = 4;
            this.lblAika.Text = "Aika:";
            // 
            // lblTaso
            // 
            this.lblTaso.AutoSize = true;
            this.lblTaso.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaso.Location = new System.Drawing.Point(378, 9);
            this.lblTaso.Name = "lblTaso";
            this.lblTaso.Size = new System.Drawing.Size(83, 31);
            this.lblTaso.TabIndex = 4;
            this.lblTaso.Text = "Taso:";
            // 
            // btnLeft
            // 
            this.btnLeft.BackgroundImage = global::Muistipeli.Properties.Resources.leftarrow;
            this.btnLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLeft.Location = new System.Drawing.Point(250, 9);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(60, 40);
            this.btnLeft.TabIndex = 5;
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnRight
            // 
            this.btnRight.BackgroundImage = global::Muistipeli.Properties.Resources.rightarrow;
            this.btnRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRight.Location = new System.Drawing.Point(316, 9);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(60, 40);
            this.btnRight.TabIndex = 5;
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // lblSiirrot
            // 
            this.lblSiirrot.AutoSize = true;
            this.lblSiirrot.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSiirrot.Location = new System.Drawing.Point(12, 40);
            this.lblSiirrot.Name = "lblSiirrot";
            this.lblSiirrot.Size = new System.Drawing.Size(105, 31);
            this.lblSiirrot.TabIndex = 4;
            this.lblSiirrot.Text = "Siirtoja:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 538);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.lblTaso);
            this.Controls.Add(this.lblSiirrot);
            this.Controls.Add(this.lblAika);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblAika;
        private System.Windows.Forms.Label lblTaso;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Label lblSiirrot;
    }
}

