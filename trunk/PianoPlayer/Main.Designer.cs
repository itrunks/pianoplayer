namespace PianoPlayer
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if( disposing && ( components != null ) )
            {
                components.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( Main ) );
            this.octave = new System.Windows.Forms.NumericUpDown();
            this.octaveLabel = new System.Windows.Forms.Label();
            this.pianoKeyboard = new PianoPlayer.PianoKeyboard();
            ( ( System.ComponentModel.ISupportInitialize )( this.octave ) ).BeginInit();
            this.SuspendLayout();
            // 
            // octave
            // 
            this.octave.Location = new System.Drawing.Point( 572, 7 );
            this.octave.Maximum = new decimal( new int[] {
            8,
            0,
            0,
            0} );
            this.octave.Minimum = new decimal( new int[] {
            1,
            0,
            0,
            0} );
            this.octave.Name = "octave";
            this.octave.Size = new System.Drawing.Size( 29, 20 );
            this.octave.TabIndex = 3;
            this.octave.Value = new decimal( new int[] {
            5,
            0,
            0,
            0} );
            this.octave.ValueChanged += new System.EventHandler( this.octave_ValueChanged );
            // 
            // octaveLabel
            // 
            this.octaveLabel.AutoSize = true;
            this.octaveLabel.Location = new System.Drawing.Point( 524, 9 );
            this.octaveLabel.Name = "octaveLabel";
            this.octaveLabel.Size = new System.Drawing.Size( 42, 13 );
            this.octaveLabel.TabIndex = 4;
            this.octaveLabel.Text = "Octave";
            // 
            // pianoKeyboard
            // 
            this.pianoKeyboard.Font = new System.Drawing.Font( "Microsoft Sans Serif", 6F );
            this.pianoKeyboard.Location = new System.Drawing.Point( 11, 32 );
            this.pianoKeyboard.Margin = new System.Windows.Forms.Padding( 2, 2, 2, 2 );
            this.pianoKeyboard.Name = "pianoKeyboard";
            this.pianoKeyboard.Octave = 0;
            this.pianoKeyboard.Size = new System.Drawing.Size( 590, 163 );
            this.pianoKeyboard.TabIndex = 5;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 615, 206 );
            this.Controls.Add( this.pianoKeyboard );
            this.Controls.Add( this.octaveLabel );
            this.Controls.Add( this.octave );
            this.Icon = ( ( System.Drawing.Icon )( resources.GetObject( "$this.Icon" ) ) );
            this.Name = "Main";
            this.Text = "Piano Player";
            ( ( System.ComponentModel.ISupportInitialize )( this.octave ) ).EndInit();
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown octave;
        private System.Windows.Forms.Label octaveLabel;
        private PianoKeyboard pianoKeyboard;
    }
}

