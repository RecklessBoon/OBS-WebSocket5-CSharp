﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OBSWebSocket5.Enum
{
    public enum RequestStatus
    {
        Unknown = 0,
        NoError = 10,
        Success = 100,
        MissingRequestType = 203,
        UnknownRequestType = 204,
        GenericError = 205,
        UnsupportedRequestBatchExecutionType = 206,
        MissingRequestField = 300,
        MissingRequestData = 301,
        InvalidRequestField = 400,
        InvalidRequestFieldType = 401,
        RequestFieldOutOfRange = 402,
        RequestFieldEmpty = 403,
        TooManyRequestFields = 404,
        OutputRunning = 501,
        OutputNotRunning = 501,
        OutputPaused = 502,
        OutputNotPaused = 503,
        OutputDisabled = 504,
        StudioModeActive = 505,
        StudioModeNotActive = 506,
        ResourceNotFound = 600,
        ResourceAlreadyExists = 601,
        InvalidResourceType = 602,
        NotEnoughResources = 603,
        InvalidResourceState = 604,
        InvalidInputKind = 605,
        ResourceNotConfigurable = 606,
        InvalidFilterKind = 607,
        ResourceCreationFailed = 700,
        ResourceActionFailed = 701,
        RequestProcessingFailed = 702,
        CannotAct = 703,
    }
}
