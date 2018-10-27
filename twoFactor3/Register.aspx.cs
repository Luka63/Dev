using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace twoFactor3 {
    public partial class Register : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }


        protected void CreateUser_Click(object sender, EventArgs e) {
            // Default UserStore constructor uses the default connection string named: DefaultConnection
            var userStore = new UserStore<IdentityUser>();
            var manager = new UserManager<IdentityUser>(userStore);

            // const int passwordLength = 8;
           // manager.PasswordValidator = new CustomPasswordValidator(passwordLength);
            manager.PasswordValidator = new CustomPasswordValidator();
        //    manager.UserValidator = new CustomUserValidator();

            var user = new IdentityUser() { UserName = UserName.Text };
            IdentityResult result = manager.Create(user, Password.Text);

            if (result.Succeeded) {
                StatusMessage.Text = string.Format("User {0} was created successfully!", user.UserName);
            }
            else {
                StatusMessage.Text = result.Errors.FirstOrDefault();
            }
        }
    }    
}