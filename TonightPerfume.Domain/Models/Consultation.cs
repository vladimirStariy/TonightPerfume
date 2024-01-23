namespace TonightPerfume.Domain.Models
{
    public class Consultation
    {
        public uint Consultation_ID { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public bool IsNew { get; set; }
        public bool IsOver { get; set; }
        public DateTime ConsultationDate { get; set; }
    }
}
