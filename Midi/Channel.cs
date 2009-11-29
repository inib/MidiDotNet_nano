﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Midi
{
    /// <summary>
    /// MIDI Channel.
    /// </summary>
    /// MIDI channels are named starting at 1, but encoded programmatically starting at 0.
    ///
    /// Channel10 is the dedicated percussion channel.
    public enum Channel
    {
        /// <summary> MIDI Channel 1. </summary>
        Channel1 = 0,
        /// <summary> MIDI Channel 2. </summary>
        Channel2 = 1,
        /// <summary> MIDI Channel 3. </summary>
        Channel3 = 2,
        /// <summary> MIDI Channel 4. </summary>
        Channel4 = 3,
        /// <summary> MIDI Channel 5. </summary>
        Channel5 = 4,
        /// <summary> MIDI Channel 6. </summary>
        Channel6 = 5,
        /// <summary> MIDI Channel 7. </summary>
        Channel7 = 6,
        /// <summary> MIDI Channel 8. </summary>
        Channel8 = 7,
        /// <summary> MIDI Channel 9. </summary>
        Channel9 = 8,
        /// <summary> MIDI Channel 10, the dedicated percussion channel. </summary>
        Channel10 = 9,
        /// <summary> MIDI Channel 11. </summary>
        Channel11 = 10,
        /// <summary> MIDI Channel 12. </summary>
        Channel12 = 11,
        /// <summary> MIDI Channel 13. </summary>
        Channel13 = 12,
        /// <summary> MIDI Channel 14. </summary>
        Channel14 = 13,
        /// <summary> MIDI Channel 15. </summary>
        Channel15 = 14,
        /// <summary> MIDI Channel 16. </summary>
        Channel16 = 15
    };

    /// <summary>
    /// Extension methods for the Channel enum.
    /// </summary>
    /// Be sure to "using midi" if you want to use these as extension methods.
    public static class ChannelExtensionMethods
    {
        /// <summary>
        /// Returns true if the specified channel is valid.
        /// </summary>
        /// <param name="channel">The channel to test.</param>
        public static bool IsValid(this Channel channel)
        {
            return (int)channel >= 0 && (int)channel < 16;
        }

        /// <summary>
        /// Throws an exception if channel is not valid.
        /// </summary>
        /// <param name="channel">The channel to validate.</param>
        public static void Validate(this Channel channel)
        {
            if (!channel.IsValid())
            {
                throw new Exception("invalid Channel");
            }
        }

        /// <summary>
        /// Table of channel names.
        /// </summary>
        private static string[] ChannelNames = new string[]
        {
            "Channel 1",
            "Channel 2",
            "Channel 3",
            "Channel 4",
            "Channel 5",
            "Channel 6",
            "Channel 7",
            "Channel 8",
            "Channel 9",
            "Channel 10"
        };

        /// <summary>
        /// Returns the human-readable name of a MIDI channel.
        /// </summary>
        /// <param name="channel">The channel.</param>
        public static string Name(this Channel channel)
        {
            channel.Validate();
            return ChannelNames[(int)channel];
        }
    }
}