using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinApp.ViewModels
{
    public class CollectionOfUsers
    {
        public CollectionOfUsers()
        {
            this.Users = new List<UserViewModel>();
            this.AddSampleData();
        }

        public IList<UserViewModel> Users { get; set; }

        private void AddSampleData()
        {
            this.Users.Add(new UserViewModel() { Name = "Ivan Petrov", ImageUrl = "http://edge.alluremedia.com.au/m/l/2015/06/CodingSnippet.jpg" });
            this.Users.Add(new UserViewModel() { Name = "Goergi", ImageUrl = "https://cdn3.iconfinder.com/data/icons/web-development-3/512/web_coding_website_code_programming_flat_icon-128.png" });
            this.Users.Add(new UserViewModel() { Name = "Petio Sharov", ImageUrl = "http://icons.iconarchive.com/icons/dakirby309/windows-8-metro/256/Apps-Coding-app-Metro-icon.png" });
            this.Users.Add(new UserViewModel() { Name = "Petar Ivanov", ImageUrl = "http://edge.alluremedia.com.au/m/l/2015/06/CodingSnippet.jpg" });
            this.Users.Add(new UserViewModel() { Name = "Ivan Todorov", ImageUrl = "https://pbs.twimg.com/profile_images/595694555107831808/QZc4Mi8O.png" });
            this.Users.Add(new UserViewModel() { Name = "Pesho 2", ImageUrl = "http://edge.alluremedia.com.au/m/l/2015/06/CodingSnippet.jpg" });
        }
    }
}
