namespace ClienteRazor.Models
{
    public class VmJobs
    {
        public short Id { get; set; }
        public string? JobDesc { get; set; }
        public byte? MinLev { get; set; }

        public byte? MaxLev { get; set; }
    }
}
