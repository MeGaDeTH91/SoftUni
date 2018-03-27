using LoggerLibrary.Interfaces;
using LoggerLibrary.Models.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerLibrary.Factories
{
    public class LayoutFactory
    {
        public ILayout CreateLayout(string layoutType)
        {
            ILayout layout = null;

            switch (layoutType)
            {
                case "SimpleLayout":
                    layout = new SimpleLayout();
                    break;
                case "XmlLayout":
                    layout = new XmlLayout();
                    break;
                case "JsonLayout":
                    layout = new JsonLayout();
                    break;
                default:
                    throw new ArgumentException("Invalid Layout!");
            }

            return layout;
        }
    }
}
