// Copyright (c) 2009, Tom Lokovic
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions are met:
//
//     * Redistributions of source code must retain the above copyright notice,
//       this list of conditions and the following disclaimer.
//     * Redistributions in binary form must reproduce the above copyright
//       notice, this list of conditions and the following disclaimer in the
//       documentation and/or other materials provided with the distribution.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
// ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE
// LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR
// CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF
// SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
// INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN
// CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
// ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
// POSSIBILITY OF SUCH DAMAGE.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Midi
{
    /// <summary>
    /// MIDI Control, used in Control Change messages.
    /// </summary>
    /// <remarks>
    /// <para>In MIDI, Control Change messages are used to influence various auxiliary "controls"
    /// on a device, such as knobs, levers, and pedals.  Controls are specified with
    /// integers in [0..127].  This enum provides an incomplete list of controls, because
    /// most controls are too obscure to document effetively here.  Even for the ones listed
    /// here, the details of how the value is interpreted are arcane.  Please see the MIDI spec for
    /// details.</para>
    /// <para>The most commonly used control is SustainPedal, which is considered off when &lt; 64,
    /// on when &gt; 64.</para>
    /// <para>This enum has extension methods, such as <see cref="ControlExtensionMethods.Name"/>
    /// and <see cref="ControlExtensionMethods.IsValid"/>, defined in
    /// <see cref="ControlExtensionMethods"/>.</para>
    /// </remarks>
    public enum Control
    {
        Fader1 = 0,
        Fader2 = 1,
        Fader3 = 2,
        Fader4 = 3,
        Fader5 = 4,
        Fader6 = 5,
        Fader7 = 6,
        Fader8 = 7,
        Rec1 = 64,
        Rec2 = 65,
        Rec3 = 66,
        Rec4 = 67,
        Rec5 = 68,
        Rec6 = 69,
        Rec7 = 70,
        Rec8 = 71,
        Mute1 = 48,
        Mute2 = 49,
        Mute3 = 50,
        Mute4 = 51,
        Mute5 = 52,
        Mute6 = 53,
        Mute7 = 54,
        Mute8 = 55,
        Solo1 = 32,
        Solo2 = 33,
        Solo3 = 34,
        Solo4 = 35,
        Solo5 = 36,
        Solo6 = 37,
        Solo7 = 38,
        Solo8 = 39,
        Pan1 = 16,
        Pan2 = 17,
        Pan3 = 18,
        Pan4 = 19,
        Pan5 = 20,
        Pan6 = 21,
        Pan7 = 22,
        Pan8 = 23,
        Rev = 43,
        For = 44,
        Stop = 42,
        Play = 41,
        Rec = 45,
    }

    /// <summary>
    /// Extension methods for the Control enum.
    /// </summary>
    /// Be sure to "using midi" if you want to use these as extension methods.
    public static class ControlExtensionMethods
    {
        /// <summary>
        /// Returns true if the specified control is valid.
        /// </summary>
        /// <param name="control">The Control to test.</param>
        public static bool IsValid(this Control control)
        {
            return (int)control >= 0 && (int)control < 128;
        }

        /// <summary>
        /// Throws an exception if control is not valid.
        /// </summary>
        /// <param name="control">The control to validate.</param>
        /// <exception cref="ArgumentOutOfRangeException">The control is out-of-range.</exception>
        public static void Validate(this Control control)
        {
            if (!control.IsValid())
            {
                throw new ArgumentOutOfRangeException("Control out of range");
            }
        }

        /// <summary>
        /// Table of control names.
        /// </summary>
        private static Dictionary<int, string> ControlNames = new Dictionary<int, string>
        {
            {1, "Modulation wheel"},
            {6, "Data Entry MSB"},
            {7, "Volume"},
            {10, "Pan"},
            {11, "Expression"},
            {38, "Data Entry LSB"},
            {64, "Sustain pedal"},
            {91, "Reverb level"},
            {92, "Tremolo level"},
            {93, "Chorus level"},
            {94, "Celeste level"},
            {95, "Phaser level"},
            {98, "Non-registered Parameter LSB"},
            {99, "Non-registered Parameter MSB"},
            {100, "Registered Parameter Number LSB"},
            {101, "Registered Parameter Number MSB"},
            {121, "All controllers off"},
            {123, "All notes off"}
        };

        /// <summary>
        /// Returns the human-readable name of a MIDI control.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <exception cref="ArgumentOutOfRangeException">The control is out-of-range.</exception>
        public static string Name(this Control control)
        {
            control.Validate();
            if (ControlNames.ContainsKey((int)control))
            {
                return ControlNames[(int)control];
            }
            else
            {
                return "Other Control (see MIDI spec for details).";
            }
        }
    }
}
