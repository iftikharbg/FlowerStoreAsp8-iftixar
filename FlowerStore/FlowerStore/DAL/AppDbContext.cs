using FlowerStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerStore.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
        {


        }
        public DbSet<Slider> Sliders { get; set; }

        public DbSet<Valentine> Valentines { get; set; }

        public DbSet<ListItem> LitsItems { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<SubscribeTable> subscribeTables { get; set; }
        public DbSet<Expert> Experts { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<Footer> Footers { get; set; }

        public DbSet<Header> Headers { get; set; }

        public DbSet<Worker> Workers { get; set; }

        public DbSet<Blog> Blogs { get; set; } 

        public DbSet<BlogItems> BlogItems { get; set; }

        public DbSet<Images> Images { get; set; }

        public DbSet<Hashtag> Hashtags { get; set; }
        public DbSet<SliderImage> SliderImage { get; set; }














    }
}
