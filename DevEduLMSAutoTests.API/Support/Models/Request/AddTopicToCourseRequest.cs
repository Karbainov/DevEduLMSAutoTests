﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEduLMSAutoTests.API.Support.Models.Request
{
    public class AddTopicToCourseRequest
    {
        [JsonPropertyName("position")]
        public int Position { get; set; }
    }
}