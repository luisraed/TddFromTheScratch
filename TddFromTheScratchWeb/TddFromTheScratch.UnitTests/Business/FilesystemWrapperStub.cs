﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TddFromTheScratch.UnitTests.Business
{
    public class FilesystemWrapperStub : IFilesystemWrapper
    {
        public bool Exists { get; set; }
        public string Path { get; set; }
        public string[] Lines { get; set; }

        public bool FileExists(string path)
        {
            return Exists;
        }

        public string PathCombine(string fileName)
        {
            return Path;
        }

        public string[] ReadAlllines(string path)
        {
            return Lines;
        }
    }
}
