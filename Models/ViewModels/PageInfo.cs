using System;

namespace BYUEgypt.Models.ViewModels
{
    public class PageInfo
    {
        public int TotalNumRecords { get; set; }
        public int RecordsPerPage { get; set; }
        public int CurrentPage { get; set; }
        
        // Figure out how many pages we need
        public int TotalPages => (int) Math.Ceiling((double) TotalNumRecords / RecordsPerPage);
    }
}