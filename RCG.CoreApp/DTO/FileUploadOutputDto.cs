using System;
using System.Collections.Generic;
using System.Text;

namespace RCG.CoreApp.DTO
{
    public class FileUploadOutputDto
    {
        public int NumberOfFailed { get; set; }
        public int NumberOfNew { get; set; }
        public int NumberOfTotal { get; set; }
    }
}
