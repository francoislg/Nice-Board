﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nice_Board.Clients
{
    public class DeviceAuthorizationResponse
    {
        public string device_code { get; set; }
        public string user_code { get; set; }
        public string verification_url { get; set; }
        public string expires_in { get; set; }
        public string interval { get; set; }
    }
}
