﻿using System;
using System.Collections.Generic;
using System.Text;
using MlkPwgen;

namespace Com.Danliris.Service.Sales.Lib.Utilities
{
    public static class CodeGenerator
    {
        private const int LENGTH = 8;
        private const string ALLOWED_CHARACTER = "ABCDEFGHIJKLMNPQRSTUVWXYZ123456789";

        public static string Generate()
        {
            return PasswordGenerator.Generate(length: LENGTH, allowed: ALLOWED_CHARACTER);
        }
    }
}
