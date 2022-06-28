using System.ComponentModel.DataAnnotations;

namespace UserServiceModels
{
    /// <summary>
    /// TODO IMPLEMENT USERROLES
    /// </summary>
    public class UserRole
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string description { get; set; }

    }
}
