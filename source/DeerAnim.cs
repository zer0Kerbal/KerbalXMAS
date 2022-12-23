/* Kerbal XMAS (XMAS) - Custom Deer Animation
   * Copyright (C) 2014 Lunatic Aeronautics (ximrm and Tuareg)
   * Copyright (C) 2020,2022 zer0Kerbal

  * This program is free software; you can redistribute it and/or modify
  * it under the terms of the GNU General Public License as published by
  * the Free Software Foundation; either version 2 of the License, or (at
  * your option) any later version.
  * 
  * This program is distributed in the hope that it will be useful, but
  * WITHOUT ANY WARRANTY; without even the implied warranty of
  * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
  * General Public License for more details.
  * 
  * You should have received a copy of the GNU General Public License
  * along with this program; if not, write to the Free Software
  * Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307
  * USA.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace KerbalXMAS
{
    /// <summary>Kerbal XMAS (XMAS - custom Deer Animation</summary>
    public class DeerAnim : PartModule
    {
        /// <summary>Idle Animation</summary>
        [KSPField(isPersistant = false)]
        public string IdleAnim;

        /// <summary>Trot Animation</summary>
        [KSPField(isPersistant = false)]
        public string TrotAnim;

        /// <summary>Gallop Animation</summary>
        [KSPField(isPersistant = false)]
        public string GallopAnim;

        private Animation myAnimation;

        private float ActualThrot;

        private FXGroup IdleAudio = new FXGroup("Idle");
        private FXGroup TrotAudio = new FXGroup("Walk");
        private FXGroup GallopAudio = new FXGroup("Gallop");

        /// <summary>OnStart</summary>
        /// <param name="State"></param>
        public override void OnStart(StartState State)
        {
            myAnimation = this.part.GetComponentInChildren<Animation>();

            IdleAudio.audio = this.gameObject.AddComponent<AudioSource>();
            IdleAudio.audio.clip = GameDatabase.Instance.GetAudioClip("LunaticAeronautics/KerbalXMAS/Sounds/Idle");
            IdleAudio.audio.dopplerLevel = 0f;
            IdleAudio.audio.rolloffMode = AudioRolloffMode.Logarithmic;
            IdleAudio.audio.Stop();
            IdleAudio.audio.loop = true;
            IdleAudio.audio.volume = GameSettings.SHIP_VOLUME;
            IdleAudio.audio.time = 0;
            IdleAudio.audio.maxDistance = 2000;

            TrotAudio.audio = this.gameObject.AddComponent<AudioSource>();
            TrotAudio.audio.clip = GameDatabase.Instance.GetAudioClip("LunaticAeronautics/KerbalXMAS/Sounds/Walk");
            TrotAudio.audio.dopplerLevel = 0f;
            TrotAudio.audio.rolloffMode = AudioRolloffMode.Logarithmic;
            TrotAudio.audio.Stop();
            TrotAudio.audio.loop = true;
            TrotAudio.audio.volume = GameSettings.SHIP_VOLUME;
            TrotAudio.audio.time = 0;
            TrotAudio.audio.maxDistance = 2000;

            GallopAudio.audio = this.gameObject.AddComponent<AudioSource>();
            GallopAudio.audio.clip = GameDatabase.Instance.GetAudioClip("LunaticAeronautics/KerbalXMAS/Sounds/Gallop");
            GallopAudio.audio.dopplerLevel = 0f;
            GallopAudio.audio.rolloffMode = AudioRolloffMode.Logarithmic;
            GallopAudio.audio.Stop();
            GallopAudio.audio.loop = true;
            GallopAudio.audio.volume = GameSettings.SHIP_VOLUME;
            GallopAudio.audio.time = 0;
            GallopAudio.audio.maxDistance = 2000;
        }

        /// <summary>OnUpdate</summary>
        public override void OnUpdate()
        {
            ActualThrot = vessel.ctrlState.mainThrottle;
            ModuleEngines engines = (ModuleEngines)this.part.Modules["ModuleEngines"];

            Debug.Log(IdleAudio.audio.time);
            Debug.Log(TrotAudio.audio.time);
            Debug.Log(GallopAudio.audio.time);

            if (ActualThrot == 0 || this.part.State == PartStates.DEACTIVATED || this.part.State == PartStates.IDLE || this.part.State == PartStates.DEAD || !engines.getIgnitionState || engines.getFlameoutState)
            {
                this.myAnimation[IdleAnim].speed = 1;
                this.myAnimation.Play(IdleAnim);

                if (!this.IdleAudio.audio.isPlaying)
                {
                    this.TrotAudio.audio.Stop();
                    this.GallopAudio.audio.Stop();

                    this.IdleAudio.audio.time = 0;
                    this.IdleAudio.audio.Play();
                }
            }

            if (ActualThrot > 0 && ActualThrot <= 0.9 && this.part.State == PartStates.ACTIVE && engines.getIgnitionState && !engines.getFlameoutState)
            {
                this.myAnimation[TrotAnim].speed = Mathf.Clamp(ActualThrot * 2, 0.5f, 1.5f);
                this.myAnimation.Play(TrotAnim);

                this.TrotAudio.audio.pitch = Mathf.Clamp(ActualThrot *2, 0.8f, 1.3f);

                if (!this.TrotAudio.audio.isPlaying)
                {
                    this.IdleAudio.audio.Stop();
                    this.GallopAudio.audio.Stop();

                    this.TrotAudio.audio.time = 0;
                    this.TrotAudio.audio.Play();
                }
            }

            if (ActualThrot > 0.9 && this.part.State == PartStates.ACTIVE && engines.getIgnitionState && !engines.getFlameoutState)
            {
                this.myAnimation[GallopAnim].speed = 1 + (ActualThrot - 0.9f) * 5;
                this.myAnimation.Play(GallopAnim);

                if (!this.GallopAudio.audio.isPlaying)
                {
                    this.IdleAudio.audio.Stop();
                    this.TrotAudio.audio.Stop();

                    this.GallopAudio.audio.time = 0;
                    this.GallopAudio.audio.Play();
                }
            }
        }
    }
}