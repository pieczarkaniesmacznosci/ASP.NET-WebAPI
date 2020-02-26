namespace ExpressoAPI.Models
{
    using System.Collections.Generic;

    public class Menu
    {
        public int SubMenuId { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }
        public ICollection<SubMenu> SubMenus { get; set; }
    }
}