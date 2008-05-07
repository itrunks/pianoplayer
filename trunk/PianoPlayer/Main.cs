using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PianoPlayer
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        #region Events

        protected override void OnClosed( EventArgs e )
        {
            pianoKeyboard.Stop();
            base.OnClosed( e );
        }

        private void octave_ValueChanged( object sender, EventArgs e )
        {
            pianoKeyboard.Octave = Convert.ToInt32( octave.Value );
            pianoKeyboard.Focus();
        }

        #endregion
    }
}
