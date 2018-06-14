namespace HTTPServer.GameStoreApplication.Models
{
    public class Cake
    {
        public Cake()
        {
            this.Url = "https://www.archiesonline.com/upload/product/large/Happy_Birthday_Choco_Cake_PRCAKE139_70abbd2d.jpg";
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Url { get; set; }
    }
}
