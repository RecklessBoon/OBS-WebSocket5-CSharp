﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OBSWebSocket5.Enum
{
    public enum MediaStateType
    {
        OBS_MEDIA_STATE_NONE,
        OBS_MEDIA_STATE_PLAYING,
        OBS_MEDIA_STATE_OPENING,
        OBS_MEDIA_STATE_BUFFERING,
        OBS_MEDIA_STATE_PAUSED,
        OBS_MEDIA_STATE_STOPPED,
        OBS_MEDIA_STATE_ENDED,
        OBS_MEDIA_STATE_ERROR
    }
}
