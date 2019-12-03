using System.ComponentModel.DataAnnotations;

namespace Raybiztech.Kentico12.MVC.Widgets.RegistrationForm
{
    public class RegistrationFormViewModel 
    {
        #region Regitration Form Properties
        //By using this properties to save the register user details
        [Required(ErrorMessage = "Please enter First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter Last Name")]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please enter Email Address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,4}$", ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please enter Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please enter Confirm Password")]
        [Compare("Password", ErrorMessage = "Your password didn't match. Please confirm your password")]
        public string PasswordConfirmation { get; set; }
        public string ValidationMessage { get; set; }
        #endregion
    }
}