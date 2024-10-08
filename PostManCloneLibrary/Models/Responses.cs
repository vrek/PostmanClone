using System.ComponentModel.DataAnnotations;

namespace PostManCloneLibrary.Models
{
    public class Response
    {
        [Key]

        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string GUID { get; set; }
    }
}
