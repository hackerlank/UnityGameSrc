﻿namespace PlayerView
{
    using System;

    public class PandaCharacterAudio : AbstractCharacterAudio
    {
        protected override void onInitialize()
        {
            base.AggroAudioGroupType = AudioGroupType.SfxGrpGameplay_PetJadeVoice;
        }
    }
}

