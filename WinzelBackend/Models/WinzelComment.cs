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

    public class WinzelComment
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public string Date { get; set; }
    }
}
