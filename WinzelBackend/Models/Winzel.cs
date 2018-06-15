using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WinzelBackend.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Net.Mime;

    using Microsoft.CodeAnalysis;

    public class Winzel
    {
        public long Id { get; set; }
        public string WinzelTitle { get; set; }
        public string WinzelText { get; set; }
        public string WinzelLocation { get; set; }
        public ICollection<WinzelGrapes> WinzelGraps { get; set; }
        public ICollection<WinzelHashTag> WinzelHashTags { get; set; }
        public int WinzelUpvotes { get; set; }
        public string WinzelDate { get; set; }
        public string WinzelAuthor { get; set; }
        public ICollection<WinzelComment> WinzelComments { get; set; }
        public string WinzelImage { get; set; }
    }
}
