﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telephony.IO.Interfaces;

namespace Telephony.IO
{
    public class FileWriter : IWriter
    {
        public void WriteLine(string line)
        {
            string filePath = "../../../output.txt";

            using StreamWriter writer = new (filePath, true);

            writer.WriteLine(line);
        }
    }
}
