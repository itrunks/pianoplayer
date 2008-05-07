using System;
using System.Collections.Generic;
using System.Text;
using Sanford.Multimedia.Midi;

namespace PianoPlayer
{
    public class MIDI : IDisposable
    {
        private OutputDevice outputDevice = new OutputDevice( 0 );
        private ChannelMessageBuilder channelMessageBuilder = new ChannelMessageBuilder();
        private bool disposed = false;

        public MIDI()
        {
        }

        ~MIDI()
        {
            Dispose( false );
        }

        public void SendCommand( ChannelCommand channelCommand, int note, int pitch )
        {
            channelMessageBuilder.Command = channelCommand;
            channelMessageBuilder.MidiChannel = 0;
            channelMessageBuilder.Data1 = note;
            channelMessageBuilder.Data2 = pitch;
            channelMessageBuilder.Build();

            outputDevice.Send( channelMessageBuilder.Result );
        }

        #region IDisposable Members

        public void Dispose()
        {
            Dispose( true );
            GC.SuppressFinalize( this );
        }

        protected virtual void Dispose( bool disposing )
        {
            if( !this.disposed )
            {
                if( disposing )
                {
                    outputDevice.Dispose();
                }
                disposed = true;
            }
        }

        #endregion
    }
}
