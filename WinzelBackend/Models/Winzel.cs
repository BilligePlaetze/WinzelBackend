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
        public WinzelTitle WinzelTitle { get; set; }
        public WinzelAuthor WinzelAuthor { get; set; }
        public WinzelLocation WinzelLocation { get; set; }
        public List<WinzelTextContent> WinzelContents { get; set; }
        public List<WinzelComment> WinzelComments { get; set; }
    }
}
