using System;
using System.Collections.Generic;
using System.Text;

namespace WalletApp
{
    public class Category
    {
        private string _name;
        private string _description;
        private string _color; //name or value (rgb, hsl, hex etc.) - variable type may be changed later
        private string _icon_path; //TODO: path to icon file - variable type may be changed later

        //constructors
        public Category()
        {
            _name = "Other";
            _description = "Default category";
            _color = "#03d3fc";
            _icon_path = "C:\\Users\\Nastya\\Desktop\\C#\\WalletApp\\WalletApp\\files\\noun_sparkle_2595966.png";
        }

        public Category(string name, string description, string icon_path, string color = "#03d3fc")
        {
            _name = name;
            _description = description;
            _color = color;
            _icon_path = icon_path;
        }

        //getters & setters
        public string Name
        {
            get { return _name; }
            private set { _name = value; }
        }

        public string Description
        {
            get { return _description; }
            private set { _description = value; }
        }

        public string Color
        {
            get { return _color; }
            private set { _color = value; }
        }

        public string IconPath
        {
            get { return _icon_path; }
            private set { _icon_path = value; }
        }

    }
}
