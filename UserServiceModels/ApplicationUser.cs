
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using UserServiceModels.Relationships;
using WorkspaceModels;

namespace UserServiceModels
{
    public enum UserType
    {
        User, Administrator

    }
    public class ApplicationUser : IdentityUser
    {
        public string? Token { get; set; }


        [Required]
        [MinLength(3)]
        [StringLength(50)]
        [ProtectedPersonalData]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        [StringLength(50)]
        [ProtectedPersonalData]
        public string LastName { get; set; }

        [Required]
        public UserType Type { get; private set; } //ROLES?

        public List<Workspace> Workspaces { get; set; } = new();
        public List<Workspace> FavoriteWorkspaces { get; set; } = new();

        public ICollection<UserGroups>? Groups { get; set; }

        #region adminCtor
        public ApplicationUser(string title, string firstName, string lastName, string email, string identificationNumber, UserType type = UserType.User)
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(FirstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(LastName));
            Email = email;
            UserName = identificationNumber;
            Type = type;
        }
        #endregion

        public ApplicationUser() { }


        private bool IdentificationNumberIsValid(string identificationNumberToCheck)
        {
            return OnlyContainsNumbers(identificationNumberToCheck) && identificationNumberToCheck.Length > 0 &&
                   identificationNumberToCheck.Length <= 32;
        }

        public bool OnlyContainsNumbers(string toTest)
        {
            return int.TryParse(toTest, out var i);
        }

    }
}
