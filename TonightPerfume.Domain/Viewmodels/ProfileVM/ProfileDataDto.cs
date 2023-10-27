namespace TonightPerfume.Domain.Viewmodels.ProfileVM
{
    public class ProfileDataDto
    {
        public string? Firstname { get; set; }
        public string? Middlename { get; set; }
        public string? Lastname { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

        public List<ProfileAdressDto> ProfileAdresses { get; set; } = new List<ProfileAdressDto>();
    }
}
