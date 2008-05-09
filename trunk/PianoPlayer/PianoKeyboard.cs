using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Sanford.Multimedia.Midi;

namespace PianoPlayer
{
    public partial class PianoKeyboard : UserControl
    {
        private Dictionary<Keys, int> keyboard = new Dictionary<Keys, int>();
        private Dictionary<Keys, bool> keyDown = new Dictionary<Keys, bool>();
        private MIDI midi;
        private int octave = 5;

        public PianoKeyboard()
        {
            InitializeComponent();

            this.Font = new Font( this.Font.Name, 6, FontStyle.Regular );
            octave = 5;
            midi = new MIDI();

            InitializeKeyboard();
        }

        private void InitializeKeyboard()
        {
            keyboard[ Keys.Z ] = 0;
            keyboard[ Keys.S ] = -1;
            keyboard[ Keys.X ] = 1;
            keyboard[ Keys.D ] = -2;
            keyboard[ Keys.C ] = 2;
            keyboard[ Keys.V ] = 3;
            keyboard[ Keys.G ] = -4;
            keyboard[ Keys.B ] = 4;
            keyboard[ Keys.H ] = -5;
            keyboard[ Keys.N ] = 5;
            keyboard[ Keys.J ] = -6;
            keyboard[ Keys.M ] = 6;

            keyboard[ Keys.Oemcomma ] = 7;
            keyboard[ Keys.L ] = -8;
            keyboard[ Keys.OemPeriod ] = 8;
            keyboard[ Keys.OemSemicolon ] = -9;
            keyboard[ Keys.OemQuestion ] = 9;
            keyboard[ Keys.Q ] = 10;
            keyboard[ Keys.D2 ] = -11;
            keyboard[ Keys.W ] = 11;
            keyboard[ Keys.D3 ] = -12;
            keyboard[ Keys.E ] = 12;
            keyboard[ Keys.D4 ] = -13;
            keyboard[ Keys.R ] = 13;

            keyboard[ Keys.T ] = 14;
            keyboard[ Keys.D6 ] = -15;
            keyboard[ Keys.Y ] = 15;
            keyboard[ Keys.D7 ] = -16;
            keyboard[ Keys.U ] = 16;
            keyboard[ Keys.I ] = 17;
            keyboard[ Keys.D9 ] = -18;
            keyboard[ Keys.O ] = 18;
            keyboard[ Keys.D0 ] = -19;
            keyboard[ Keys.P ] = 19;
            keyboard[ Keys.OemMinus ] = -20;
            keyboard[ Keys.OemOpenBrackets ] = 20;
            keyboard[ Keys.OemCloseBrackets ] = 21;

            // set initial key status to up
            foreach( Keys k in keyboard.Keys )
            {
                keyDown[ k ] = false;
            }

        }
        private int GetNote( Keys key )
        {
            int note = 0;
            foreach( Keys k in keyboard.Keys )
            {
                if( k.Equals( key ) ) return note;
                note++;
            }
            return -1;
        }
        private string GetNoteName( int n )
        {
            switch( n )
            {
                case 0:
                    return "C";
                case 1:
                    return "D";
                case 2:
                    return "E";
                case 3:
                    return "F";
                case 4:
                    return "G";
                case 5:
                    return "A";
                case 6:
                    return "B";
                default:
                    return "?";
            }
        }

        private void PlayNote( Keys key, bool isDown )
        {
            int note = GetNote( key ) + 12 * octave;

            keyDown[ key ] = isDown;

            if( isDown )
            {
                midi.SendCommand( ChannelCommand.NoteOn, note, 127 );
            }
            else
            {
                midi.SendCommand( ChannelCommand.NoteOff, note, 0 );
            }

            DrawKey( keyboard[ key ], isDown );
        }

        private void DrawKeyboard( Graphics g )
        {
            float keyWidth = ( this.Width / 22 );
            int keyHeight = this.Height - 1;
            int x;
            float width;
            float height;
            int note = 0;

            g.Clear( Color.White );

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            for( float i = 0; i < this.Width; i += keyWidth )
            {
                //g.DrawLine( Pens.Red, x, 10, x, 100 );
                g.DrawRectangle( Pens.Black, i, 0, i + keyWidth, keyHeight );
                g.DrawString( GetNoteName( note % 7 ), this.Font, Brushes.Black, i + keyWidth - this.Font.Height, keyHeight - this.Font.Height );
                note++;
            }

            foreach( Keys key in keyboard.Keys )
            {
                if( keyboard[ key ] < 0 )
                {
                    x = Convert.ToInt32( Convert.ToSingle( -keyboard[ key ] ) * keyWidth ) - Convert.ToInt32( keyWidth / 4 );
                    width = ( keyWidth / 2 );
                    height = ( this.Height / 10 ) * 6;
                    g.FillRectangle( Brushes.Black, x, 0, width, height );
                }
            }
        }


        private void DrawKey( int key, bool isDown )
        {
            float keyWidth = ( this.Width / 22 );

            int x = Convert.ToInt32( Convert.ToSingle( key ) * keyWidth );
            int y = ( this.Height / 10 ) * 8;

            if( key < 0 )
            {
                x = -x - Convert.ToInt32( keyWidth / 4 );
                y = ( y / 8 ) * 4;
            }

            float width = keyWidth - 4;
            float height = width;

            if( key < 0 )
            {
                width = height = ( width - 2 ) / 2;
            }

            using( Graphics g = this.CreateGraphics() )
            {
                //g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                if( isDown )
                {
                    g.FillEllipse( Brushes.Red, x + 2, y, width, height );
                }
                else
                {
                    g.FillEllipse( key >= 0 ? Brushes.White : Brushes.Black, x + 2, y, width, height );
                }
            }
        }

        internal void Stop()
        {
            if( midi != null )
            {
                midi.Dispose();
                midi = null;
            }
        }

        #region Properties

        [DefaultValue( 5 )]
        public int Octave
        {
            get
            {
                return octave;
            }
            
            set
            {
                octave = value; 
            }
        }

        #endregion

        #region Events

        protected override void OnPaint( PaintEventArgs e )
        {
            base.OnPaint( e );
            DrawKeyboard( e.Graphics );
        }

        protected override void OnKeyDown( KeyEventArgs e )
        {
            base.OnKeyDown( e );
            if( keyboard.ContainsKey( e.KeyCode ) && !keyDown[ e.KeyCode ] ) PlayNote( e.KeyCode, true );
        }

        protected override void OnKeyUp( KeyEventArgs e )
        {
            base.OnKeyUp( e );
            if( keyboard.ContainsKey( e.KeyCode ) && keyDown[ e.KeyCode ] ) PlayNote( e.KeyCode, false );
        }

        protected override void OnControlRemoved( ControlEventArgs e )
        {
            Stop();
            base.OnControlRemoved( e );
        }

        #endregion
    }
}