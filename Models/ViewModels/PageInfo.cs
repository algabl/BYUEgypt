using System;

namespace BYUEgypt.Models.ViewModels
{
    public class PageInfo
    {
        public int TotalNumArtifacts { get; set; }
        public int ArtifactsPerPage { get; set; }
        public int CurrentPage { get; set; }
        
        // Figure out how many pages we need
        public int TotalPages => (int) Math.Ceiling((double) TotalNumArtifacts / ArtifactsPerPage);
    }
}