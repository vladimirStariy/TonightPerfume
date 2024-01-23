using System.Collections;
using TonightPerfume.Domain.Models;

namespace TonightPerfume.Domain.Viewmodels.Filter
{
    public class FilterRequestDto
    {
        public int Page { get; set; }
        public bool isForOrder { get; set; }
        public ICollection<int> Volumes { get; set; }
        public int[] Prices { get; set; }
        public ICollection<int> Brands { get; set; }
        public ICollection<int> AromaGroups { get; set; }
        public ICollection<int> Categories { get; set; }
        public ICollection<int> PerfumeNotes { get; set; }
        public ICollection<string> Countries { get; set; }
        public string sortType { get; set; }
    }
}
