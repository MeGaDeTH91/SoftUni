using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class GoldenEditionBook : Book
{
    public GoldenEditionBook(string title, string author, decimal price)
        :base(title, author, price)
    {
        this.Price *= 1.3m;
    }
}
