﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeTrackerEtf.Client
{
    public class Config
    {
        public const string ApiRootUrl = "http://localhost:44342/";
        public const string ApiResourceUrl = ApiRootUrl + "api/";
        public const string TokenUrl = ApiRootUrl + "get-token";
    }
}
