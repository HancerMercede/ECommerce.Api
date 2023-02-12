using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.API.Entities
{
    public class Client
    {
          
        public Guid ClientId { get; set; }
        private string _name;
        private string _lastname;
        public string? Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = string.Join(' ', 
                        value.Split(' ').Select(x => x[0].ToString().ToUpper() + x.Substring(1).ToLower()).ToArray());
            }
        }
        public string? LastName
        {
            get
            {
                return _lastname;
            }
            set {
                _lastname = string.Join(' ',
                            value.Split(' ').Select(c => c[0].ToString().ToUpper() + c.Substring(1).ToLower()).ToArray());
            }
        }
        public string? Address { get; set; }
        [Phone(ErrorMessage ="Please enter a valid phone number.")]
        public string? Telephone { get; set; }
        [EmailAddress(ErrorMessage ="Please select a valid Email.")]
        public string? Email { get; set; }
        public string? RNC { get; set; }
        public string? DNI { get; set;}
    }
}
