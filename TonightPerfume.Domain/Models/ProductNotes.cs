using System.ComponentModel.DataAnnotations.Schema;

namespace TonightPerfume.Domain.Models
{
    public class ProductNotes
    {
        public uint ProductNote_ID { get; set; }
        public uint Note_ID { get; set; }
        [ForeignKey("Note_ID")]
        public virtual PerfumeNote PerfumeNote { get; set; }
        public uint Product_ID { get; set; }
        [ForeignKey("Product_ID")]
        public virtual Product Product { get; set; }
        public string NoteType { get; set; }
    }
}
